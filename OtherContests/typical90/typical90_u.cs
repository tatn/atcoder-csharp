namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_u
    {
        // 021 - Come Back in One Piece（★5） 

        // 強連結成分分解
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            List<int>[] G = new List<int>[N + 1];
            List<int>[] H = new List<int>[N + 1];
            for (int i = 0; i < N+1; i++)
            {
                G[i] = new List<int>();
                H[i] = new List<int>();
            }

            for (int i = 1; i <= M; i++)
            {
                int[] AB = ReadIntArray();
                G[AB[0]].Add(AB[1]);
                H[AB[1]].Add(AB[0]);
            }

            List<int> order = new List<int>();
            bool[] visited = new bool[N+1];

            for (int i = 1; i <= N; i++)
            {
                if (!visited[i])
                {
                    DFS(i);
                }

            }

            order.Reverse();

            bool[] visitedBack = new bool[N + 1];
            List<List<int>> conected = new List<List<int>>();

            long answer = 0;

            foreach (int node in order)
            {
                if (!visitedBack[node])
                {
                    List<int> list = new List<int>();
                    DFSBack(node, list);
                    conected.Add(list);

                    answer += (long)list.Count * ((long)list.Count - 1L) / 2L;
                }
            }

            Console.WriteLine(answer);

            void DFS(int node)
            {
                visited[node] = true;

                foreach (int next in G[node])
                {
                    if (!visited[next])
                    {
                        DFS(next);
                    }
                }

                order.Add(node);
            }

            void DFSBack(int node, List<int> list)
            {
                visitedBack[node] = true;
                list.Add(node);

                foreach (int next in H[node])
                {
                    if (!visitedBack[next])
                    {
                        DFSBack(next, list);
                    }
                }
            }

        }
    }
}
