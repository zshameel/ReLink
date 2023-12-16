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
            try {
                GetBrowserByType(BrowserType.EdgeLegacy).ExePath = "microsoft-edge:";
            } catch { }
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

        internal static void GetBrowserInfoFromAppId(string appId, out BrowserType browserType, out string browserName) {
            if (string.IsNullOrWhiteSpace(appId) || appId.Contains("IE.HTTP")) {
                browserType = BrowserType.InternetExplorer;
                browserName = "Internet Explorer";
            } else if (appId.Contains("AppXq0fevzme2pys62n3e0fbqa7peapykr8v")) {
                browserType = BrowserType.EdgeLegacy;
                browserName = "Edge (Legacy)";
            } else if (appId.Contains("MSEdgeHTM")) {
                browserType = BrowserType.Edge;
                browserName = "Edge";
            } else if (appId.Contains("Firefox")) {
                browserType = BrowserType.Firefox;
                browserName = "Firefox";
            } else if (appId.Contains("Chrome")) {
                browserType = BrowserType.Chrome;
                browserName = "Chrome";
            } else if (appId.Contains("Opera")) {
                browserType = BrowserType.Opera;
                browserName = "Opera";
            } else if (appId.Contains("Safari")) {
                browserType = BrowserType.Safari;
                browserName = "Safari";
            } else if (appId.Contains("Brave")) {
                browserType = BrowserType.Brave;
                browserName = "Brave";
            } else if (appId.Contains("ChromiumHTM.CDR3CLVQ567AB7Y3475B63PFYE")) {
                browserType = BrowserType.Sidekick;
                browserName = "Sidekick";
            } else {
                browserType = BrowserType.Unknown;
                browserName = appId;
            }
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