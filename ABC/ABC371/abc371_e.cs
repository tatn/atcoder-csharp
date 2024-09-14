namespace AtCoderCsharp.ABC.ABC371
{
    // E - I Hate Sigma Problems

    internal class abc371_e
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();

            List<int>[] indexes = new List<int>[N+1];
            for (int i = 0; i < N+1; i++)
            {
                indexes[i] = new List<int>();
                indexes[i].Add(0);
            }

            for (int i = 0; i < N; i++)
            {
                indexes[A[i]].Add(i+1);
            }

            for (int i = 0; i < N + 1; i++)
            {
                indexes[i].Add(N+1);
            }

            long answer = 0L;
            for (int i = 1; i <= N; i++)
            {
                long count = 0;
                for (int j = 0; j < indexes[i].Count -1; j++)
                {
                    long distance = indexes[i][j+1] - indexes[i][j] - 1;
                    count += distance * (distance + 1L) / 2L;
                }

                answer += ((long)N)*((long)N + 1L)/2L - count;
            }

            Console.WriteLine(answer);
        }
    }
}
