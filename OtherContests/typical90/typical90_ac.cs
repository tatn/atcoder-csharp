namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ac
    {
        // 029 - Long Bricks（★5） 
        // Adjusted Lazy Segment Tree
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] WN = ReadIntArray();
            int W = WN[0];
            int N = WN[1];

            int[] L = new int[N + 1];
            int[] R = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] LR = ReadIntArray();
                L[i] = LR[0];
                R[i] = LR[1];
            }

            int size = 1;
            while (size < W)
            {
                size <<= 1;
            }

            int[] tree = new int[size * 2];
            int?[] lazyTree = new int?[size * 2];

            for (int i = 1; i <= N; i++)
            {
                int left = L[i];
                int right = R[i];

                int maxHeight = GetMaximumHeight(left, right, 1, 1, size);
                Console.WriteLine(maxHeight + 1);

                UpdateHeight(left, right, maxHeight + 1, 1, 1, size);
            }

            void Push(int nodeIndex, int nodeLeft, int nodeRight)
            {
                if (lazyTree[nodeIndex].HasValue)
                {
                    tree[nodeIndex] = lazyTree[nodeIndex]!.Value;
                    if (nodeLeft != nodeRight)
                    {
                        lazyTree[nodeIndex * 2] = lazyTree[nodeIndex]!.Value;
                        lazyTree[nodeIndex * 2 + 1] = lazyTree[nodeIndex]!.Value;
                    }
                    lazyTree[nodeIndex] = null;
                }
            }

            int GetMaximumHeight(int queryLeft, int queryRight, int nodeIndex, int nodeLeft, int nodeRight)
            {
                Push(nodeIndex, nodeLeft, nodeRight);
                if (queryRight < nodeLeft || nodeRight < queryLeft)
                {
                    return 0;
                }

                if (queryLeft <= nodeLeft && nodeRight <= queryRight)
                {
                    return tree[nodeIndex];
                }

                int mid = (nodeLeft + nodeRight) / 2;
                int leftMax = GetMaximumHeight(queryLeft, queryRight, nodeIndex * 2, nodeLeft, mid);
                int rightMax = GetMaximumHeight(queryLeft, queryRight, nodeIndex * 2 + 1, mid + 1, nodeRight);
                return Math.Max(leftMax, rightMax);
            }

            void UpdateHeight(int queryLeft, int queryRight, int height, int nodeIndex, int nodeLeft, int nodeRight)
            {
                Push(nodeIndex, nodeLeft, nodeRight);
                if (queryRight < nodeLeft || nodeRight < queryLeft)
                {
                    return;
                }

                if (queryLeft <= nodeLeft && nodeRight <= queryRight)
                {
                    tree[nodeIndex] = height;
                    if (nodeLeft != nodeRight)
                    {
                        lazyTree[nodeIndex * 2] = height;
                        lazyTree[nodeIndex * 2 + 1] = height;
                    }
                    return;
                }

                int mid = (nodeLeft + nodeRight) / 2;
                UpdateHeight(queryLeft, queryRight, height, nodeIndex * 2, nodeLeft, mid);
                UpdateHeight(queryLeft, queryRight, height, nodeIndex * 2 + 1, mid + 1, nodeRight);
                tree[nodeIndex] = Math.Max(tree[nodeIndex * 2], tree[nodeIndex * 2 + 1]);
            }
        }
    }
}