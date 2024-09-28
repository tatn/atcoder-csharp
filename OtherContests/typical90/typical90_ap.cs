namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ap
    {
        // 042 - Multiple of 9（★4） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int K = ReadInt();

            if(K % 9 != 0)
            {
                Console.WriteLine(0);
                return;
            }

            long[] dp = new long[K + 1];
            dp[0] = 1;

            for (int i = 1; i <= K; i++)
            {
                for(int j = 1; j <= 9; j++)
                {
                    dp[i] += i - j < 0 ? 0 : dp[i - j];
                    dp[i] %= 1000000007;
                }
            }

            Console.WriteLine(dp[K]);
        }
    }
}
