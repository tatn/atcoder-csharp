
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_u
    {
        //A21 - Block Game 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] P = new int[N + 1];
            int[] A = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] pa = ReadIntArray();
                P[i] = pa[0];
                A[i] = pa[1];
            }

            int[,] dp = new int[N + 1, N + 1];
            dp[1, N] = 0;

            for (int length = N - 1; 1 <= length; length--)
            {
                for (int i = 1; i + length -1 <= N; i++)
                {
                    if (1 <= i - 1)
                    {
                        int addScore = i <= P[i - 1] && P[i - 1] <= i + length - 1 ? A[i - 1] : 0;
                        dp[i, i + length - 1] = Math.Max(dp[i, i + length - 1], dp[i - 1, i + length - 1] + addScore);
                    }

                    if(i + length <= N)
                    {
                        int addScore = i <= P[i + length] && P[i + length] <= i + length - 1 ? A[i + length] : 0;
                        dp[i, i + length - 1] = Math.Max(dp[i, i + length - 1], dp[i, i + length] + addScore);
                    }
                }
            }

            int score = 0;
            for (int i = 1; i <= N; i++)
            {
                score = Math.Max(score, dp[i, i]);
            }

            Console.WriteLine(score);
        }
    }
}
