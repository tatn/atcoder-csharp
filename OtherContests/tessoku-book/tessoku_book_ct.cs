
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_ct
    {
        //B21 - Longest Subpalindrome 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string ReadString() => Console.ReadLine()!;

            int N = ReadInt();
            string S = ReadString();

            int[,] dp = new int[N + 1, N + 1];

            for (int i = 1; i <= N; i++)
            {
                dp[i, i] = 1;
            }

            for (int i = 1; i <= N-1; i++)
            {
                dp[i, i + 1] = S[i - 1] == S[i] ? 2 : 1;
            }

            for (int length = 3; length <=N; length++)
            {
                for (int i = 1; i + length - 1 <=N; i++)
                {
                    dp[i, i + length - 1] = dp[i + 1, i + length - 2];
                    dp[i, i + length - 1] += S[i - 1] == S[i + length - 2] ? 2 : 0;
                    dp[i, i + length - 1] = Math.Max(dp[i, i + length - 1], dp[i + 1, i + length - 1]);
                    dp[i, i + length - 1] = Math.Max(dp[i, i + length - 1], dp[i, i + length - 2]);
                }
            }

            Console.WriteLine(dp[1,N]);
        }
    }
}
