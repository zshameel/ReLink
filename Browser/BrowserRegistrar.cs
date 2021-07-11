/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace ReLink
{
    abstract class BrowserRegistrar {

        protected const string AppId = "ReLink";
        protected const string AppName = "ReLink";
        protected const string AppDescription = "ReLink, The Browser Bootstraper";
        protected const string CompanyName = "AdroitTechnologies";
        protected const string UserChoiceKeyPath = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";

        protected static string AppPath = Assembly.GetExecutingAssembly().Location;
        protected static string AppIcon = AppPath + ",1";
        protected static string AppOpenUrlCommand = AppPath + " \"%1\"";
        protected static string AppReinstallCommand = AppPath + ReLinkMain.ARG_REGISTER;

        static bool IsAdminMode = false;

        protected static RegistryKey RootKey {
            get {
                return IsAdminMode ? Registry.LocalMachine : Registry.CurrentUser;
            }
        }

        private static OSVersion GetOSVersion() {
            if ((Environment.OSVersion.Version.Major == 10)) {
                return OSVersion.Win10;
            } else if ((Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 2)) {
                return OSVersion.Win8;
            } else {
                return OSVersion.Unknown;
            }
        }

        internal static BrowserRegistrar GetRegistrar() {
            switch (GetOSVersion()) {
                //case OSVersion.Win7:
                //    return new BrowserRegistrarWin7();
                case OSVersion.Win8:
                    return new BrowserRegistrarWin10();
                case OSVersion.Win10:
                    return new BrowserRegistrarWin10();
                default:
                    throw new NotSupportedException("The Operating System is not supported.");
            }
        }

        internal abstract void RegisterRelinkAsBrowser();

        internal abstract void UnregisterRelinkAsBrowser();

        internal abstract void SetRelinkAsDefaultBrowser();

        internal abstract bool IsRelinkTheDefaultBrowser();

        internal abstract BrowserInfo GetDefaultBrowser();

        internal abstract BrowserInfo[] GetRegisteredBrowsers();

        protected BrowserInfo GetBrowserInfo(string appId) {

            if (string.IsNullOrWhiteSpace(appId)) {
                return null;
            }

            BrowserInfo browser = new BrowserInfo();
            browser.AppId = appId;

            const string exeSuffix = ".exe";
            string path = appId + @"\shell\open\command";
            FileInfo browserPath;
            using (RegistryKey pathKey = Registry.ClassesRoot.OpenSubKey(path)) {
                if (pathKey == null) {
                    return null;
                }

                // Trim parameters.
                try {
                    path = pathKey.GetValue(null).ToString().ToLower().Replace("\"", "");
                    if (!path.EndsWith(exeSuffix)) {
                        path = path.Substring(0, path.LastIndexOf(exeSuffix, StringComparison.Ordinal) + exeSuffix.Length);
                        browserPath = new FileInfo(path);
                        browser.ExePath = browserPath.FullName;
                        browser.Icon = Icon.ExtractAssociatedIcon(browser.ExePath);
                    }
                } catch {
                    // Assume the registry value is set incorrectly, or some funky browser is used which currently is unknown.
                }
            }

            if (string.IsNullOrWhiteSpace(appId) || appId.Contains("IE.HTTP")) {
                browser.BrowserType = BrowserType.InternetExplorer;
                browser.Name = "Internet Explorer";
            } else if (appId.Contains("AppXq0fevzme2pys62n3e0fbqa7peapykr8v")) {
                browser.BrowserType = BrowserType.EdgeLegacy;
                browser.Name = "Edge (Legacy)";
            } else if (appId.Contains("MSEdgeHTM")) {
                browser.BrowserType = BrowserType.Edge;
                browser.Name = "Edge";
            } else if (appId.Contains("Firefox")) {
                browser.BrowserType = BrowserType.Firefox;
                browser.Name = "Firefox";
            } else if (appId.Contains("Chrome")) {
                browser.BrowserType = BrowserType.Chrome;
                browser.Name = "Chrome";
            } else if (appId.Contains("Opera")) {
                browser.BrowserType = BrowserType.Opera;
                browser.Name = "Opera";
            } else if (appId.Contains("Safari")) {
                browser.BrowserType = BrowserType.Safari;
                browser.Name = "Safari";
            } else if (appId.Contains("Brave")) {
                browser.BrowserType = BrowserType.Brave;
                browser.Name = "Brave";
            } else {
                browser.BrowserType = BrowserType.Unknown;
                browser.Name = appId;
            }

            return browser;
        }
    }

}
