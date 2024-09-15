namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_h
    {
        //008 - AtCounter（★4） 
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            string S = ReadString();

            string T = "atcoder";

            long[,] dp = new long[N + 1, T.Length + 1];

            for (int i = 1; i <= N; i++)
            {
                dp[i, 1] = dp[i - 1, 1] + (S[i-1] == T[0] ? 1 : 0);
            }

            for (int i = 2; i <= T.Length; i++)
            {
                for(int j = 1; j <= N; j++)
                {
                    if (S[j-1] == T[i - 1])
                    {
                        dp[j, i] = dp[j, i - 1] + dp[j -1 , i];
                    }
                    else
                    {
                        dp[j, i] = dp[j - 1, i];
                    }

                    dp[j, i] %= 1000000007;
                }
            }

            Console.WriteLine(dp[N,T.Length]);
        }
    }
}
