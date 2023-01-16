using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Contest.Tasks.Sandbox;

public class Task_J
{
    // Электронная таблица
    internal static void Main_Task()
    {
        var count = Convert.ToInt32(Console.ReadLine());

        for (var i = 0; i < count; i++)
        {
            Console.ReadLine();
            var splitString = Console.ReadLine()?.Split(' ');
            var rowsCount = Convert.ToInt32(splitString[0]);
            var columnsCount = Convert.ToInt32(splitString[1]);

            var array = new int[rowsCount][];

            for (var j = 0; j < rowsCount; j++)
            {
                var numsString = Console.ReadLine()?.Split(' ');
                array[j] = new int[columnsCount];
                for (int k = 0; k < columnsCount; k++)
                {
                    array[j][k] = Convert.ToInt32(numsString[k]);
                }
            }

            var clickCount = Convert.ToInt32(Console.ReadLine());

            var columnNumberString = Console.ReadLine()?.Split(' ');
            foreach (var col in columnNumberString)
            {
                var columnNumber = Convert.ToInt32(col);
                array = array.OrderBy(x => x[columnNumber - 1]).ToArray();
            }

            for (int r = 0; r < rowsCount; r++)
            {
                Console.WriteLine(string.Join(" ", array[r]));
            }

            Console.WriteLine();
        }
    }
}