using System;

namespace ReLink {
    class NativeHelper {
        internal static OSVersion GetOSVersion() {
            if ((Environment.OSVersion.Version.Major == 10)) {
                return OSVersion.Win10;
            } else if ((Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 2)) {
                return OSVersion.Win8;
            } else {
                return OSVersion.Unknown;
            }
        }
    }
}
