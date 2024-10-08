﻿
using System.Reflection.Metadata.Ecma335;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_ee
    {
        //B58 - Jumping 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NLR = ReadIntArray();
            int N = NLR[0];
            int L = NLR[1];
            int R = NLR[2];

            List<int> X = ReadIntArray().ToList();
            X.Insert(0, -2_000_000_000);

            int max = 2_00_000;
            int[] dp = new int[N + 1];
            for (int i = 0; i < N+1; i++)
            {
                dp[i] = max;
            }

            int leafSize = 1;
            int level = 1;
            while (leafSize < N)
            {
                leafSize *= 2;
                level++;
            }

            int[] nodes = new int[1 << level];

            for (int i = 0; i < leafSize; i++)
            {
                int nodeIndex = GetNodeIndex(i + 1);
                SetNodeValue(nodeIndex, max);
            }

            dp[1] = 0;
            SetNodeValue(GetNodeIndex(1), 0);


            for (int i = 2; i <= N; i++)
            {
                int leftIndex = X.BinarySearch(X[i] - R);
                if(leftIndex < 0)
                {
                   leftIndex = ~leftIndex;
                }

                int rightIndex = X.BinarySearch(X[i] - L);
                if(rightIndex < 0)
                {
                    rightIndex = ~rightIndex;
                    rightIndex--;
                }

                if(rightIndex < leftIndex)
                {
                    continue;
                }

                dp[i] = GetMinValue(leftIndex,rightIndex,1,1) + 1;
                SetNodeValue(GetNodeIndex(i), dp[i]);
            }

            Console.WriteLine(dp[N]);


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

            void SetNodeValue(int nodeIndex, int value)
            {
                nodes[nodeIndex] = value;

                int nextNodeIndex = nodeIndex / 2;
                if (0 < nextNodeIndex)
                {
                    int nextValue = Math.Min(nodes[nextNodeIndex * 2], nodes[nextNodeIndex * 2 + 1]);
                    SetNodeValue(nextNodeIndex, nextValue);
                }
            }

            int GetMinValue(int positionLeft, int positionRight, int targetNodeIndex, int targetNodeLevel)
            {
                (int targetLeft, int targetRight) = GetRange(targetNodeIndex, targetNodeLevel);

                if (positionLeft <= targetLeft && targetRight <= positionRight)
                {
                    return nodes[targetNodeIndex];
                }

                if (targetRight < positionLeft || positionRight < targetLeft)
                {
                    return 2_000_000_000;
                }

                int leftMin = GetMinValue(positionLeft, positionRight, targetNodeIndex * 2, targetNodeLevel + 1);
                int rightMin = GetMinValue(positionLeft, positionRight, targetNodeIndex * 2 + 1, targetNodeLevel + 1);

                return Math.Min(leftMin, rightMin);
            }

        }
    }
}