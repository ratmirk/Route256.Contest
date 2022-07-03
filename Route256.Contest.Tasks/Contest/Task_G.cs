using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Contest.Tasks.Contest
{
    internal class Task_G
    {
        internal static void Main_Task()
        {
            var countList = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            var usersCount = countList.First();
            var pairsCount = countList.Last();
            var usersFriends = Enumerable.Range(1, usersCount).ToDictionary(x => x, f => new SortedSet<int>());

            for (int i = 0; i < pairsCount; i++)
            {
                var usersPair = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                var firstUser = usersPair.First();
                var secondUser = usersPair.Last();

                usersFriends[firstUser].Add(secondUser);
                usersFriends[secondUser].Add(firstUser);
            }

            var possibleFiends = new Dictionary<int, SortedSet<int>>();

            foreach (var user in usersFriends)
            {
                var key = user.Key;
                var friends = user.Value;
                possibleFiends.Add(key, new SortedSet<int>());

                var finalCount = 0;
                foreach (var friend in friends)
                {
                    var possibleFrToAdd = usersFriends[friend].Where(x => x != user.Key && !friends.Contains(x)).ToList();

                    for (int i = 0; i < possibleFrToAdd.Count; i++)
                    {
                        var count = friends.Intersect(usersFriends[possibleFrToAdd[i]]).Count();
                        if (count > finalCount)
                        {
                            finalCount = count;
                            possibleFiends[key].Clear();
                            possibleFiends[key].Add(possibleFrToAdd[i]);
                        }
                        else if (count == finalCount && count != 0)
                        {
                            possibleFiends[key].Add(possibleFrToAdd[i]);
                        }
                    }
                }
            }

            foreach (var userPossible in possibleFiends)
            {
                if (userPossible.Value.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", userPossible.Value));
                }
            }
        }
    }
}
