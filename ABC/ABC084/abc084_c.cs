namespace AtCoderCsharp.ABC.ABC084
{
    // C - Special Trains

    internal class arc084_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] C = new int[N];
            int[] S = new int[N];
            int[] F = new int[N];

            for (int i = 1; i <= N - 1; i++)
            {
                int[] input = ReadIntArray();
                C[i] = input[0];
                S[i] = input[1];
                F[i] = input[2];
            }

            for (int i = 1; i <= N - 1; i++)
            {
                int passedTime = 0;
                for (int j = i; j <= N - 1; j++)
                {
                    if(passedTime < S[j])
                    {
                        passedTime = S[j];
                    }

                    int remainder = passedTime % F[j];
                    if (remainder != 0)
                    {
                        passedTime += F[j] - remainder;
                    }

                    passedTime += C[j];
                }

                Console.WriteLine(passedTime);
            }
            Console.WriteLine(0);

        }
    }
}
