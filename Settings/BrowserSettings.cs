/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

using System.Collections;

namespace ReLink.Core {
    static class BrowserSettings {
        static Properties properties = PropertyService.Get("BrowserSettings", new Properties());

        public static Properties Properties {
            get { return properties; }
        }

        public static string DefaultBrowserName {
            get {
                string defaultBrowser = "Edge";
                return properties.Get<string>("DefaultBrowser", defaultBrowser);
            }
            set { properties.Set<string>("DefaultBrowser", value); }
        }

        public static bool UseDefaultBrowserForAllLinks {
            get {
                return properties.Get<bool>("UseDefaultBrowserForAllLinks", false);
            }
            set { properties.Set<bool>("UseDefaultBrowserForAllLinks", value); }
        }

        public static ArrayList Rules {
            get {
                return properties.Get<ArrayList>("Rules", null);
            }
            set { properties.Set<ArrayList>("Rules", value); }
        }

    }
}