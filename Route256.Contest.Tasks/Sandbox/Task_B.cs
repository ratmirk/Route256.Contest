using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Contest.Tasks.Sandbox
{
    internal class Task_B
    {
        internal static void Main_Task()
        {
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var taskCount = int.Parse(Console.ReadLine());
                var line = Console.ReadLine();
                var tasksList = line?.Split(' ').Select(x => int.Parse(x)).ToList();
                var dic = new SortedDictionary<int, SortedSet<int>>();

                for (int j = 0; j < taskCount; j++)
                {
                    var num = tasksList[j];
                    if (!dic.ContainsKey(num))
                    {
                        dic.Add(num, new SortedSet<int>());
                    }
                    dic[num].Add(j);
                }

                var keys = dic.Keys.ToList();

                for (int k = keys.Count - 1, ii = 1; k >= 0; k--, ii++)
                
                {
                    if (keys.Count == 1 || k == 0)
                    {
                        foreach (var t in dic[keys.First()])
                        {
                            tasksList[t] = ii;
                        }
                        break;
                    }
                    if (keys[k] == keys[k - 1] + 1)
                    {
                        foreach (var t in dic[keys[k]])
                        {
                            tasksList[t] = ii;
                        }
                        foreach (var t in dic[keys[k - 1]])
                        {
                            tasksList[t] = ii;
                        }

                        k--;
                    }
                    else
                    {
                        foreach (var t in dic[keys[k]])
                        {
                            tasksList[t] = ii;
                        }
                    }
                }

                
                Console.WriteLine(string.Join(" ", tasksList));
            }
        }
    }
}
