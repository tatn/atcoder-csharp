using System.Collections.Specialized;

namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ak
    {
        // 037 - Don't Leave the Spice（★5） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] WN = ReadIntArray();
            int W = WN[0];
            int N = WN[1];

            int[] L = new int[N + 1];
            int[] R = new int[N + 1];
            int[] V = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] LRV = ReadIntArray();
                L[i] = LRV[0];
                R[i] = LRV[1];
                V[i] = LRV[2];
            }

            // dp[i,j] := i番目までの料理で重さがjになるように選んだときの価値の最大値
            long[,] dp = new long[N + 1, W + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int w = 1; w <= W; w++)
                {
                    dp[i, w] = long.MinValue;
                }
            }

            List<SegmentTree> segmentTreeList = new List<SegmentTree>();
            segmentTreeList.Add(new SegmentTree(W));

            for (int i = 1;i <= N; i++)
            {
                SegmentTree segmentTree = new SegmentTree(W);

                for (int w = 1; w <= W; w++)
                {
                    // i番目の料理を選ばない場合
                    dp[i,w] = Math.Max(dp[i,w], dp[i - 1,w]);


                    // i-1番目までの料理で重さがw-R[i]～w-L[i]になるように選んだときの価値の最大値にV[i]を足す
                    dp[i, w] = Math.Max(dp[i, w], segmentTreeList[i-1].GetMaximumValue(w - R[i], w - L[i]) + V[i]);

                    segmentTree.Update(w, dp[i, w]);
                }

                segmentTreeList.Add(segmentTree);
            }

            Console.WriteLine(dp[N, W] <= 0 ? -1 : dp[N, W]);
        }

        // RMQ(Range Maximum Query)
        public class SegmentTree
        {
            private int treeHeight = 1;
            private int leafSize = 1;
            private long[] nodes = new long[1];

            public SegmentTree(int needNodeCount)
            {
                while(leafSize < needNodeCount)
                {
                    this.leafSize *= 2;
                    this.treeHeight++;
                }

                this.nodes = new long[1 << treeHeight];
                for (int i = 0; i < this.nodes.Length; i++)
                {
                    this.nodes[i] = long.MinValue;
                }
            }

            public void Update(int position, long value)
            {
                int nodeIndex = this.GetNodeIndex(position);

                this.UpdateByNodeIndex(nodeIndex, value);
            }

            public long GetMaximumValue(int positionLeft,int positionRight)
            {
                long maximumValue = this.GetMaximumValueByNodeIndex(positionLeft, positionRight, 1, 1);

                if(positionLeft<=0 && 0 <= positionRight)
                {
                    maximumValue = Math.Max(0L, maximumValue);
                }

                return maximumValue;
            }

            private void UpdateByNodeIndex(int nodeIndex, long value)
            {
                this.nodes[nodeIndex] = value;

                if (1 < nodeIndex)
                {
                    int nextNodeIndex = nodeIndex / 2;
                    long nexeValue = Math.Max(this.nodes[nextNodeIndex * 2], this.nodes[nextNodeIndex * 2 + 1]);
                    this.UpdateByNodeIndex(nextNodeIndex, nexeValue);
                }

            }

            private long GetMaximumValueByNodeIndex(int positionLeft, int positionRight, int targetNodeIndex,int depth)
            {
                (int left, int right) = this.GetPositionRange(targetNodeIndex,depth);

                if(positionLeft<= left && right <= positionRight)
                {
                    return nodes[targetNodeIndex];
                }

                if(right < positionLeft || positionRight < left)
                {
                    return long.MinValue;
                }

                long leftMximumValue = GetMaximumValueByNodeIndex(positionLeft, positionRight, targetNodeIndex * 2, depth + 1);
                long rightMaximumValue = GetMaximumValueByNodeIndex(positionLeft, positionRight, targetNodeIndex * 2 + 1, depth + 1);

                long maximumValue = Math.Max(leftMximumValue, rightMaximumValue);

                return maximumValue;
            }

            private int GetNodeIndex(int position)
            {
                return position + leafSize - 1;
            }

            private (int,int) GetPositionRange(int targetNodeIndex, int depth)
            {
                int deptDiff = treeHeight - depth;

                int left = targetNodeIndex * (1 << deptDiff) - leafSize + 1;
                int right = left + (1 << deptDiff) - 1;

                return (left,right);
            }


        }
    }
}
