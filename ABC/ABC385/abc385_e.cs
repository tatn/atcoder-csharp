using System.Collections.Generic;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC385
{
    internal class abc385_e
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] u = new int[N];
            int[] v = new int[N];

            int[] degree = new int[N+1];
            List<int>[] G = new List<int>[N+1];
            for (int i = 0; i <= N; i++)
            {
                G[i] = new List<int>();
            }

            for (int i = 1; i <= N-1; i++)
            {
                int[] uv = ReadIntArray();
                u[i] = uv[0];
                v[i] = uv[1];

                degree[u[i]]++;
                degree[v[i]]++;

                G[u[i]].Add(v[i]);
                G[v[i]].Add(u[i]);
            }

            Comparison<int> comparison = (x, y) =>
            {
                return -1 * degree[x].CompareTo(degree[y]);
            };

            for (int i = 0; i <= N; i++)
            {
                G[i].Sort(Comparer<int>.Create(comparison));
            }

            int maxDegree = 0;

            for (int centerIndex = 1;centerIndex <= N; centerIndex++)
            {
                int xDegreeMax = degree[centerIndex];

                for (int xDegree = 1; xDegree <= xDegreeMax; xDegree++)
                {
                    int yIndex = G[centerIndex][xDegree - 1];
                    int yDegreeMax = degree[yIndex] - 1;
                    int degreeCount = yDegreeMax * xDegree + xDegree + 1;
                    maxDegree = Math.Max(maxDegree, degreeCount);
                }
            }

            Console.WriteLine(N - maxDegree);

        }
    }
}
