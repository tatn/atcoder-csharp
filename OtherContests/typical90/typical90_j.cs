namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_j
    {
        //010 - Score Sum Queries（★2） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] C = new int[N + 1];
            int[] P = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] cp = ReadIntArray();
                C[i] = cp[0];
                P[i] = cp[1];
            }

            int Q = ReadInt();
            int[] L = new int[Q + 1];
            int[] R = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                int[] lr = ReadIntArray();
                L[i] = lr[0];
                R[i] = lr[1];
            }

            int[] sumOfClass1 = new int[N + 1];
            int[] sumOfClass2 = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                sumOfClass1[i] = sumOfClass1[i - 1];
                sumOfClass2[i] = sumOfClass2[i - 1];
                if (C[i] == 1)
                {
                    sumOfClass1[i] += P[i];
                }
                else
                {
                    sumOfClass2[i] += P[i];
                }
            }

            for (int i = 1; i <= Q; i++)
            {
                Console.WriteLine($"{sumOfClass1[R[i]] - sumOfClass1[L[i] - 1]} {sumOfClass2[R[i]] - sumOfClass2[L[i] - 1]}");
            }
        }
    }
}
