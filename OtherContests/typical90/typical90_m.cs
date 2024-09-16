namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_m
    {
        // 013 - Passing（★5） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = new int[M + 1];
            int[] B = new int[M + 1];
            int[] C = new int[M + 1];

            List<(int, int)>[] G = new List<(int, int)>[N + 1];
            for (int i = 0; i < N+1; i++)
            {
                G[i] = new List<(int, int)>();
            }

            for (int i = 1; i <= M; i++)
            {
                int[] abc = ReadIntArray();
                A[i] = abc[0];
                B[i] = abc[1];
                C[i] = abc[2];

                G[A[i]].Add((B[i], C[i]));
                G[B[i]].Add((A[i], C[i]));
            }

            bool[] visited = new bool[N + 1];
            int[] dp = new int[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                dp[i] = 2_000_000_000;
            }

            PriorityQueue<(int, int), int> priorityQueue = new PriorityQueue<(int, int), int>();
            priorityQueue.Enqueue((1, 0), 0);

            while (0 < priorityQueue.Count)
            {
                (int index , int distance) = priorityQueue.Dequeue();
                visited[index] = true;
                dp[index] = Math.Min(dp[index], distance);

                foreach ((int nextIndex,int cost) in G[index])
                {
                    if (visited[nextIndex])
                    {
                        continue;
                    }

                    if (distance + cost < dp[nextIndex])
                    {
                        priorityQueue.Enqueue((nextIndex, distance + cost), distance + cost);
                    }
                }
            }

            bool[] visitedRev = new bool[N + 1];
            int[] dpRev = new int[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                dpRev[i] = 2_000_000_000;
            }

            PriorityQueue<(int, int), int> priorityQueueRev = new PriorityQueue<(int, int), int>();
            priorityQueueRev.Enqueue((N, 0), 0);

            while (0 < priorityQueueRev.Count)
            {
                (int index, int distance) = priorityQueueRev.Dequeue();
                visitedRev[index] = true;
                dpRev[index] = Math.Min(dpRev[index], distance);

                foreach ((int nextIndex, int cost) in G[index])
                {
                    if (visitedRev[nextIndex])
                    {
                        continue;
                    }

                    if (distance + cost < dpRev[nextIndex])
                    {
                        priorityQueueRev.Enqueue((nextIndex, distance + cost), distance + cost);
                    }
                }
            }

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(dp[i] + dpRev[i]);
            }

        }
    }
}
