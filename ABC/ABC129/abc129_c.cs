using System.Numerics;
namespace AtCoderCsharp.ABC.ABC129
{
    internal class abc129_c
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] a = new int[M];
            bool[] isBroken = new bool[N + 1];
            for (int i = 0; i < M; i++)
            {
                a[i] = ReadInt();
                isBroken[a[i]] = true;
            }

            long mod = 1_000_000_007L;
            long[] dp = new long[N + 1];
            dp[0] = 1;
            dp[1] = isBroken[1] ? -1 : dp[0];

            for (int i = 2; i <= N ; i++)
            {
                dp[i] += isBroken[i - 2] ? 0 : dp[i - 2];
                dp[i] += isBroken[i - 1] ? 0 : dp[i - 1];
                dp[i] %= mod;
            }

            Console.WriteLine(dp[N]);
        }
    }
}
