namespace AtCoderCsharp.ABC.ABC373
{
    // D - Hidden Weights
    internal class abc373_d
    {

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] u = new int[M + 1];
            int[] v = new int[M + 1];
            int[] w = new int[M + 1];

            List<(int, int)>[] G = new List<(int, int)>[N + 1];
            for (int i = 1; i <= N; i++)
            {
                G[i] = new List<(int, int)>();
            }

            for (int i = 1; i <= M; i++)
            {
                int[] uvw = ReadIntArray();
                u[i] = uvw[0];
                v[i] = uvw[1];
                w[i] = uvw[2];

                G[u[i]].Add((v[i], w[i]));
                G[v[i]].Add((u[i], -w[i]));
            }

            long[] values = new long[N + 1];
            bool[] visited = new bool[N + 1];

            for (int i = 1; i <= N; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                Stack<int> stack = new Stack<int>();
                stack.Push(i);

                while (stack.Any())
                {
                    int index = stack.Pop();

                    foreach ((int next, int weight) in G[index])
                    {
                        if (visited[next])
                        {
                            continue;
                        }

                        values[next] = values[index] + (long)weight;
                        visited[next] = true;

                        stack.Push(next);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", values.Skip(1)));
        }

        public static void Main1(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] u = new int[M + 1];
            int[] v = new int[M + 1];
            int[] w = new int[M + 1];

            List<(int, int)>[] G = new List<(int, int)>[N + 1];
            List<(int, int)>[] H = new List<(int, int)>[N + 1];
            for (int i = 1; i <= N; i++)
            {
                G[i] = new List<(int, int)>();
                H[i] = new List<(int, int)>();
            }

            UnionFindTree unionFindTree = new UnionFindTree(N);
            for (int i = 1; i <= M; i++)
            {
                int[] uvw = ReadIntArray();
                u[i] = uvw[0];
                v[i] = uvw[1];
                w[i] = uvw[2];

                G[u[i]].Add((v[i], w[i]));
                H[v[i]].Add((u[i], -w[i]));

                unionFindTree.Merge(u[i], v[i]);
            }


            List<int>[] sameRootIndexes = new List<int>[N + 1];
            for (int i = 1; i <= N; i++)
            {
                sameRootIndexes[i] = new List<int>();
            }

            for (int i = 1; i <= N; i++)
            {
                sameRootIndexes[unionFindTree.GetRoot(i)].Add(i);
            }

            long[] values = new long[N + 1];
            bool[] visited = new bool[N + 1];

            for (int i = 1; i <= N; i++)
            {
                List<int> indexes = sameRootIndexes[i];

                if(indexes.Count == 0)
                {
                    continue;
                }

                Stack<int> stack = new Stack<int>();
                values[indexes[0]] = 0;
                stack.Push(indexes[0]);

                while (0 < stack.Count)
                {
                    int index = stack.Pop();

                    foreach((int next1,int weight1) in G[index])
                    {
                        if (visited[next1])
                        {
                            continue;
                        }

                        values[next1] = values[index] + (long)weight1;
                        visited[next1] = true;
                        stack.Push(next1);
                    }

                    foreach ((int next2, int weight2) in H[index])
                    {
                        if (visited[next2])
                        {
                            continue;
                        }

                        values[next2] = values[index] + (long)weight2;
                        visited[next2] = true;
                        stack.Push(next2);
                    }

                }
            }

            Console.WriteLine(string.Join(" ", values.Skip(1)));
        }


        private class UnionFindTree
        {
            private int[] parent;
            private int[] size;

            public UnionFindTree(int size)
            {
                this.parent = new int[size + 1];
                this.size = new int[size + 1];

                for (int i = 0; i <= size; i++)
                {
                    this.parent[i] = i;
                    this.size[i] = 1;
                }
            }

            public int GetRoot(int nodeIndex)
            {
                if (this.parent[nodeIndex] == nodeIndex)
                {
                    return nodeIndex;
                }

                return this.GetRoot(this.parent[nodeIndex]);
            }

            public void Merge(int x, int y)
            {
                int rootX = this.GetRoot(x);
                int rootY = this.GetRoot(y);

                if (rootX == rootY)
                {
                    return;
                }

                if (this.size[rootX] < this.size[rootY])
                {
                    int temp = rootX;
                    rootX = rootY;
                    rootY = temp;
                }

                this.parent[rootY] = rootX;
                this.size[rootX] += this.size[rootY];

            }


            public bool IsConnected(int x, int y)
            {
                int rootX = this.GetRoot(x);
                int rootY = this.GetRoot(y);
                return rootX == rootY;
            }

        }
    }
}
