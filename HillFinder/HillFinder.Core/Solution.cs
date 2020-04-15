using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillFinder.Core
{
    public class Solution
    {

        public Solution() { }

        public int GetSolution(int[] a)
        {
            int cannon = 0;
            if (a != null && a.Length > 0)
            {
                var hills = GetHills(a);
                cannon = 1;
                if (hills.Length > 1)
                {
                    int bestCaseOcurrence = (int)Math.Round(Math.Sqrt(a.Length), MidpointRounding.AwayFromZero);
                    int optimalValue = bestCaseOcurrence <= hills.Length ? bestCaseOcurrence : hills.Length;

                    while (cannon != optimalValue)
                    {
                        for (int i = 0; i < hills.Length; i++)
                        {
                            for (int x = (i + 1); x < hills.Length; x++)
                            {
                                if ((hills[x] - hills[i]) >= optimalValue)
                                {
                                    cannon++;
                                    i = (x-1);
                                    break;
                                }
                            }
                        }

                        if (cannon != optimalValue)
                        {
                            optimalValue--;
                            cannon = 1;
                        }
                    }

                }
            }

            return cannon;
        }


        private long[] GetHills(int[] mountains)
        {
            ConcurrentBag<long> hills = new ConcurrentBag<long>();
            if (mountains != null && mountains.Length > 0)
            {
                Parallel.ForEach(mountains, (line, state, index) =>
                {
                    if (index == 0)
                    {
                        if (mountains[index] > mountains[index + 1])
                            hills.Add(index);
                    }
                    else if (index == (mountains.Length - 1))
                    {
                        if (mountains[index - 1] < mountains[index])
                            hills.Add(index);
                    }
                    else if ((mountains[index - 1] < mountains[index]) && (mountains[index] > mountains[index + 1]))
                        hills.Add(index);
                });
            }
            return hills.OrderBy(x => x).ToArray();
        }

    }
}
