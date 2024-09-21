namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ax
    {
        // 050 - Stair Jump（★3） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NL = ReadIntArray();
            int N = NL[0];
            int L = NL[1];

            int[] dp = new int[N + 1];
            dp[0] = 1;

            for (int i = 1; i <= N; i++)
            {
                dp[i] = dp[i - 1] +  (0 <= i - L ? dp[i - L] : 0);
                dp[i] %= 1_000_000_007;
            }

            Console.WriteLine(dp[N]);
        }
    }
}
