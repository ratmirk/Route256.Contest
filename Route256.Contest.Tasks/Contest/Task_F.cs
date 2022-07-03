using System;
using System.Linq;

namespace Route256.Contest.Tasks.Contest
{
    internal class Task_F
    {
        internal static void Main_Task()
        {
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var secondsSet = Enumerable.Range(0, 86400).ToHashSet();
                var isValid = true;

                var pairsCount = int.Parse(Console.ReadLine());
                for (int j = 0; j < pairsCount; j++)
                {
                    var timePair = Console.ReadLine().Split('-');
                    var firstTime = timePair.First().Split(':');
                    var firstHour = int.Parse(firstTime[0]);
                    var firstMinute = int.Parse(firstTime[1]);
                    var firstSecond = int.Parse(firstTime[2]);
                    var lastTime = timePair.Last().Split(':');
                    var lastHour = int.Parse(lastTime[0]);
                    var lastMinute = int.Parse(lastTime[1]);
                    var lastSecond = int.Parse(lastTime[2]);

                    var firstSeconds = firstHour * 3600 + firstMinute * 60 + firstSecond;
                    var lastSeconds = lastHour * 3600 + lastMinute * 60 + lastSecond;

                    if (firstSeconds > lastSeconds || firstHour > 23 || lastHour > 23 || firstMinute > 59 || lastMinute > 59 || firstSecond > 59 || lastSecond > 59)
                    {
                        isValid = false;
                    }
                    else
                    {
                        for (var s = firstSeconds; s <= lastSeconds; s++)
                        {
                            var isRemoved = secondsSet.Remove(s);
                            if (isRemoved) continue;

                            isValid = false;
                            break;
                        }
                    }
                }

                Console.WriteLine(isValid ? "YES" : "NO");
            }
        }
    }
}
