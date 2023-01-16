using System;
using System.Collections.Generic;

namespace Route256.Contest.Tasks.Sandbox
{
    // Wordle
    internal class Task_D
    {
        private const char GREEN = 'G';
        private const char YELLOW = 'Y';
        private const char GRAY = '.';

        internal static void Main_Task()
        {
            var s = Console.ReadLine();
            var dic = new Dictionary<char, int>();

            foreach (var sym in s)
            {
                if (dic.ContainsKey(sym))
                {
                    dic[sym] += 1;
                }
                else
                {
                    dic.Add(sym, 1);
                }
            }

            var t = Console.ReadLine();
            var length = s.Length;
            var res = new char[length];

            for (var i = 0; i < length; i++)
            {
                if (s[i] != t[i]) continue;

                res[i] = GREEN;
                dic[s[i]] -= 1;
            }

            for (var i = 0; i < length; i++)
            {
                if (!res[i].Equals(GREEN) && dic.ContainsKey(t[i]) && dic[t[i]] > 0)
                {
                    res[i] = YELLOW;
                    dic[t[i]] -= 1;
                }
                else if (!res[i].Equals(GREEN))
                {
                    res[i] = GRAY;
                }
            }

            Console.WriteLine(string.Concat(res));
        }
    }
}
