/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReLink
{

    class Rule : IEquatable<Rule>, IComparable<Rule> {

        internal int RuleId { get; set; }
        internal MatchType MatchType { get; set; }
        internal string Url { get; set; }
        internal string BrowserName { get; set; }

        internal bool IsMatch(string matchUrl) {
            switch(MatchType) {
                case MatchType.Contains:
                    return (matchUrl.Contains(Url));
                case MatchType.StartsWith:
                    return (matchUrl.StartsWith(Url));
                case MatchType.ExactMatch:
                    return (matchUrl.Equals(Url, StringComparison.OrdinalIgnoreCase));
                case MatchType.Wildcard:
                    return Wildcard.IsMatch(matchUrl, Url);
                case MatchType.Regex:
                    return Regex.IsMatch(matchUrl, Url, RegexOptions.IgnoreCase);
                default:
                    return false;
            }
        }

        public override string ToString() {
            return string.Format("RuleId={0}|MatchType={1}|Url={2}|BrowserName={3}", RuleId, MatchType, Url, BrowserName);
        }

        public static Rule Parse(string ruleString) {
            if (string.IsNullOrWhiteSpace(ruleString)) {
                return null;
            }

            Rule rule = new Rule();
            string[] parts = ruleString.Split('|');
            foreach(string part in parts) {
                int index = part.IndexOf('=');
                if (index <= 0) {
                    continue;
                } else {
                    string key = part.Substring(0, index);
                    string value = part.Substring(index + 1);

                    if (key.Equals("RuleId", StringComparison.OrdinalIgnoreCase)) {
                        rule.RuleId = Convert.ToInt32(value);
                    } else if (key.Equals("MatchType", StringComparison.OrdinalIgnoreCase)) {
                        rule.MatchType = (MatchType)Enum.Parse(typeof(MatchType), value);
                    } else if (key.Equals("Url", StringComparison.OrdinalIgnoreCase)) {
                        rule.Url = BrowserManager.GetSanitizedUrl(value);
                    } else if (key.Equals("BrowserName", StringComparison.OrdinalIgnoreCase)) {
                        rule.BrowserName = value;
                    }
                }
            }

            return rule;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            Rule rule = obj as Rule;
            if (rule == null) {
                return false;
            } else {
                return Equals(rule);
            }
        }

        public bool Equals(Rule other) {
            if (other == null) {
                return false;
            }
            return (this.RuleId.Equals(other.RuleId));
        }

        // Default comparer for Rule type.
        public int CompareTo(Rule compareRule) {
            // A null value means that this object is greater.
            if (compareRule == null) {
                return 1;
            } else {
                return this.RuleId.CompareTo(compareRule.RuleId);
            }
        }

        public override int GetHashCode() {
            return RuleId;
        }

    }
}
