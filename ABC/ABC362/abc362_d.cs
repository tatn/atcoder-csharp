using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
namespace AtCoderCsharp.ABC.ABC362
{
    internal class abc362_d
    {
        //ToDo
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            long[] A = new long[N+1];
            long[] aInput = ReadLongArray();
            for (int i = 0; i < N; i++)
            {
                A[i + 1] = aInput[i];
            }

            List<int>[] UV = new List<int>[N+1];
            for (int i = 0; i <= N; i++)
            {
                UV[i] = new List<int> { };
            }

            long[,] B = new long[N+1, N + 1];
            for (int i = 0; i < M; i++)
            {
                int[] UVB = ReadIntArray();
                UV[UVB[0]].Add(UVB[1]);
                UV[UVB[1]].Add(UVB[0]);
                B[UVB[0], UVB[1]] = UVB[2];
                B[UVB[1], UVB[0]] = UVB[2];
            }

            bool[] fix = new bool[N+1];
            long[] distance = new long[N+1];
            for (int i = 0; i <= N; i++)
            {
                distance[i] = 1_000_000_000L * 2L * 100_000L * 2L * 2L;
            }

            PriorityQueue<int,long> priorityQueue = new PriorityQueue<int,long>();

            distance[1] = A[1];
            priorityQueue.Enqueue(1, distance[1]);

            List<int> path = new List<int>();
            while (0 < priorityQueue.Count)
            {
                int current = priorityQueue.Dequeue();
                path.Add(current);

                if (fix[current])
                {
                    continue;
                }

                fix[current] = true;

                for (int i = 0; i < UV[current].Count; i++)
                {
                    int next = UV[current][i];
                    long cost = B[current, next] + A[next];

                    if(distance[current] + cost < distance[next])
                    {
                        distance[next] = distance[current] + cost;
                        priorityQueue.Enqueue(next,distance[next]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", distance.Skip(2)));
        }
    }
}
