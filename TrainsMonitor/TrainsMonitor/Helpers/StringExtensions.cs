using System;
using System.Collections.Generic;

namespace TrainsMonitor.Helpers
{
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitInParts(this string s, int partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

        public static string StringCuttedBy(this string s, string separator)
        {
            var l = s.IndexOf(separator, StringComparison.Ordinal);
            return l > 0 ? s.Substring(0, l) : s;
        }
    }
}