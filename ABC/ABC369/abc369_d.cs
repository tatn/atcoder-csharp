using System.Numerics;

namespace AtCoderCsharp.ABC.ABC369
{
    internal class abc369_d
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();
            long[] A = ReadLongArray();

            // dp[i,0] i回目を偶数回の実施で終了、dp[i,1] i回目を奇数回の実施で終了
            long[,] dp = new long[N+1, 2];

            dp[1, 0] = 0;
            dp[1, 1] = A[0];

            for (int i = 2; i <= N; i++)
            {
                dp[i, 0] = Math.Max(Math.Max(dp[i - 1, 1] + A[i - 1] * 2, dp[i - 1, 0]), i - 2 <=0 ? -1 : dp[i - 2, 1] + A[i - 1] * 2);
                dp[i, 1] = Math.Max(Math.Max(dp[i - 1, 0] + A[i - 1], dp[i - 1, 1]), i - 2 <= 0 ? -1 : dp[i - 2, 0] + A[i - 1]);
            }

            Console.WriteLine(Math.Max(dp[N, 0], dp[N, 1]));

        }


    }
}
