using System;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC384
{
    internal class abc384_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NR = ReadIntArray();
            int N = NR[0];
            int R = NR[1];

            int[] D = new int[N + 1];
            int[] A = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] DA = ReadIntArray();
                D[i] = DA[0];
                A[i] = DA[1];
            }

            int answer = R;
            for (int i = 1; i <= N; i++)
            {
                if (D[i] == 1)
                {
                    if(1600 <= answer && answer <= 2799)
                    {
                        answer = answer + A[i];
                    }


                }
                else if (D[i] == 2)
                {
                    if (1200 <= answer && answer <= 2399)
                    {
                        answer = answer + A[i];
                    }
                }

            }

            Console.WriteLine(answer);
        }
    }
}
