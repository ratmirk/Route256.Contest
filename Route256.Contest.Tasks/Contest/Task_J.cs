using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Contest.Tasks.Contest
{
    internal class Task_J
    {
        // Рифмы
        internal static void Main_Task()
        {
            var dictCount = int.Parse(Console.ReadLine());

            var rhythmDict = new SortedDictionary<int, Dictionary<string, List<string>>>();
            for (var i = 0; i < dictCount; i++)
            {
                var word = Console.ReadLine();
                for (int j = 1; j <= word.Length; j++)
                {
                    var rhythmSuffix = word.Substring(word.Length - j);
                    if (!rhythmDict.ContainsKey(j))
                    {
                        rhythmDict.Add(j, new Dictionary<string, List<string>>());
                    }

                    if (!rhythmDict[j].ContainsKey(rhythmSuffix))
                    {
                        rhythmDict[j].Add(rhythmSuffix, new List<string>());
                    }

                    var list = rhythmDict[j][rhythmSuffix];
                    list.Add(word);
                }
            }

            var requestCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < requestCount; i++)
            {
                var word = Console.ReadLine();
                for (int rhythmLen = word.Length; rhythmLen > 0 ; rhythmLen--)
                {
                    var rhythmSuffix = word.Substring(word.Length - rhythmLen);
                    if (!rhythmDict.ContainsKey(rhythmLen))
                    {
                        if (rhythmLen == 1)
                        {
                            Console.WriteLine(rhythmDict.First().Value.First().Value.First());
                        }

                        continue;
                    }

                    if (!rhythmDict[rhythmLen].ContainsKey(rhythmSuffix))
                    {
                        if (rhythmLen == 1)
                        {
                            Console.WriteLine(rhythmDict.First().Value.First().Value.First());
                        }

                        continue;
                    }

                    var rList = rhythmDict[rhythmLen][rhythmSuffix];
                    var rhythWord = rList.FirstOrDefault(x => x != word);
                    if (rhythWord != null)
                    {
                        Console.WriteLine(rhythWord);
                        break;
                    }
                    else
                    {
                        if (rhythmLen == 1)
                        {
                            Console.WriteLine(rhythmDict.First().Value.First().Value.First());
                        }
                    }
                }
            }
        }
    }
}
