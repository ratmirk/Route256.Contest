using System;
using System.Collections.Generic;

namespace Route256.Contest.Tasks.Sandbox;

public class Task_H
{
    // Сумма к оплате
    internal static void Main_Task()
    {
        var count = Convert.ToInt32(Console.ReadLine());

        for (var i = 0; i < count; i++)
        {
            var priceCount = Convert.ToInt32(Console.ReadLine());
            var line = Console.ReadLine();
            var splitString = line?.Split(' ');
            var dic = new Dictionary<int, int>();

            foreach (var str in splitString)
            {
                var num = Convert.ToInt32(str);
                if (dic.ContainsKey(num))
                {
                    dic[num] += 1;
                }
                else
                {
                    dic.Add(num, 1);
                }
            }

            int sum = 0;

            foreach (var kvp in dic)
            {
                sum = sum + ((kvp.Value - kvp.Value / 3) * kvp.Key);
            }

            Console.WriteLine(sum);
        }
    }
}