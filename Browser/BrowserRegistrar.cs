/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace ReLink {
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


        internal static BrowserRegistrar GetRegistrar() {
            switch (NativeHelper.GetOSVersion()) {
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

            BrowserType browserType;
            string browserName;

            BrowserManager.GetBrowserInfoFromAppId(appId, out browserType, out browserName);

            browser.BrowserType = browserType;
            browser.Name = browserName;

            return browser;
        }

    }

}