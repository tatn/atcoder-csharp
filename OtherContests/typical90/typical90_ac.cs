using System.Reflection.Metadata.Ecma335;

namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ac
    {
        // 029 - Long Bricks（★5） ToDo
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

            int leafSize = 1;
            int treeHeight = 1;

            while (leafSize < W)
            {
                leafSize *= 2;
                treeHeight++;
            }

            int[] tree = new int[1 << treeHeight];
            int[] depthMemo = new int[1 << treeHeight];

            for (int i = 1; i <= N; i++)
            {
                int left = L[i];
                int right = R[i];

                int maxHeight = GetMaximumHeight(left, right, 1);
                Console.WriteLine(maxHeight + 1);

                UpdateHeight(left, right, maxHeight + 1 , 1);

            }

            void UpdateHeight(int left,int right, int height , int targetNodeIndex)
            {
                (int leftPosition, int rightPosition) = GetLeafPositionRange(targetNodeIndex);
                if (right < leftPosition || rightPosition < left)
                {
                    return;
                }

                tree[targetNodeIndex] = Math.Max(height, tree[targetNodeIndex]);

                int depth = GetDepth(targetNodeIndex);
                if(treeHeight <= depth)
                {
                    return;
                }

                UpdateHeight(left, right, height, targetNodeIndex * 2);
                UpdateHeight(left, right, height, targetNodeIndex * 2 + 1);
            }



            int GetMaximumHeight(int left, int right, int targetNodeIndex)
            {
                (int leftPosition, int rightPosition) = GetLeafPositionRange(targetNodeIndex);

                if (right < leftPosition || rightPosition < left)
                {
                    return 0;
                }

                if (left <= leftPosition && rightPosition <= right)
                {
                    return tree[targetNodeIndex];
                }

                int leftHeight = GetMaximumHeight(left, right, targetNodeIndex * 2);
                int rightHeight = GetMaximumHeight(left, right, targetNodeIndex * 2 + 1);

                return Math.Max(leftHeight, rightHeight);

            }

            (int,int) GetLeafPositionRange(int targetNodeIndex)
            {
                int depth = GetDepth(targetNodeIndex);
                int depthDiff = treeHeight - depth;

                int left = targetNodeIndex * (1 << depthDiff) - leafSize + 1;
                int right = left + (1 << depthDiff) - 1;

                return (left, right);
            }

            int GetDepth(int targetNodeIndex)
            {
                if (depthMemo[targetNodeIndex] == 0)
                {
                    int depth = 1;

                    while ( (1 << depth) <= targetNodeIndex )
                    {
                        depth++;
                    }

                    depthMemo[targetNodeIndex] = depth;
                }

                return depthMemo[targetNodeIndex];
            }

        }
    }
}
