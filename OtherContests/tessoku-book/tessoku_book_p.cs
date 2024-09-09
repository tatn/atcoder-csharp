
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_p
    {
        //A16 - Dungeon 1

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);
            A.Insert(1, 0);

            List<int> B = ReadIntArray().ToList();
            B.Insert(0, 0);
            B.Insert(0, 0);
            B.Insert(0, 0);

            int[] dp = new int[N + 1];
            for (int i = 0; i <= N; i++)
            {
                dp[i] = 1_00_000_000;
            }
            dp[1] = 0;

            for (int i = 1; i <= N-2; i++)
            {
                dp[i + 1] = Math.Min(dp[i + 1], dp[i] + A[i + 1]);
                dp[i + 2] = Math.Min(dp[i + 2], dp[i] + B[i + 2]);
            }
            dp[N] = Math.Min(dp[N], dp[N-1] + A[N]);

            Console.WriteLine(dp[N]);
        }
    }
}
