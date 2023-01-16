using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Route256.Contest.Tasks.Contest
{
    internal class Task_I
    {
        // Планировщик задач
        internal static void Main_Task()
        {
            var countList = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();
            var procCount = countList.First();
            var taskCount = countList.Last();

            var procList = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();
            var procFreeSet = new SortedSet<long>();
            var procBusySet = new SortedSet<Proc>(new ProcComparer());
            long workPowerCommon = 0;

            foreach (var power in procList)
            {
                procFreeSet.Add(power);
            }

            for (int i = 0; i < taskCount; i++)
            {
                var taskList = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();
                var taskStartTime = taskList.First();
                var taskDuration = taskList.Last();

                if (procBusySet.Count > 0)
                {
                    var setCount = procBusySet.Count;

                    for (int j = 0; j < setCount; j++)
                    {
                        var procBusy = procBusySet.FirstOrDefault();

                        if (procBusy.EndWorkTime <= taskStartTime)
                        {
                            procBusySet.Remove(procBusy);
                            procBusy.EndWorkTime = 0;

                            procFreeSet.Add(procBusy.Power);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (procFreeSet.Count > 0)
                {
                    var procPower = procFreeSet.First();
                    procFreeSet.Remove(procPower);

                    workPowerCommon += taskDuration * procPower;
                    procBusySet.Add(new Proc(procPower) { EndWorkTime = taskStartTime + taskDuration });
                }
            }

            Console.WriteLine(workPowerCommon);
        }
    }

    public class Proc
    {
        public Proc(long power)
        {
            Power = power;
        }

        public long Power { get; set; }

        public long EndWorkTime { get; set; }
    }

    public class ProcComparer : IComparer<Proc>
    {
        public int Compare(Proc x, Proc y)
        {
            //first by EndWorkTime
            var result = x.EndWorkTime.CompareTo(y.EndWorkTime);

            //then power
            if (result == 0)
                result = x.Power.CompareTo(y.Power);

            return result;
        }
    }
}