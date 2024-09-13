using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_ef
    {
        //B59 - Number of Inversions 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            int leafSize = 1;
            int level = 1;
            while (leafSize < N)
            {
                leafSize *= 2;
                level++;
            }

            long[] nodes = new long[1 << level];

            long answer = 0;

            for (int i = 1; i <= N; i++)
            {
                long count = GetSumValue(A[i], N, 1, 1);
                answer += count;

                long countNumber = GetSumValue(A[i], A[i], 1, 1);
                SetNodeValue(GetNodeIndex(A[i]), countNumber + 1);
            }

            Console.WriteLine(answer);


            int GetNodeIndex(int position)
            {
                int nodeIndex = (1 << (level - 1)) + position - 1;
                return nodeIndex;
            }

            (int, int) GetRange(int nodeIndex, int nodeLevel)
            {
                int levelLength = level - nodeLevel;
                int leftNodeIndex = nodeIndex * (1 << levelLength);
                int rightNodeIndex = leftNodeIndex + (1 << levelLength) - 1;

                int leftPosition = leftNodeIndex - (1 << (level - 1)) + 1;
                int rightPosition = rightNodeIndex - (1 << (level - 1)) + 1;
                return (leftPosition, rightPosition);
            }

            void SetNodeValue(int nodeIndex, long value)
            {
                nodes[nodeIndex] = value;

                int nextNodeIndex = nodeIndex / 2;
                if (0 < nextNodeIndex)
                {
                    long nextValue = nodes[nextNodeIndex * 2] + nodes[nextNodeIndex * 2 + 1];
                    SetNodeValue(nextNodeIndex, nextValue);
                }
            }

            long GetSumValue(int positionLeft, int positionRight, int targetNodeIndex, int targetNodeLevel)
            {
                (int targetLeft, int targetRight) = GetRange(targetNodeIndex, targetNodeLevel);

                if (positionLeft <= targetLeft && targetRight <= positionRight)
                {
                    return nodes[targetNodeIndex];
                }

                if (targetRight < positionLeft || positionRight < targetLeft)
                {
                    return 0L;
                }

                long leftValue = GetSumValue(positionLeft, positionRight, targetNodeIndex * 2, targetNodeLevel + 1);
                long rightValue = GetSumValue(positionLeft, positionRight, targetNodeIndex * 2 + 1, targetNodeLevel + 1);

                return leftValue + rightValue;
            }
        }
    }
}