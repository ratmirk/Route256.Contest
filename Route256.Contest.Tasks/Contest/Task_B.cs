using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Contest.Tasks.Contest
{
    internal static class Task_B
    {
        // Парное программирование
        internal static void Main_Task()
        {
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var taskCount = int.Parse(Console.ReadLine());
                var line = Console.ReadLine();
                var tasksList = line?.Split(' ').Select(x => int.Parse(x)).ToList().Select((x, i) => new{x, i}).ToList();

                while (tasksList.Count > 0)
                {
                    var first = tasksList.First();
                    var nextFinal = tasksList[1];
                    var delta = -1;
                    var deltaFinal = Math.Abs(first.x - nextFinal.x);

                    for (int k = 1; k < tasksList.Count; k++)
                    {
                        var next = tasksList[k];
                        delta = Math.Abs(first.x - next.x);

                        if (delta == 0)
                        {
                            nextFinal = next;
                            break;
                        }

                        if (delta < deltaFinal)
                        {
                            nextFinal = next;
                            deltaFinal = delta;
                        }
                    }

                    tasksList.RemoveAt(0);
                    tasksList.Remove(nextFinal);
                    Console.WriteLine($"{first.i + 1} {nextFinal.i + 1}");
                }

                Console.WriteLine();
            }
        }
    }
}

