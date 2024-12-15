namespace AtCoderCsharp.ABC.ABC138
{

    internal class abc138_d
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            List<int>[] tree = new List<int>[N + 1];
            for (int i = 0; i <= N; i++)
            {
                tree[i] = new List<int>();
            }

            int[] counters = new int[N + 1];

            for (int i = 1; i <= N - 1; i++)
            {
                int[] ab = ReadIntArray();
                tree[ab[0]].Add(ab[1]);
                tree[ab[1]].Add(ab[0]);
            }

            for (int i = 1; i <= Q; i++)
            {
                int[] px = ReadIntArray();
                counters[px[0]] += px[1];
            }

            bool[] visited = new bool[N + 1];

            Queue<(int,int)> queue = new Queue<(int,int)>();
            queue.Enqueue((1,0));

            int[] answer = new int[N + 1];

            while (0 < queue.Count)
            {
                (int node , int value) = queue.Dequeue();

                answer[node] = value + counters[node];
                visited[node] = true;

                foreach (int next in tree[node])
                {
                    if (visited[next])
                    {
                        continue;
                    }
                   
                    queue.Enqueue((next, answer[node]));
                }
            }

            for (int i = 1; i <= N; i++)
            {
                Console.Write(answer[i]);
                if (i < N)
                {
                    Console.Write(" ");
                }
            }




        }
    }
}
