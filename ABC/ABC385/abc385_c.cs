using System.Collections.Generic;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC385
{
    internal class abc385_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            List<int> H = ReadIntArray().ToList();
            H.Insert(0, 0);

            List<int>[] countBuildings = new List<int>[3000 + 1];
            for (int i = 0; i <= 3000; i++)
            {
                countBuildings[i] = new List<int>();
            }

            for (int i = 1; i <= N; i++)
            {
                countBuildings[H[i]].Add(i);
            }

            // count[i, j] = i番目の建物について。間隔jであるときの建物の数。
            int[,] count = new int[3000 + 1, 3000 + 1];

            for (int i = 1; i <= N ; i++)
            {
                for (int j = 0; j < i ; j++)
                {
                    if(j == 0)
                    {
                        count[i, j] = 1;
                    }
                    else if (H[i-j] == H[i])
                    {
                        if(count[i-j, j] == 0)
                        {
                            count[i, j] = 2;
                        }
                        else
                        {
                            count[i, j] = count[i - j, j] + 1;
                        }
                    }
                    else
                    {
                        count[i, j] = 0;
                    }
                }
            }

            int ans = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    ans = Math.Max(ans, count[i, j]);
                }
            }

            Console.WriteLine(ans);


        }
    }
}
