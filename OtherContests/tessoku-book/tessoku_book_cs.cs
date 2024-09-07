
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_cs
    {
        //B20 - Edit Distance 

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
                    dp[i, j] = 2001;
                }
            }

            dp[0, 0] = 0;
            for (int i = 1; i <= countS; i++)
            {
                dp[i, 0] = i;
            }
            for (int i = 1; i <= countT; i++)
            {
                dp[0, i] = i;
            }

            for (int i = 1; i <= countS; i++)
            {
                for (int j = 1; j <= countT; j++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j] + 1);
                    dp[i, j] = Math.Min(dp[i, j], dp[i, j - 1] + 1);
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1] + (S[i - 1] == T[j - 1] ? 0 : 1));
                }
            }

            Console.WriteLine(dp[countS, countT]);
        }
    }
}
