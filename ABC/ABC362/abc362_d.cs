namespace AtCoderCsharp.ABC.ABC362
{
    internal class abc362_d
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            long[] A = new long[N+1];
            Array.Copy(ReadLongArray(), 0, A, 1, N);

            List<(int, long)>[] UV = new List<(int, long)>[N + 1];
            for (int i = 0; i < N+1; i++)
            {
                UV[i] = new List<(int, long)>();
            }

            for (int i = 0; i < M; i++)
            {
                int[] UVB = ReadIntArray();
                UV[UVB[0]].Add((UVB[1], UVB[2]));
                UV[UVB[1]].Add((UVB[0], UVB[2]));
            }

            bool[] fix = new bool[N+1];
            long[] distance = new long[N+1];
            for (int i = 0; i <= N; i++)
            {
                distance[i] = long.MaxValue;
            }

            PriorityQueue<int,long> priorityQueue = new PriorityQueue<int,long>();

            distance[1] = A[1];
            priorityQueue.Enqueue(1, distance[1]);

            while (0 < priorityQueue.Count)
            {
                int current = priorityQueue.Dequeue();

                if (fix[current])
                {
                    continue;
                }

                fix[current] = true;

                for (int i = 0; i < UV[current].Count; i++)
                {
                    int next = UV[current][i].Item1;
                    long cost = UV[current][i].Item2 + A[next];

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
