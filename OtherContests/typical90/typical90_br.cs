namespace AtCoderCsharp.OtherContests.typical90
{
    // 070 - Plant Planning（★4） ToDo

    internal class typical90_br
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] X = new int[N + 1];
            int[] Y = new int[N + 1];

            List<int> XList = new List<int>();
            List<int> YList = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                int[] xy = ReadIntArray();
                X[i] = xy[0];
                Y[i] = xy[1];

                XList.Add(xy[0]);
                YList.Add(xy[1]);
            }

            XList.Sort();
            YList.Sort();

            int leftX = 0;
            int rightX = N - 1;

            while(1 < rightX - leftX)
            {
                int midXIndex = (leftX + rightX) / 2;
                int midXValue = XList[midXIndex];

                int leftCount = XList.BinarySearch(midXValue, new LowerBoundComparer<int>());
                if(leftCount < 0)
                {
                    leftCount = ~leftCount;
                }

                int rightCount = XList.BinarySearch(midXValue + 1, new LowerBoundComparer<int>());
                if (rightCount < 0)
                {
                    rightCount = ~rightCount;
                }
                rightCount = N - rightCount;

                if (leftCount <= rightCount)
                {
                    leftX = midXIndex;

                }
                else if (rightCount < leftCount)
                {
                    rightX = midXIndex;
                }
            }

            long answerX1 = 0L;
            long answerX2 = 0L;

            for (int i = 1; i <= N; i++)
            {
                answerX1 += (long)Math.Abs(X[i] - XList[leftX]);
                answerX2 += (long)Math.Abs(X[i] - XList[rightX]);
            }

            int leftY = 0;
            int rightY = N-1;

            while (1 < rightY - leftY)
            {
                int midYIndex = (leftY + rightY) / 2;
                int midYValue = YList[midYIndex];

                int leftCount = YList.BinarySearch(midYValue, new LowerBoundComparer<int>());
                if (leftCount < 0)
                {
                    leftCount = ~leftCount;
                }

                int rightCount = YList.BinarySearch(midYValue + 1, new LowerBoundComparer<int>());
                if (rightCount < 0)
                {
                    rightCount = ~rightCount;
                }
                rightCount = N - rightCount;

                if (leftCount <= rightCount)
                {
                    leftY = midYIndex;

                }
                else if (rightCount < leftCount)
                {
                    rightY = midYIndex;
                }
            }

            long answerY1 = 0L;
            long answerY2 = 0L;

            for (int i = 1; i <= N; i++)
            {
                answerY1 += (long)Math.Abs(Y[i] - YList[leftY]);
                answerY2 += (long)Math.Abs(Y[i] - YList[rightY]);
            }


            Console.WriteLine(Math.Min(answerX1, answerX2)+ Math.Min(answerY1, answerY2));

        }


        public class LowerBoundComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T? x, T? y)
            {
                return 0 <= x?.CompareTo(y) ? 1 : -1;
            }
        }

    }
}
