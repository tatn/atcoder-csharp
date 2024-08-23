namespace AtCoderCsharp.OtherContests.jsc2019_qual
{
    internal class jsc2019_qual_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = ReadIntArray();

            int tentouNumberOfA = 0;
            int[] smallerCountOfA = new int[N];

            if(N == 1)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i+1 ; j < N ; j++)
                {
                    if (A[i] > A[j])
                    {
                        tentouNumberOfA++;
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                int smallCount = 0;

                for (int j = 0; j < N; j++)
                {
                    if(i == j)
                    {
                        continue;
                    }

                    if (A[i] > A[j])
                    {
                        smallCount++;
                    }
                }

                smallerCountOfA[i] = smallCount;
            }

            long answer = 0;
            long mode = 1_000_000_000L + 7L;

            answer = (long)tentouNumberOfA * (long)K;
            answer = answer % mode;

            if (1 < K)
            {
                for (int i = 0; i < N; i++)
                {
                    int smallerCount = smallerCountOfA[i];
                    if (smallerCount == 0)
                    {
                        continue;
                    }

                    long tentouNumber = (long)K * ((long)K - 1L) / 2L;
                    tentouNumber = tentouNumber % mode;
                    tentouNumber = tentouNumber * (long)smallerCount;
                    tentouNumber = tentouNumber % mode;

                    answer = answer + tentouNumber;
                    answer = answer % mode;
                }

            }
            Console.WriteLine(answer);


        }
    }
}
