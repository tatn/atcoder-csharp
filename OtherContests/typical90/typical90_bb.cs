namespace AtCoderCsharp.OtherContests.typical90
{
    // 054 - Takahashi Number（★6） 

    internal class typical90_bb
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            List<int>[] G = new List<int>[N + M + 1];
            for (int i = 0; i <= N + M; i++)
            {
                G[i] = new List<int>();
            }

            for (int i = 1; i <= M; i++)
            {
                int Ki = ReadInt();
                int[] input = ReadIntArray();

                for (int j = 1; j <= Ki; j++)
                {
                    int index = input[j - 1];
                    G[i + N].Add(index);
                    G[index].Add(i + N);
                }
            }

            bool[] visited = new bool[N + M + 1];
            int[] dist = new int[N + M + 1];
            for (int i = 0; i <= N + M; i++)
            {
                dist[i] = int.MaxValue;
            }

            dist[1] = 0;

            Queue<int> priorityQueue = new Queue<int>();
            priorityQueue.Enqueue(1);

            while (0 < priorityQueue.Count)
            {
                int index = priorityQueue.Dequeue();
                visited[index] = true;

                foreach (int next in G[index])
                {
                    if (visited[next])
                    {
                        continue;
                    }

                    int distance = dist[index] + 1;

                    if (distance < dist[next])
                    {
                        dist[next] = distance;
                        priorityQueue.Enqueue(next);
                    }
                }   
            }

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(dist[i] == int.MaxValue ? -1 : dist[i]/2);
            }
        }
    }
}
