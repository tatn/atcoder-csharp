using System.Numerics;
namespace AtCoderCsharp.ABC.ABC128
{
    internal class abc128_c
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] k = new int[M];
            int[,] s = new int[M, N];
            for (int i = 0; i < M; i++)
            {
                int[] ks = ReadIntArray();
                k[i] = ks[0];

                for (int j = 0; j < ks.Length - 1; j++)
                {
                    s[i, j] = ks[j + 1];
                }
            }

            int[] pInput = ReadIntArray();
            int[] P = new int[M];
            for (int i = 0; i < M; i++)
            {
                P[i] = pInput[i];
            }

            long answer = 0;
            for (int i = 0; i < 1<<N; i++)
            {
                bool isAllon = true;
                for (int j = 0; j < M; j++)
                {
                    int switchOndition = 0;
                    for (int si = 0; si < k[j]; si++)
                    {
                        switchOndition += 1 << (s[j, si] - 1);
                    }

                    int onCounter = BitOperations.PopCount((ulong)(i & switchOndition));

                    if (onCounter % 2 != P[j])
                    {
                        isAllon = false;
                    }
                }

                if (isAllon)
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);
            

        }
    }
}
