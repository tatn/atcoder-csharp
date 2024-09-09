namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_v
    {
        //A22 - Sugoroku

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            List<int> B = ReadIntArray().ToList();
            B.Insert(0, 0);

            int[] dp = new int[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                dp[i] = -1_00_000_000;
            }
            dp[1] = 0;

            for (int i = 1; i <= N-1; i++)
            {
                dp[A[i]] = Math.Max(dp[A[i]], dp[i] + 100);
                dp[B[i]] = Math.Max(dp[B[i]], dp[i] + 150);
            }

            Console.WriteLine(dp[N]);

        }
    }
}
