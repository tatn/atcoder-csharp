
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_bx
    {
        //A76 - River Crossing 

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NWLR = ReadIntArray();
            int N = NWLR[0];
            int W = NWLR[1];
            int L = NWLR[2];
            int R = NWLR[3];

            List<int> X = ReadIntArray().ToList();
            X.Insert(0, 0);
            X.Add(W);

            long[] dp = new long[N + 2];
            long[] sum = new long[N + 2];
            dp[0] = 1;
            sum[0] = 1;

            long mod = 1_000_000_007L;

            for (int i = 1; i <= N + 1; i++)
            {
                int currentX = X[i];
                int left = currentX - R;
                int right = currentX - L;

                int leftIndex = X.BinarySearch(left);
                if (leftIndex < 0)
                {
                    leftIndex = ~leftIndex;
                }

                int rightIndex = X.BinarySearch(right);
                if (rightIndex < 0)
                {
                    rightIndex = ~rightIndex;
                    rightIndex = rightIndex - 1;
                }

                if (i <= leftIndex)
                {
                    dp[i] = 0;
                    sum[i] = sum[i - 1] + dp[i];
                    continue;
                }

                if(rightIndex < leftIndex)
                {
                    dp[i] = 0;
                    sum[i] = sum[i - 1] + dp[i];
                    continue;
                }

                dp[i] = sum[rightIndex] - (leftIndex - 1 < 0 ? 0 : sum[leftIndex - 1]);
                dp[i] %= mod;
                if (dp[i] < 0)
                {
                    dp[i] += mod;
                }

                sum[i] = sum[i - 1] + dp[i];
                sum[i] %= mod;
            }

            Console.WriteLine(dp[N+1]);
        }
    }
}
