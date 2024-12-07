using System.Collections.Generic;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC383
{
    internal class abc383_c
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] hwd = ReadIntArray();
            int H = hwd[0];
            int W = hwd[1];
            int D = hwd[2];

            string[,] S = new string[H + 2, W + 2];
            for (int i = 1; i <= H; i++)
            {
                string strin = ReadString();
                for (int j = 1; j <= W; j++)
                {
                    S[i, j] = strin[j - 1].ToString();
                }
            }

            for (int i = 0; i <= H+1; i++)
            {
                S[i, 0] = "#";
                S[i, W + 1] = "#";
            }
            for (int j = 0; j <= W+1; j++)
            {
                S[0, j] = "#";
                S[H+1, j] = "#";
            }

            PriorityQueue<(int, int,int),int> priorityQueue = new PriorityQueue<(int,int, int),int>();

            int[,] distance = new int[H + 2, W + 2];
            for (int i = 0; i <= H+1; i++)
            {
                for (int j = 0; j <= W+1; j++)
                {
                    distance[i,j] = int.MaxValue;
                }
            }


            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    if (S[i, j] != "H")
                    {
                        continue;
                    }

                    priorityQueue.Enqueue((i, j, 0), 0);
                }
            }

            while (0 < priorityQueue.Count)
            {
                (int i, int j, int d) = priorityQueue.Dequeue();

                if (D < d)
                {
                    continue;
                }

                if (distance[i, j] <= d)
                {
                    continue;
                }

                if (S[i, j] == "#")
                {
                    continue;
                }

                distance[i, j] = d;

                priorityQueue.Enqueue((i + 1, j, d + 1), d + 1);
                priorityQueue.Enqueue((i - 1, j, d + 1), d + 1);
                priorityQueue.Enqueue((i, j + 1, d + 1), d + 1);
                priorityQueue.Enqueue((i, j - 1, d + 1), d + 1);
            }

            int count = 0;
            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    if(distance[i, j] <= D)
                    {
                        count++;
                    }

                }
            }
            Console.WriteLine(count);
        }
    }
}
