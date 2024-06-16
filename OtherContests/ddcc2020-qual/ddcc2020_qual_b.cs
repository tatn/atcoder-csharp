namespace AtCoderCsharp.OtherContests.ddcc2020_qual
{
    internal class ddcc2020_qual_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();
            long[] A = ReadLongArray();

            long[] S = new long[N];

            S[0] = A[0];
            for (int i = 1; i < N; i++)
            {
                S[i] = S[i - 1] + A[i];
            }

            long answer = S[N - 1] - S[0] - S[0];
            for (int i = 0; i < N -1; i++)
            {
                long left = S[i];
                long right = S[N - 1] - S[i];


                long cost = Math.Abs(left - right);
                if(cost < answer)
                {
                    answer = cost;
                }

            }

            Console.WriteLine(answer);
        }

    }
}
