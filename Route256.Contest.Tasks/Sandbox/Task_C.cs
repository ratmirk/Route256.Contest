using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Contest.Tasks.Sandbox
{
    // Дельта-кодирование
    internal class Task_C
    {
        internal static void Main_Task()
        {
            var count = int.Parse(Console.ReadLine());
            var line = Console.ReadLine();
            var deltas = line?.Split(' ').Select(x => int.Parse(x)).ToList();

            DeltaDecoding(deltas);
        }

        private static void DeltaDecoding(List<int> deltas)
        {
            var min = deltas.Min();
            var count = deltas.Count;
            var index = deltas.IndexOf(min) + 1;
            var newArray = new int[count + 1];

            newArray[index] = 0;

            for (int i = index; i < count; i++)
            {
                newArray[i + 1] = newArray[i] + deltas[i];
            }

            for (int i = index; i > 0; i--)
            {
                newArray[i - 1] = newArray[i] - deltas[i - 1];
            }

            var resultMin = newArray.Min();
            var delta = 0 - resultMin;
            if (delta > 0)
            {
                newArray = newArray.Select(x => x + delta).ToArray();
            }

            Console.WriteLine(string.Join(" ", newArray));
        }
    }
}
