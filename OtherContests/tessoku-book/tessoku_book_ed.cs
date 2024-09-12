
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_ed
    {
        //B57 - Calculator 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            // 2^30 = 1.07 * 10^9
            // dp[i,j] jに対して、2^i回操作した後の値
            int[,] dp = new int[30 + 1, N + 1];

            for (int i = 0; i <= N; i++)
            {
                int sum = i.ToString().Select(x => int.Parse(x.ToString())).Sum();
                dp[0, i] = i - sum;
            }

            for (int i = 1; i <= 30; i++)
            {
                for(int j = 0; j <= N; j++)
                {
                    dp[i,j] = dp[i-1, dp[i-1, j]];
                }
            }

            int[] answer = new int[N+1];
            for (int i = 1; i <= N; i++)
            {
                answer[i] = i;
            }

            int kWork = K;
            int digitCount = 1;
            while(0 < kWork)
            {
                if(kWork % 2 == 1)
                {
                    for (int i = 1; i <= N; i++)
                    {
                        answer[i] = dp[digitCount-1, answer[i]];
                    }
                }

                digitCount++;
                kWork /= 2;
            }


            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(answer[i]);
            }

        }
    }
}