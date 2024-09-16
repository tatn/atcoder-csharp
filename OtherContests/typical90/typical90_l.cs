namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_l
    {
        // 012 - Red Painting（★4） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            int Q = ReadInt();

            List<int>[] q = new List<int>[Q+1];
            for (int i = 1; i <= Q; i++)
            {
                q[i] = ReadIntArray().ToList();
            }

            for (int i = 1; i <= Q; i++)
            {
                List<int> query = q[i];
                switch (query[0])
                {
                    case 1:
                        int r = query[1];
                        int c = query[2];
                        UnionFindTree tree = UnionFindTree.Create(r, c);
                        List<UnionFindTree> neighbors = tree.FindNeighbors();
                        tree.Merge(neighbors);
                        break;
                    case 2:
                        int ra = query[1];
                        int ca = query[2];
                        int rb = query[3];
                        int cb = query[4];

                        UnionFindTree? aTree = UnionFindTree.Get(ra, ca);
                        UnionFindTree? bTree = UnionFindTree.Get(rb, cb);

                        if (aTree == null || bTree == null)
                        {
                            Console.WriteLine("No");
                        }
                        else
                        {
                            Console.WriteLine(aTree.IsConnected(bTree) ? "Yes" : "No");
                        }
                        break;
                }                
            }
        }

        private class UnionFindTree
        {
            const int ROW_COL_RANGE = 10000;

            private static UnionFindTree[] AllGrid = new UnionFindTree[20_002_001];

            private int row = 0;
            private int col = 0;

            private int parent = -1;
            private int nodeIndex = -1;
            private int size = 1;


            private UnionFindTree(int row, int col)
            {
                this.row = row;
                this.col = col;
                this.nodeIndex = GetNodeIndex(row, col);
            }

            public static UnionFindTree Create(int row, int col)
            {
                int index = GetNodeIndex(row, col);
                if (AllGrid[index] != null)
                {
                    return AllGrid[index];
                }

                UnionFindTree tree = new UnionFindTree(row, col);
                AllGrid[index] = tree;
                return tree;
            }

            public static UnionFindTree? Get(int row, int col)
            {
                if(row < 0 || 2000 < row)
                {
                    return null;
                }

                if (col < 0 || 2000 < col)
                {
                    return null;
                }

                int index = GetNodeIndex(row, col);
                return AllGrid[index];
            }

            public int GetRoot()
            {
                if(this.parent == -1)
                {
                    return this.nodeIndex;
                }

                return AllGrid[this.parent].GetRoot();
            }

            public void Merge(UnionFindTree tree)
            {
                int root = this.GetRoot();
                int treeRoot = tree.GetRoot();

                if(root == treeRoot)
                {
                    return;
                }

                if(AllGrid[root].size < AllGrid[treeRoot].size)
                {
                    AllGrid[root].parent = treeRoot;
                    AllGrid[treeRoot].size += AllGrid[root].size;
                }
                else
                {
                    AllGrid[treeRoot].parent = root;
                    AllGrid[root].size += AllGrid[treeRoot].size;
                }
            }

            public void Merge(List<UnionFindTree> trees)
            {
                if(trees == null)
                {
                    return;
                }

                foreach (UnionFindTree tree in trees)
                {
                    if(tree == null)
                    {
                        continue;
                    }

                    this.Merge(tree);
                }
            }

            public List<UnionFindTree> FindNeighbors()
            {
                List<UnionFindTree> neighbors = new List<UnionFindTree>();

                UnionFindTree? up = UnionFindTree.Get(row - 1, col);
                UnionFindTree? down = UnionFindTree.Get(row + 1, col);
                UnionFindTree? left = UnionFindTree.Get(row, col - 1);
                UnionFindTree? right = UnionFindTree.Get(row, col + 1);

                if(up != null)
                {
                    neighbors.Add(up);
                }
                if(down != null)
                {
                    neighbors.Add(down);
                }
                if(left != null)
                {
                    neighbors.Add(left);
                }
                if(right != null)
                {
                    neighbors.Add(right);
                }

                return neighbors;
            }

            public bool IsConnected(UnionFindTree tree)
            {
                int root = this.GetRoot();
                int treeRoot = tree.GetRoot();
                return root == treeRoot;
            }

            private static int GetNodeIndex(int row, int col)
            {
                int index = row * ROW_COL_RANGE + col;
                return index;
            }

        }
    }
}
