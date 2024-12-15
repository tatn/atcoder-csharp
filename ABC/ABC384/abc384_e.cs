using System.Collections.Generic;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC384
{
    internal class abc384_e
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int[] HWX = ReadIntArray();
            int H = HWX[0];
            int W = HWX[1];
            int X = HWX[2];

            int[] PQ = ReadIntArray();
            int P = PQ[0];
            int Q = PQ[1];

            long[,] S = new long[H + 2, W + 2];
            for (int i = 0; i <= H+1; i++)
            {
                S[i, 0] = long.MaxValue;
                S[i, W + 1] = long.MaxValue;
            }
            for (int i = 0; i <= W + 1; i++)
            {
                S[0, i] = long.MaxValue;
                S[H + 1 , i] = long.MaxValue;
            }

            for (int i = 1; i <=H; i++)
            {
                long[] input = ReadLongArray();
                for (int j = 1; j <= W; j++)
                {
                    S[i, j] = input[j - 1];
                }
            }

            PriorityQueue<(long, int, int), long> priorityQueue = new PriorityQueue<(long, int, int), long>();

            List<(int, int)> moveList = new List<(int, int)>();
            moveList.Add((1, 0));
            moveList.Add((-1, 0));
            moveList.Add((0, 1));
            moveList.Add((0, -1));

            bool[,] visited = new bool[H + 2, W + 2];
            visited[P, Q] = true;
            priorityQueue.Enqueue((0, P, Q), 0);

            long power = S[P, Q];

            while (0 < priorityQueue.Count)
            {
                (long p, int row, int col) = priorityQueue.Dequeue();

                if((power+(long)X - 1 ) / (long)X <= p )
                {
                    break;
                }

                power += p;

                foreach ((int i, int j) in moveList)
                {
                    if(visited[row + i, col + j])
                    {
                        continue;
                    }

                    priorityQueue.Enqueue((S[row + i, col + j], row + i, col + j), S[row + i, col + j]);
                    visited[row + i, col + j] = true;
                }
            }

            Console.WriteLine(power);
        }
    }
}
