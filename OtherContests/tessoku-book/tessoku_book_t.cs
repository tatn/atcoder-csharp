
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_t
    {
        //A20 - LCS

        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            string S = ReadString();
            string T = ReadString();

            int countS = S.Length;
            int countT = T.Length;

            int[,] dp = new int[countS + 1, countT + 1];

            for (int i = 1; i <= countS; i++)
            {
                for (int j = 1; j <= countT; j++)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
                    dp[i, j] = Math.Max(dp[i, j], dp[i, j - 1]);

                    if (S[i-1] == T[j-1])
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - 1] + 1);
                    }
                }
            }

            Console.WriteLine(dp[countS, countT]);
        }
    }
}
