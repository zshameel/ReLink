/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

namespace ReLink {

    internal class Wildcard {
        internal static bool IsMatch(string input, string pattern) {
            bool isMatch = true;

            string[] parts = pattern.Split('*');
            int index = -1;
            foreach (string part in parts) {
                if (!string.IsNullOrWhiteSpace(part)) {
                    if (input.IndexOf(part) > index) {
                        index = input.IndexOf(part);
                        continue;
                    } else {
                        isMatch = false;
                        break;
                    }
                }
            }

            return isMatch;
        }
    }

}