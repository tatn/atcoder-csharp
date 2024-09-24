namespace AtCoderCsharp.OtherContests.typical90
{
    // 068 - Paired Information（★5） 

    internal class typical90_bp
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int Q = ReadInt();

            int[] T = new int[Q + 1];
            int[] X = new int[Q + 1];
            int[] Y = new int[Q + 1];
            int[] V = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                int[] TXYV = ReadIntArray();
                T[i] = TXYV[0];
                X[i] = TXYV[1];
                Y[i] = TXYV[2];
                V[i] = TXYV[3];                
            }

            UnionFindTree unionFindTree = new UnionFindTree(N);
            SegmentTree segmentTree = new SegmentTree(N);
            for (int i = 1; i <= Q; i++)
            {
                switch (T[i])
                {
                    case 0:
                        segmentTree.Update(X[i], V[i]);
                        unionFindTree.Merge(X[i], Y[i]);
                        break;
                    case 1:
                        int left = X[i] <= Y[i] ? X[i] : Y[i];
                        int right = X[i] <= Y[i] ? Y[i] : X[i];

                        if(!unionFindTree.IsConnected(X[i] ,  Y[i]))
                        {
                            Console.WriteLine("Ambiguous");
                            continue;
                        }   

                        long sumValue = segmentTree.GetSumValue(left, right - 1);

                        long answer = 0L;

                        if(left % 2 == 0)
                        {
                            sumValue = -sumValue;

                            if (X[i] <= Y[i])
                            {
                                if (right % 2 == 0)
                                {
                                    answer = -sumValue + V[i];
                                }
                                else
                                {
                                    answer = sumValue - V[i];
                                }
                            }
                            else
                            {
                                if (right % 2 == 0)
                                {
                                    answer = sumValue + V[i];
                                }
                                else
                                {
                                    answer = sumValue - V[i];
                                }
                            }

                        }
                        else
                        {
                            if (X[i] <= Y[i])
                            {
                                if (right % 2 == 0)
                                {
                                    answer = sumValue - V[i];
                                }
                                else
                                {
                                    answer = -sumValue + V[i];
                                }
                            }
                            else
                            {
                                if (right % 2 == 0)
                                {
                                    answer = sumValue - V[i];
                                }
                                else
                                {
                                    answer = sumValue + V[i];
                                }
                            }
                        }

                        Console.WriteLine(answer);
                        break;
                    default:
                        break;
                }
            }

        }


        // RSQ(Range Sum Query)
        public class SegmentTree
        {
            private int treeHeight = 1;
            private int leafSize = 1;
            private long[] nodes = new long[1];

            public SegmentTree(int needNodeCount)
            {
                while (leafSize < needNodeCount)
                {
                    this.leafSize *= 2;
                    this.treeHeight++;
                }

                this.nodes = new long[1 << treeHeight];
                for (int i = 0; i < this.nodes.Length; i++)
                {
                    this.nodes[i] = 0;
                }
            }

            public void Update(int position, long value)
            {
                int nodeIndex = this.GetNodeIndex(position);

                this.UpdateByNodeIndex(nodeIndex, position % 2 == 0 ? -value : value);
            }

            public long GetSumValue(int positionLeft, int positionRight)
            {
                long sumValue = this.GetSumValueByNodeIndex(positionLeft, positionRight, 1, 1);
                return sumValue;
            }

            private void UpdateByNodeIndex(int nodeIndex, long value)
            {
                this.nodes[nodeIndex] = value;

                if (1 < nodeIndex)
                {
                    int nextNodeIndex = nodeIndex / 2;
                    long nexeValue = this.nodes[nextNodeIndex * 2] + this.nodes[nextNodeIndex * 2 + 1];
                    this.UpdateByNodeIndex(nextNodeIndex, nexeValue);
                }

            }

            private long GetSumValueByNodeIndex(int positionLeft, int positionRight, int targetNodeIndex, int depth)
            {
                (int left, int right) = this.GetPositionRange(targetNodeIndex, depth);

                if (positionLeft <= left && right <= positionRight)
                {
                    return nodes[targetNodeIndex];
                }

                if (right < positionLeft || positionRight < left)
                {
                    return 0;
                }

                long leftSumValue = GetSumValueByNodeIndex(positionLeft, positionRight, targetNodeIndex * 2, depth + 1);
                long rightSumValue = GetSumValueByNodeIndex(positionLeft, positionRight, targetNodeIndex * 2 + 1, depth + 1);

                long sumValue = leftSumValue + rightSumValue;

                return sumValue;
            }

            private int GetNodeIndex(int position)
            {
                return position + leafSize - 1;
            }

            private (int, int) GetPositionRange(int targetNodeIndex, int depth)
            {
                int deptDiff = treeHeight - depth;

                int left = targetNodeIndex * (1 << deptDiff) - leafSize + 1;
                int right = left + (1 << deptDiff) - 1;

                return (left, right);
            }


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

            public void Merge(int x,int y)
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


            public bool IsConnected(int x,int y)
            {
                int rootX = this.GetRoot(x);
                int rootY = this.GetRoot(y);
                return rootX == rootY;
            }

        }
    }
}
