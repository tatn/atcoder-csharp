namespace AtCoderCsharp.ABC.ABC373
{
    // F - Knapsack with Diminishing Values
    internal class abc373_f
    {
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

            // dp[i, j] := i番目までの品物から重さがjになるように選んだときの価値の最大値
            long[,] dp = new long[N + 1, W + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    dp[i, j] = long.MinValue;
                }
            }

            dp[0, 0] = 0L;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    // i番目の品物を選ばない場合
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);

                    int weight = w[i];
                    int value = v[i];

                    // i番目の品物をk個選ぶ場合
                    for (int k = 1; k <= 3000; k++)
                    {
                        if (W < weight * k)
                        {
                            break;
                        }

                        if (0 <= j - weight * k)
                        {
                            if (dp[i - 1, j - weight * k] != long.MinValue)
                            {
                                dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - weight * k] + (long)k * ((long)value - (long)k));
                            }

                        }
                        else
                        {
                            break;
                        }
                    }

                }
            }

            long answer = 0L;
            for (int i = 1; i <= W; i++)
            {
                answer = Math.Max(answer, dp[N, i]);
            }

            Console.WriteLine(answer);
        }
    }
}
