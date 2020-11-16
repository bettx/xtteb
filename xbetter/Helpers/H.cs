using System;
using System.Collections.Generic;

namespace xbetter.Helpers
{
    public static class H
    {
        public static string FReplace(this string text, string oldChar, string newChar)
        {
            try
            {
                var f1 = text.IndexOf(oldChar, StringComparison.Ordinal);
                text = text.Remove(f1, oldChar.Length);
                return text.Insert(f1, newChar);
            }
            catch
            {
                return text;
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while(n > 1)
            {
                var k = Rnd.Next(0, n) % n;
                n--;
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}
