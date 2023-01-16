using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Contest.Tasks.Contest
{
    internal class Task_E
    {
        // Отчет
        internal static void Main_Task()
        {
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var taskCount = int.Parse(Console.ReadLine());
                var line = Console.ReadLine();
                var tasksList = line?.Split(' ').Select(x => int.Parse(x)).ToList();
                var dic = new SortedDictionary<int, List<int>>();

                bool isValid = true;
                for (int j = 0; j < taskCount; j++)
                {
                    var num = tasksList[j];

                    if (dic.ContainsKey(num))
                    {
                        if (j - dic[num].Last() > 1)
                        {
                            isValid = false;
                            break;
                        }

                        dic[num].Add(j);
                    }

                    else
                    {
                        dic.Add(num, new List<int>());
                        dic[num].Add(j);
                    }
                }

                Console.WriteLine(isValid ? "YES" : "NO");
            }
        }
    }
}
