
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_bf
    {
        //A58 - RMQ (Range Maximum Queries) 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[,] Query = new int[Q+1,3];
            for (int i = 1; i <= Q; i++)
            {
                int[] q = ReadIntArray();
                Query[i,0] = q[0];
                Query[i,1] = q[1];
                Query[i,2] = q[2];
            }

            int leafSize = 1;
            int level = 1;
            while (leafSize < N)
            {
                leafSize *= 2;
                level++;
            }

            int[] nodes = new int[1 << level];

            for (int i = 1; i <= Q; i++)
            {
                switch (Query[i, 0])
                {
                    case 1:
                        int pos = Query[i, 1];
                        int x = Query[i, 2];
                        int nodeIndex = GetNodeIndex(pos);
                        SetNodeValue(nodeIndex, x);
                        break;
                    case 2:
                        int l = Query[i, 1];
                        int r = Query[i, 2];
                        int max = GetMaxValue(l, r-1, 1, 1);
                        Console.WriteLine(max);
                        break;
                }

            }

            int GetNodeIndex(int position)
            {
                int nodeIndex = (1 << (level -1)) + position - 1;
                return nodeIndex;
            }

            (int, int) GetRange(int nodeIndex,int nodeLevel)
            {
                int levelLength = level - nodeLevel;
                int leftNodeIndex = nodeIndex * (1 << levelLength);
                int rightNodeIndex = leftNodeIndex + (1 << levelLength) - 1;

                int leftPosition = leftNodeIndex - (1 << (level-1)) + 1;
                int rightPosition = rightNodeIndex - (1 << (level - 1)) + 1;
                return (leftPosition, rightPosition);
            }

            void SetNodeValue(int nodeIndex, int value)
            {
                nodes[nodeIndex] = value;

                int nextNodeIndex = nodeIndex / 2;
                if(0 < nextNodeIndex)
                {
                    int nextValue = Math.Max(nodes[nextNodeIndex * 2], nodes[nextNodeIndex * 2 + 1]);
                    SetNodeValue(nextNodeIndex, nextValue);
                }
            }

            int GetMaxValue(int positionLeft,int positionRight, int targetNodeIndex, int targetNodeLevel)
            {
                (int targetLeft, int targetRight) = GetRange(targetNodeIndex, targetNodeLevel);

                if (positionLeft <= targetLeft && targetRight <= positionRight)
                {
                    return nodes[targetNodeIndex];
                }

                if (targetRight < positionLeft || positionRight < targetLeft)
                {
                    return -1;
                }

                int leftMax = GetMaxValue(positionLeft, positionRight, targetNodeIndex * 2, targetNodeLevel + 1);
                int rightMax = GetMaxValue(positionLeft, positionRight, targetNodeIndex * 2 + 1, targetNodeLevel + 1);

                return Math.Max(leftMax,rightMax);
            }

        }
    }
}