namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_s
    {
        // 019 - Pick Two（★6） 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            long[,] dp = new long[2 * N + 1, 2 * N + 1];
            for (int i = 0; i < 2 * N + 1; i++)
            {
                for (int j = 0; j < 2 * N + 1; j++)
                {
                    dp[i, j] = 300_000_000L;
                }
            }

            for (int length = 2; length <= 2 * N; length=length+2)
            {
                for (int i = 1; i + length - 1 <= 2 * N; i++)
                {
                    int left = i;
                    int right = i + length - 1;

                    if(length == 2)
                    {
                        // i ~ i+length-1
                        dp[left, right] = Math.Abs(A[i] - A[i + 1]);
                    }
                    else
                    {
                        dp[left, right] = Math.Min(dp[left, right], dp[left+1, right-1] + Math.Abs(A[left] - A[right]));

                        for (int j = left + 2 * 1 -1; j < right; j=j+2)
                        {
                            dp[left, right] = Math.Min(dp[left, right], dp[left, j]+ dp[j+1, right]);
                        }
                    }

                }
            }

            Console.WriteLine(dp[1,2*N]);

        }
    }
}
