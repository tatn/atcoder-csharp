namespace AtCoderCsharp.OtherContests.typical90
{
    // 069 - Colorful Blocks 2（★3） 

    internal class typical90_bq
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NK = ReadLongArray();
            long N = NK[0];
            long K = NK[1];

            if (K == 1)
            {
                Console.WriteLine(N == 1L ? 1 : 0);
                return;
            }

            if (K == 2)
            {
                Console.WriteLine(3L <= N ? 0 : 2);
                return;
            }

            if (K == 3)
            {
                Console.WriteLine(N == 1L ? 3 : 6);
                return;
            }

            if(N == 1)
            {
                Console.WriteLine(K);
                return;
            }

            long answer = K * (K - 1L);
            long mod = 1000_000_007L;
            answer %= mod;

            if (N == 2)
            {
                Console.WriteLine(answer);
                return;
            }



            // K-2を　N-2乗する
            long baseNumber = K - 2L;
            long exponent = N - 2L;
            while (0 < exponent)
            {
                if (exponent % 2 == 1)
                {
                    answer *= baseNumber;
                    answer %= mod;
                }

                exponent /= 2;
                baseNumber *= baseNumber;
                baseNumber %= mod;
            }

            Console.WriteLine(answer);
        }

    }
}
