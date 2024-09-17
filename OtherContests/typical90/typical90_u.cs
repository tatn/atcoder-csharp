namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_u
    {
        // 021 - Come Back in One Piece（★5） ToDo
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            List<int>[] G = new List<int>[N+1];
            for (int i = 0; i < N+1; i++)
            {
                G[i] = new List<int>();
            }

            for (int i = 1; i <= M; i++)
            {
                int[] AB = ReadIntArray();
                G[AB[0]].Add(AB[1]);
            }

            for (int i = 1; i <= N; i++)
            {
                G[i].Sort();
            }

            for (int i = 1; i <= N; i++)
            {
                UnionFindTree tree = UnionFindTree.Create(i);
                foreach (int j in G[i])
                {
                    if(j <= i)
                    {
                        continue;
                    }

                    int foundIndex = G[j].BinarySearch(i);

                    if(0 <= foundIndex)
                    {
                        UnionFindTree treeConnect = UnionFindTree.Create(j);
                        tree.Merge(treeConnect);
                    }
                }
            }

            long answer = 0L;
            for (int i = 1; i <= N; i++)
            {
                UnionFindTree tree = UnionFindTree.Get(i);

                if(tree.Size == 1)
                {
                    continue;
                }

                if(tree.GetRoot() != tree.NodeIndex)
                {
                    continue;
                }

                answer += (long)tree.Size * ((long)tree.Size - 1L) / 2L;
            }


            Console.WriteLine(answer);
        }


        private class UnionFindTree
        {
            const int NODE_COUNT = 100000;

            private static UnionFindTree[] Trees = new UnionFindTree[NODE_COUNT + 1];

            private int parent = -1;
            private int size = 1;

            public int Size { get { return this.size; } }
            public int NodeIndex { get; }


            private UnionFindTree(int nodeIndex)
            {
                this.NodeIndex = nodeIndex;
            }

            public static UnionFindTree Create(int nodeIndex)
            {
                UnionFindTree tree = UnionFindTree.Get(nodeIndex);
                if (tree == null)
                {
                    tree = new UnionFindTree(nodeIndex);
                    Trees[nodeIndex] = tree;
                }

                return tree;
            }

            public static UnionFindTree Get(int nodeIndex)
            {
                return Trees[nodeIndex];
            }

            public int GetRoot()
            {
                if (this.parent == -1)
                {
                    return this.NodeIndex;
                }

                return Trees[this.parent].GetRoot();
            }

            public void Merge(UnionFindTree tree)
            {
                int root = this.GetRoot();
                int treeRoot = tree.GetRoot();

                if (root == treeRoot)
                {
                    return;
                }

                if (Trees[root].size < Trees[treeRoot].size)
                {
                    Trees[root].parent = treeRoot;
                    Trees[treeRoot].size += Trees[root].size;
                }
                else
                {
                    Trees[treeRoot].parent = root;
                    Trees[root].size += Trees[treeRoot].size;
                }
            }

            public void Merge(List<UnionFindTree> trees)
            {
                if (trees == null)
                {
                    return;
                }

                foreach (UnionFindTree tree in trees)
                {
                    if (tree == null)
                    {
                        continue;
                    }

                    this.Merge(tree);
                }
            }

            public bool IsConnected(UnionFindTree tree)
            {
                int root = this.GetRoot();
                int treeRoot = tree.GetRoot();
                return root == treeRoot;
            }

        }
    }
}
