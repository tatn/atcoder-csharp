namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_az
    {
        // 052 - Dice Product（★3） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[,] A = new int[N + 1, 6 + 1];

            int[] sum = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] aInput = ReadIntArray();
                int inputSum = 0;
                for (int j = 1; j <= 6; j++)
                {
                    A[i, j] = aInput[j - 1];
                    inputSum += A[i, j];
                }
                sum[i] = inputSum;
            }

            long answer = 1L;
            for (int i = 1; i <= N; i++)
            {
                answer = (answer * (long)sum[i]) % 1_000_000_007L;
            }

            Console.WriteLine(answer);

        }
    }
}
