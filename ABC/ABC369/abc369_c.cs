using System.Numerics;

namespace AtCoderCsharp.ABC.ABC369
{
    internal class abc369_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            long answer = N + N - 1;

            if (3 <= N)
            {
                int[] B = new int[N];

                for (int i = 0; i < N - 1; i++)
                {
                    B[i] = A[i + 1] - A[i];
                }

                B[N - 1] = -2_000_000_000;

                int prevB = -2_000_000_000;
                long prevCount = 1;
                for (int i = 0; i < N; i++)
                {
                    if (prevB == B[i])
                    {
                        prevCount++;
                    }
                    else
                    {
                        if (1 < prevCount)
                        {
                            answer += (long)(prevCount * (prevCount - 1L) / 2L);
                        }

                        prevCount = 1;
                        prevB = B[i];
                    }
                }

            }

            Console.WriteLine(answer);
        }
    }
}
