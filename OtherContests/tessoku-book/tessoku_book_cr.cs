
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_cr
    {
        //B19 - Knapsack 2

        public static void Main(string[] args)
        {

            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NW = ReadIntArray();
            int N = NW[0];
            int W = NW[1];

            int[] w = new int[N + 1];
            int[] v = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] wv = ReadIntArray();
                w[i] = wv[0];
                v[i] = wv[1];
            }

            // dp[i,j] i番目までの品物、合計価値jでの最小の重さ
            int maxValueSize = 100_000;
            long[,] dp = new long[N + 1, maxValueSize + 1];
            for (int i = 0; i < N + 1; i++)
            {
                for (int j = 0; j < maxValueSize + 1; j++)
                {
                    dp[i, j] = 1_00_000_000_001L;
                }
            }

            dp[0, 0] = 0L;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= maxValueSize; j++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j]);

                    if(0 <= j - v[i])
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j-v[i]] + w[i] );
                    }
                }
            }

            long answer = 0L;
            for (int j = maxValueSize; 0 <= j; j--)
            {
                if (dp[N,j]<= W)
                {
                    answer = j;
                    break;
                }
            }

            Console.WriteLine(answer);


        }
    }
}
