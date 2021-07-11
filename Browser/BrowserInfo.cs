/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

using System.Drawing;

namespace ReLink
{
    internal class BrowserInfo {
        internal string Name { get; set; }
        internal string AppId { get; set; }
        internal string ExePath { get; set; }
        internal Icon Icon { get; set; }
        internal BrowserType BrowserType { get; set; }
    }
}