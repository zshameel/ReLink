/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ReLink
{
    class BrowserRegistrarWin10 : BrowserRegistrar {

        internal override void RegisterRelinkAsBrowser() {
            //Unregister AppId.
            UnregisterRelinkAsBrowser();

            RegistryKey appReg = RootKey.OpenSubKey("SOFTWARE", true);
            appReg = appReg.CreateSubKey(CompanyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
            //appReg now points to SOFTWARE\AdroitTechnologies
            appReg = appReg.CreateSubKey(AppName, RegistryKeyPermissionCheck.ReadWriteSubTree);
            //appReg now points to SOFTWARE\AdroitTechnologies\ReLink

            // Register capabilities.
            var capabilityReg = appReg.CreateSubKey("Capabilities");
            capabilityReg.SetValue("ApplicationName", AppName);
            capabilityReg.SetValue("ApplicationIcon", AppIcon);
            capabilityReg.SetValue("ApplicationDescription", AppDescription);

            // Set up protocols we want to handle.
            var urlAssoc = capabilityReg.CreateSubKey("URLAssociations");
            urlAssoc.SetValue("http", AppId);
            urlAssoc.SetValue("https", AppId);

            var regApps = RootKey.OpenSubKey(@"SOFTWARE\RegisteredApplications", true);
            regApps.SetValue(AppId, $@"SOFTWARE\{CompanyName}\{AppName}\Capabilities");

            string keyName = @"SOFTWARE\Classes\" + AppId;
            var classesReg = Registry.CurrentUser.CreateSubKey(keyName);
            classesReg.SetValue("", AppName);
            classesReg.CreateSubKey("DefaultIcon").SetValue("", AppIcon);
            classesReg.CreateSubKey("shell\\open\\command").SetValue("", AppOpenUrlCommand);

            classesReg = RootKey.CreateSubKey(keyName);
            classesReg.SetValue("", AppName);
            classesReg.CreateSubKey("DefaultIcon").SetValue("", AppIcon);
            classesReg.CreateSubKey("shell\\open\\command").SetValue("", AppOpenUrlCommand);
        }

        internal override void UnregisterRelinkAsBrowser() {
            // Unregister application.
            string classesKey = $@"Software\Classes\{AppId}";
            string orgKey = $@"Software\{CompanyName}\{AppId}";

            try {
                var regAppsCU = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RegisteredApplications", true);

                if (regAppsCU.GetValueNames().FirstOrDefault(v => v.Equals(AppId)) != null) {
                    regAppsCU.DeleteValue(AppId);
                }

                if (Registry.CurrentUser.GetSubKeyNames().FirstOrDefault(v => v.Equals(classesKey)) != null) {
                    Registry.CurrentUser.DeleteSubKeyTree(classesKey);
                }

                if (Registry.CurrentUser.GetSubKeyNames().FirstOrDefault(v => v.Equals(orgKey)) != null) {
                    Registry.CurrentUser.DeleteSubKeyTree(orgKey);
                }
            } catch {
                //throw;
            }

            try {
                var regAppsLM = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\RegisteredApplications", true);

                if (regAppsLM.GetValueNames().FirstOrDefault(v => v.Equals(AppId)) != null) {
                    regAppsLM.DeleteValue(AppId);
                }

                if (Registry.LocalMachine.GetSubKeyNames().FirstOrDefault(v => v.Equals(classesKey)) != null) {
                    Registry.LocalMachine.DeleteSubKeyTree(classesKey);
                }

                if (Registry.LocalMachine.GetSubKeyNames().FirstOrDefault(v => v.Equals(orgKey)) != null) {
                    Registry.LocalMachine.DeleteSubKeyTree(orgKey);
                }
            } catch {
                //throw;
            }
        }

        internal override bool IsRelinkTheDefaultBrowser() {
            return GetDefaultBrowser()!.AppId.Equals(AppId, StringComparison.OrdinalIgnoreCase);
        }

        internal override BrowserInfo GetDefaultBrowser() {
            string appId = string.Empty;

            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(UserChoiceKeyPath)) {
                if (userChoiceKey != null) {
                    object appIdValue = userChoiceKey.GetValue("Progid");
                    if (appIdValue != null) {
                        appId = appIdValue.ToString();
                    }
                }
                return GetBrowserInfo(appId);
            }
        }

        internal override void SetRelinkAsDefaultBrowser() {
            new Process() {
                StartInfo = new ProcessStartInfo() {
                    FileName = "ms-settings:defaultapps"
                }
            }.Start();
        }

        internal override BrowserInfo[] GetRegisteredBrowsers() {
            List<BrowserInfo> browsers = new List<BrowserInfo>();
            InitBrowsers(browsers, true);
            InitBrowsers(browsers, false);
            return browsers.ToArray();
        }

        private void InitBrowsers(List<BrowserInfo> browsers, bool currentUser) {
            List<string> valueNames = new List<string>();

            try {
                RegistryKey rootKey = currentUser ? Registry.CurrentUser : Registry.LocalMachine;

                var regApps = rootKey.OpenSubKey(@"SOFTWARE\RegisteredApplications");
                var regValuesCU = regApps.GetValueNames();
                valueNames.AddRange(regValuesCU);

                foreach (string regValue in valueNames.ToArray()) {
                    string capabilitiesPath = Convert.ToString(regApps.GetValue(regValue)); //This has the capabilities key location

                    var capabilitiesKey = rootKey.OpenSubKey(capabilitiesPath);
                    if (capabilitiesKey != null) {
                        var urlAssocKey = capabilitiesKey.OpenSubKey("URLAssociations");
                        if (urlAssocKey != null) {
                            var objAppId = urlAssocKey.GetValue("http");
                            if (objAppId != null) {
                                string appId = Convert.ToString(objAppId);
                                if (appId != null && appId != AppId) { //Exclude ReLink
                                    if (browsers.Count(b => b.AppId.Equals(appId, StringComparison.OrdinalIgnoreCase)) == 0) { //If not already added
                                        BrowserInfo browser = GetBrowserInfo(appId);
                                        if (browser != null) {
                                            browsers.Add(browser);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }
    }

}
