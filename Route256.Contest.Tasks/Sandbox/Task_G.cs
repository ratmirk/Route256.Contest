using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Contest.Tasks.Sandbox
{
    internal class Task_G
    {
        private const char ZERO = '0';
        private const char CROSS = 'X';
        private const char DOT = '.';

        internal static void Main_Task()
        {

            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                Console.ReadLine();

                var field = new Dictionary<char, SortedSet<int>>();
                for (int j = 0, ii = 1; j < 3; j++)
                {
                    var cells = Console.ReadLine().ToList();
                    for (int c = 0; c < cells.Count; c++)
                    {
                        if (!field.ContainsKey(cells[c]))
                        {
                            field.Add(cells[c], new SortedSet<int>());
                        }
                        field[cells[c]].Add(ii);
                        ii++;
                    }
                }

                Console.WriteLine(IsValid(field) ? "YES" : "NO");
            }
        }

        private static bool IsValid(Dictionary<char, SortedSet<int>> field)
        {
            // Поле из одинаковых символов
            if (field.Keys.Count == 1 && field.Keys.First() == DOT)
            {
                return true;
            }
            if (field.Keys.Count == 1 && field.Keys.First() != DOT)
            {
                return false;
            }

            // Поле содержит и крестики и нолики
            if (field.ContainsKey(CROSS) && field.ContainsKey(ZERO))
            {
                var crossCount = field[CROSS].Count();
                var zeroCount = field[ZERO].Count();
                if (zeroCount > crossCount || Math.Abs(crossCount - zeroCount) > 1)
                {
                    return false;
                }
                else
                {
                    return CheckLines(field, crossCount, zeroCount);
                }
            }
            // Поле содержит только крестики или нолики
            else if (field[field.Keys.Single(k => k != DOT)].Count > 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка линий и диагоналей
        /// </summary>
        private static bool CheckLines(Dictionary<char, SortedSet<int>> field, int crossCount, int zeroCount)
        {
            var lines = new List<List<int>>
            {
                new() {1, 2, 3}, new() {4, 5, 6}, new() {7, 8, 9}, new() {1, 4, 7},
                new() {2, 5, 8}, new() {3, 6, 9}, new() {1, 5, 9}, new() {3, 5, 7}
            };

            int crossLines = lines.Count(line => line.All(x => field[CROSS].Contains(x)));
            var zeroLines = lines.Count(line => line.All(x => field[ZERO].Contains(x)));

            if (crossLines > 1 || zeroLines > 1 || crossLines == 1 && zeroLines == 1)
            {
                return false;
            }

            if (zeroLines == 1 && zeroCount != crossCount || crossLines == 1 && zeroCount >= crossCount)
            {
                return false;
            }

            return true;
        }
    }
}
