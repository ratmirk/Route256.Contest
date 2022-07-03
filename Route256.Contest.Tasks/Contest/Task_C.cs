using System;
using System.Linq;

namespace Route256.Contest.Tasks.Contest
{
    internal class Task_C
    {
        internal static void Main_Task()
        {
            var countList = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            var usersCount = countList.First();
            var requestCount = countList.Last();

            var usersRequests = Enumerable.Range(1, usersCount).ToDictionary(x => x, x => 0);
            var commonMsgIndex = 0;

            for (int i = 0, rIndex = 1; i < requestCount; i++)
            {
                var request = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                var reqType = request.First();
                var reqId = request.Last();

                if (reqType == 1)
                {
                    if (reqId != 0)
                    {
                        usersRequests[reqId] = rIndex;
                    }
                    else
                    {
                        commonMsgIndex = rIndex;
                    }
                    rIndex++;
                }
                else
                {
                    if (usersRequests[reqId] > commonMsgIndex)
                    {
                        Console.WriteLine(usersRequests[reqId]);
                    }
                    else
                    {
                        Console.WriteLine(commonMsgIndex);
                    }
                }
            }
        }
    }
}
