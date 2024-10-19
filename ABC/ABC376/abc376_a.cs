using System.Numerics;

namespace AtCoderCsharp.ABC.ABC376
{
    internal class abc376_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NC = ReadIntArray();
            int N = NC[0];
            int C = NC[1];

            int[] T = ReadIntArray();

            int answer = 0;
            int prev = -1000;
            for (int i = 0; i < N; i++)
            {
                int t = T[i];

                if (C <= t - prev)
                {
                    answer++;
                    prev = t;
                }
            }

            Console.WriteLine(answer);

        }
    }
}
