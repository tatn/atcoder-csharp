namespace AtCoderCsharp.ABC.ABC067
{
    internal class arc078_a
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();
            long[] a = ReadLongArray();

            long sumAll = a.Sum();
            long sumLeft = 0;

            long answer = 1_000_000_000L * 10L * 100_000L;
            for (int i = 0; i <= N-2; i++)
            {
                sumLeft += a[i];

                long sumRight = sumAll - sumLeft;

                long score = Math.Abs(sumLeft - sumRight);
                if (score < answer)
                {
                    answer = score;
                }
            }

            Console.WriteLine(answer);

        }

    }
}
