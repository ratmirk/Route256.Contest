using System;
using System.Linq;
using static System.Char;

namespace Route256.Contest.Tasks.Contest;

public class Task_D
{
    public static readonly char[] Vowels = "euioay".ToCharArray();

    internal static void Main_Task()
    {
        var count = int.Parse(Console.ReadLine());

        for (var i = 0; i < count; i++)
        {
            var loginString = Console.ReadLine();
            var login = new Login(loginString);


            if (login.IsValid)
            {
                Console.WriteLine(loginString);
                continue;
            }

            if (login.NumCount == 0)
            {
                loginString += "2";
                login.NumCount++;
            }

            if (login.LowerCount == 0 && login.VowelCount == 0)
            {
                loginString += "a";
                login.LowerCount++;
                login.VowelCount++;
            }

            if (login.LowerCount == 0 && login.ConsonantCount == 0)
            {
                loginString += "d";
                login.LowerCount++;
                login.ConsonantCount++;
            }

            if (login.UpperCount == 0 && login.VowelCount == 0)
            {
                loginString += "A";
                login.UpperCount++;
                login.VowelCount++;
            }

            if (login.UpperCount == 0 && login.ConsonantCount == 0)
            {
                loginString += "D";
                login.UpperCount++;
                login.ConsonantCount++;
            }

            if (login.UpperCount == 0)
            {
                loginString += "D";
                login.UpperCount++;
            }

            if (login.LowerCount == 0)
            {
                login.LowerCount++;
                loginString += "l";
            }

            if (login.ConsonantCount == 0)
            {
                loginString += "D";
                login.ConsonantCount++;
            }

            if (login.VowelCount == 0)
            {
                loginString += "i";
                login.VowelCount++;
            }

            Console.WriteLine(loginString);
        }
    }
}

public class Login
{
    public Login(string loginString)
    {
        foreach (var ch in loginString)
        {
            if (IsDigit(ch))
            {
                NumCount++;
            }
            else
            {
                _ = Task_D.Vowels.Contains(ToLower(ch)) ? VowelCount++ : ConsonantCount++;

                _ = IsUpper(ch) ? UpperCount++ : LowerCount++;

                if (IsValid) break;
            }
        }
    }

    public int NumCount { get; set; }
    public int VowelCount { get; set; }
    public int ConsonantCount { get; set; }
    public int LowerCount { get; set; }
    public int UpperCount { get; set; }

    public bool IsValid => NumCount > 0 && VowelCount > 0 && ConsonantCount > 0 && LowerCount > 0 && UpperCount > 0;
}