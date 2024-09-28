namespace AtCoderCsharp.OtherContests.typical90
{
    // 058 - Original Calculator（★4） 

    internal class typical90_bf
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NK = ReadLongArray();
            int N = (int)NK[0];
            long K = NK[1];

            int displayLimit = 100_000;

            int GetANumber(int x)
            {
                int y = x.ToString().Select(c => int.Parse(c.ToString())).Sum();
                return (x + y) % displayLimit;
            }

            int[] visitedCount = new int[displayLimit];
            bool looped = false;
            int current = N;
            int count = 0;
            int period = 0;
            int periodStart = 0;
            while (count < K)
            {
                count++;
                current = GetANumber(current);

                if (visitedCount[current] != 0)
                {
                    looped = true;
                    periodStart = visitedCount[current];
                    period = count - periodStart;
                    break;
                }

                visitedCount[current] = count;
            }

            if (looped)
            {
                long answerIndex = K - (long)periodStart;
                answerIndex %= period;

                int answer = 0;
                for(int  i = 0; i < displayLimit; i++)
                {
                    if (visitedCount[i] == periodStart + answerIndex)
                    {
                        answer = i;
                    }
                }
               

                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine(current);
            }
        }

        public static void Main1(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NK = ReadLongArray();
            int N = (int)NK[0];
            long K = NK[1];

            int displayLimit = 100_000;

            int GetANumber(int x)
            {

                int y = x.ToString().Select(c => int.Parse(c.ToString())).Sum();
                return (x + y) % displayLimit;
            }


            // 2^60 = 1.1e+18
            int[,] dp = new int[61, displayLimit];
            for (int i = 0; i < displayLimit; i++)
            {
                dp[0, i] = GetANumber(i);
            }

            for (int i = 1; i < 61; i++)
            {
                for (int j = 0; j < displayLimit; j++)
                {
                    dp[i, j] = dp[i - 1, dp[i - 1, j]];
                }
            }

            int answer = N;
            int power = 0;
            long kWork = K;
            while (0 < kWork)
            {
                if (kWork % 2 == 1)
                {
                    answer = dp[power, answer];
                }

                kWork = kWork / 2;
                power++;
            }


            Console.WriteLine(answer);


        }

    }
}
