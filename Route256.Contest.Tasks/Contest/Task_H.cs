using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Contest.Tasks.Contest
{
    internal class Task_H
    {
        internal static void Main_Task()
        {
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var countList = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                var rowsCount = countList.First();
                var symCount = countList.Last();

                var colorsDict = new Dictionary<char, List<(int, int)>>();
                for (int j = 0; j < rowsCount; j++)
                {
                    var line = Console.ReadLine();
                    var colors = line.Split('.', StringSplitOptions.RemoveEmptyEntries).ToList().Select(X => X.ToCharArray().First()).ToList();
                    if (line.First() == '.')
                    {
                        for (int k = 0, ii = 2; k < colors.Count; k++, ii+=2)
                        {
                            if (!colorsDict.ContainsKey(colors[k]))
                            {
                                colorsDict.Add(colors[k], new List<(int, int)>());
                            }

                            colorsDict[colors[k]].Add((j + 1, ii));
                        }
                    }
                    else
                    {
                        for (int k = 0, ii = 1; k < colors.Count; k++, ii += 2)
                        {
                            if (!colorsDict.ContainsKey(colors[k]))
                            {
                                colorsDict.Add(colors[k], new List<(int, int)>());
                            }

                            colorsDict[colors[k]].Add((j + 1, ii));
                        }
                    }
                }

                Console.WriteLine(Validate(colorsDict, rowsCount) ? "YES" : "NO");
            }
        }

        public static bool Validate(Dictionary<char, List<(int, int)>> field, int rowsCount)
        {
            bool isValid = true;

            var keys = field.Keys;
            var areaCount = 0;

            foreach (var key in keys)
            {
                foreach (var cell in field[key])
                {
                    if (cell.Item2 != rowsCount)
                    {

                    }

                    if (cell.Item1 != rowsCount)
                    {

                    }
                }
            }

            return isValid;
        }
    }

    public class Cell
    {
        public int X;
        public int Y;

        public Cell(string color, int x, int y)
        {
            Color = color;
            Area = 0;
            X = x;
            Y = y;
        }

        public string Color;

        public int Area;

        public List<Cell> Neighbors;
    }
}
