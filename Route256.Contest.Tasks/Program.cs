using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;


[assembly: InternalsVisibleTo("Route256.Contest.Tests")]

namespace Route256.Contest.Tasks
{
    internal class Program
    {
        public static readonly IConfiguration Configuration =
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        private static readonly string TaskType = Configuration["TaskType"];
        private static readonly string TaskName = Configuration["TaskName"];

        internal static void Main()
        {
            Enum.TryParse(TaskType, out TaskType taskType);
            Enum.TryParse(TaskName, out TaskName taskName);

            RunTask(taskType, taskName);
        }

        private static void RunTask(TaskType taskType, TaskName taskName)
        {
            if (taskType == Tasks.TaskType.Contest)
            {
                switch (taskName)
                {
                    case Tasks.TaskName.A:
                        Contest.Task_A.Main_Task();
                        break;
                    case Tasks.TaskName.B:
                        Contest.Task_B.Main_Task();
                        break;
                    case Tasks.TaskName.C:
                        Contest.Task_C.Main_Task();
                        break;
                    case Tasks.TaskName.D:
                        Contest.Task_D.Main_Task();
                        break;
                    case Tasks.TaskName.E:
                        Contest.Task_E.Main_Task();
                        break;
                    case Tasks.TaskName.F:
                        Contest.Task_F.Main_Task();
                        break;
                    case Tasks.TaskName.G:
                        Contest.Task_G.Main_Task();
                        break;
                    default:
                        throw new ArgumentException("Некорректное имя таски");
                }
            }
            else if (taskType == Tasks.TaskType.Sandbox)
            {
                switch (taskName)
                {
                    case Tasks.TaskName.A:
                        Sandbox.Task_A.Main_Task();
                        break;
                    case Tasks.TaskName.B:
                        Sandbox.Task_B.Main_Task();
                        break;
                    case Tasks.TaskName.C:
                        Sandbox.Task_C.Main_Task();
                        break;
                    case Tasks.TaskName.D:
                        Sandbox.Task_D.Main_Task();
                        break;
                    case Tasks.TaskName.E:
                        Sandbox.Task_E.Main_Task();
                        break;
                    case Tasks.TaskName.F:
                        Sandbox.Task_F.Main_Task();
                        break;
                    case Tasks.TaskName.G:
                        Sandbox.Task_G.Main_Task();
                        break;
                    default:
                        throw new ArgumentException("Некорректное имя таски");
                }
            }
        }
    }
}
