namespace AtCoderCsharp.ARC.ARC075
{
    internal class arc075_a
    {
        public void Main()
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int N = ReadInt();

            int[] s = new int[N];
            for (int i = 0; i < N; i++)
            {
                s[i] = ReadInt();
            }

            // i番目までの問題 合計点j
            int[,] dp = new int[N + 1, 100 * 101 + 1];

            dp[0, 0] = 1;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= 100 * 100; j++)
                {
                    if (dp[i, j] == 1)
                    {
                        dp[i + 1, j] = 1;

                        dp[i + 1, j + s[i]] = 1;
                    }
                }
            }

            int answer = 0;
            for (int j = 0; j < 100 * 101 + 1; j++)
            {
                if (dp[N, j] == 1 && j % 10 != 0)
                {
                    answer = Math.Max(answer, j);
                }
            }
            Console.WriteLine(answer);

        }


        public void MainNotDp()
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int N = ReadInt();

            int[] s = new int[N];
            for (int i = 0; i < N; i++)
            {
                s[i] = ReadInt();
            }

            int[] minNumbers = new int[10];

            for (int i = 0; i < N; i++)
            {
                int mod = s[i] % 10;

                if (minNumbers[mod] == 0 || s[i] < minNumbers[mod])
                {
                    minNumbers[mod] = s[i];
                }
            }

            int sum = s.Sum();

            if (sum % 10 == 0)
            {
                var q = minNumbers.Skip(1).Where(x => 0 < x);

                if (q.Any())
                {
                    Console.WriteLine(sum - q.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            else
            {
                Console.WriteLine(sum);
            }

        }

    }
}
