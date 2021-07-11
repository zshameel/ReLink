/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

using ReLink.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ReLink {
    internal class BrowserManager {

        static BrowserInfo[] browsers;
        static List<Rule> rules;

        static BrowserManager() {
            InitBrowsers();
            InitRules();
        }

        private static void InitBrowsers() {
            browsers = BrowserManager.GetRegisteredBrowsers();

            //Edge quirk
            GetBrowserByType(BrowserType.EdgeLegacy)!.ExePath = "microsoft-edge:";
        }

        private static void InitRules() {
            rules = new List<Rule>();
            if (BrowserSettings.Rules != null) {
                foreach (object objRule in BrowserSettings.Rules) {
                    Rule rule = Rule.Parse(Convert.ToString(objRule));
                    if (rule != null) {
                        rules.Add(rule);
                    }
                }
            }

            rules.Sort();
        }

        static internal BrowserInfo[] Browsers {
            get {
                return browsers;
            }
        }

        static internal BrowserInfo LaunchUrl(string url) {
            BrowserInfo browser = BrowserSettings.UseDefaultBrowserForAllLinks ?
                                    GetBrowserByName(BrowserSettings.DefaultBrowserName) :
                                    GetBrowserForUrl(url);

            LaunchUrlWithBrowser(url, browser);
            return browser;
        }

        static internal void LaunchUrlWithBrowser(string url, string browserName) {
            LaunchUrlWithBrowser(url, GetBrowserByName(browserName));
        }

        static internal void LaunchUrlWithBrowser(string url, BrowserInfo browser) {
            url = GetSanitizedUrl(url);

            ProcessStartInfo psi = new ProcessStartInfo();
            if (browser.ExePath.EndsWith(":")) {
                psi.FileName = $"{browser.ExePath}{url}";
            } else {
                psi.FileName = browser.ExePath;
                psi.Arguments = url;
            }

            new Process() {
                StartInfo = psi
            }.Start();
        }

        static BrowserInfo GetBrowserForUrl(string url) {
            BrowserInfo browser = null;

            url = GetSanitizedUrl(url);

            Rule rule = rules.FirstOrDefault(r => r.IsMatch(url));

            if (rule != null) {
                browser = GetBrowserByName(rule.BrowserName);
            }

            if (browser == null) {
                browser = GetBrowserByName(BrowserSettings.DefaultBrowserName);
            }

            if (browser == null) {
                browser = BrowserManager.GetBrowserByType(BrowserType.Edge);
                if (browser == null) {
                    browser = BrowserManager.GetBrowserByType(BrowserType.EdgeLegacy);
                    if (browser == null) {
                        browser = BrowserManager.GetBrowserByType(BrowserType.InternetExplorer);
                    }
                }
            }

            return browser;
        }

        internal static string GetSanitizedUrl(string url) {
            url = url.Trim();
            while (url.EndsWith("/")) {
                url = url.Substring(0, url.Length - 1);
            }

            return url;
        }

        static BrowserInfo GetBrowserByType(BrowserType browserType) {
            return browsers.FirstOrDefault(b => b.BrowserType == browserType);
        }

        internal static BrowserInfo GetBrowserByName(string browserName) {
            return browsers.FirstOrDefault(b => b.Name.Equals(browserName, StringComparison.OrdinalIgnoreCase));
        }

        internal static void RegisterOrUnregisterAsAdmin(bool register) {
#if (DEBUG)
            if (register) {
                RegisterRelinkAsBrowser();
            } else {
                UnregisterRelinkAsBrowser();
            }
#else
            new Process() {
                StartInfo = new ProcessStartInfo {
                    FileName = Assembly.GetExecutingAssembly().Location,
                    Arguments = register ? ReLinkMain.ARG_REGISTER : ReLinkMain.ARG_UNREGISTER,
                    Verb = ReLinkMain.RUNAS_VERB
                }
            }.Start();
#endif
        }

        private static BrowserRegistrar Registrar {
            get {
                return BrowserRegistrar.GetRegistrar();
            }
        }

        internal static BrowserInfo[] GetRegisteredBrowsers() => Registrar.GetRegisteredBrowsers();

        internal static void RegisterRelinkAsBrowser() => Registrar.RegisterRelinkAsBrowser();

        internal static void UnregisterRelinkAsBrowser() => Registrar.UnregisterRelinkAsBrowser();

        internal static void SetRelinkAsDefaultBrowser() => Registrar.SetRelinkAsDefaultBrowser();

        internal static bool IsRelinkTheDefaultBrowser => Registrar.IsRelinkTheDefaultBrowser();
    }
}