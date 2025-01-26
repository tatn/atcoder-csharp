using System.Numerics;

namespace AtCoderCsharp.ABC.ABC390
{
    internal class abc390_e
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NX = ReadIntArray();
            int N = NX[0];
            int X = NX[1];

            int[] V = new int[N + 1];
            int[] A = new int[N + 1];
            int[] C = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] VAC = ReadIntArray();
                V[i] = VAC[0];
                A[i] = VAC[1];
                C[i] = VAC[2];
            }

            // dp[i, j, k] := ビタミンi(1<=i<=3)、j番目までの食品(0<=j<=N)、カロリーk(0<=k<=X)の時に取れる最大のビタミン量
            long[,,] dp = new long[4, N + 1, X + 1];
            for (int i = 0; i <=3; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    for (int k = 0; k <= X; k++)
                    {
                        dp[i, j, k] = -1L;
                    }
                }
            }
            dp[1, 0, 0] = 0L;
            dp[2, 0, 0] = 0L;
            dp[3, 0, 0] = 0L;

            for (int i = 1; i <= 3; i++)
            {

                for (int j = 1; j <= N; j++)
                {
                    int v = V[j];
                    int a = A[j];
                    int c = C[j];

                    for (int k = 0; k <= X; k++)
                    {
                        dp[i, j, k] = Math.Max(dp[i, j - 1, k], dp[i, j, k]);

                        if (i == v &&  c <= k)
                        {
                            if (0L <= dp[i, j - 1, k - c])
                            {
                                dp[i, j, k] = Math.Max(dp[i, j - 1, k - c] + (long)a, dp[i, j, k]);
                            }

                        }
                    }
                }
            }

            // vitaminMax[i, k] := ビタミンi(1<=i<=3)、カロリーk(0<=k<=X)以下で取れる最大のビタミン量
            long[,] vitaminMax = new long[4, X + 1];
            for (int i = 1; i <= 3; i++)
            {
                long currentVitamin = 0;
                for (int k = 1; k <= X; k++)
                {
                    currentVitamin = long.Max(currentVitamin, dp[i, N, k]);
                    vitaminMax[i, k] = currentVitamin;
                }
            }

            int calorie1 = 0;
            int calorie2 = 0;
            int calorie3 = 0;
            long minVitamin = 0L;
            for (int k = 1; k <= X; k++)
            {
                minVitamin = Math.Min(long.Min(vitaminMax[1, calorie1], vitaminMax[2, calorie2]), vitaminMax[3, calorie3]);

                if (minVitamin == vitaminMax[1, calorie1])
                {
                    calorie1++;
                }
                else if (minVitamin == vitaminMax[2, calorie2])
                {
                    calorie2++;
                }
                else
                {
                    calorie3++;
                }

            }

            minVitamin = Math.Min(long.Min(vitaminMax[1, calorie1], vitaminMax[2, calorie2]), vitaminMax[3, calorie3]);
            Console.WriteLine(minVitamin);


        }
    }
}
