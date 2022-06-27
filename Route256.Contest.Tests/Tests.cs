using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Route256.Contest.Tasks;

namespace Route256.Contest.Tests
{
    [TestFixture]
    public class Tests
    {
        private static readonly string FilePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, Program.Configuration["TestsPath"]);
        private static readonly int TestsCount = Directory.GetFiles(FilePath).Length / 2;

        protected static List<int> TestCaseProvider() => Enumerable.Range(1, TestsCount).ToList();

        [Test, TestCaseSource(nameof(TestCaseProvider))]
        public void Test(int testNumber)
        {
            using var readStream = new StreamReader($"{FilePath}\\{testNumber:00}");
            using var readExpectedStream = new StreamReader($"{FilePath}\\{testNumber:00}.a");
            using var text = new StringWriter();

            Console.SetIn(readStream);
            Console.SetOut(text);
            Program.Main();
            var expectedText = readExpectedStream.ReadToEnd().Trim();
            var expected = expectedText.Split('\n');
            var resultText = text.ToString().Trim();
            var result = resultText.Split('\n');

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Trim(), result[i].Trim(), $"Ожидается: \n{expectedText}\n Получен: \n{resultText}");
            }
        }
    }
}