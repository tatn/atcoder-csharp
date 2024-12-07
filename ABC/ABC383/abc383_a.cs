using System.Numerics;

namespace AtCoderCsharp.ABC.ABC383
{
    internal class abc383_a
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] T = new int[N+1];
            int[] V = new int[N+1];
            for (int i = 1; i <= N; i++)
            {
                int[] tv = ReadIntArray();
                T[i] = tv[0];
                V[i] = tv[1];
            }

            int passedTime = T[1];
            int answer = 0;
            for (int i = 1; i <= N; i++)
            {
                answer -= T[i] - passedTime;
                passedTime = T[i];
                if (answer < 0)
                {
                    answer = 0;
                }

                answer += V[i];
            }

            Console.WriteLine(answer);

        }
    }
}
