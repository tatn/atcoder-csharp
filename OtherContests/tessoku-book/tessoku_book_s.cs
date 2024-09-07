
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_s
    {
        //A19 - Knapsack 1

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

            // dp[i,j] i番目までの品物の中か重さjでの価値の最大値
            long[,] dp = new long[N + 1, W + 1];
            for (int i = 0; i < N+1; i++)
            {
                for(int j = 0; j < W+1; j++)
                {
                    dp[i, j] = -1L;
                }
            }

            dp[0, 0] = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    if (dp[i-1, j] != -1)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
                    }

                    if(0 <= j - w[i] && dp[i-1, j - w[i]] != -1)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i-1, j - w[i]] + v[i]);
                    }
                }
            }

            long answer = -1L;
            for (int j = 0; j <= W; j++)
            {
               answer = Math.Max(answer, dp[N,j]);
            }

            Console.WriteLine(answer);
        }
    }
}
