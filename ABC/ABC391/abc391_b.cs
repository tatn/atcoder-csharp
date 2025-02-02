using System.Numerics;

namespace AtCoderCsharp.ABC.ABC391
{
    internal class abc391_b
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            char[,] S = new char[N+1,N+1];
            for (int i = 1; i <= N; i++)
            {
                string sInput = ReadString();
                for (int j = 1; j <= N; j++)
                {
                    S[i,j] = sInput[j-1];
                }
            }

            char[,] T = new char[M+1,M+1];
            for (int i = 1; i <= M; i++)
            {
                string tInput = ReadString();
                for (int j = 1; j <= M; j++)
                {
                    T[i,j] = tInput[j-1];
                }
            }

            for(int i=1; i<=1+N-M; i++)
            {
                for(int j=1; j<=1+N-M; j++)
                {
                    bool isSame = true;

                    for(int k = 1; k <= M; k++)
                    {
                        for(int l=1; l<=M; l++)
                        {
                            if (S[i + k - 1, j + l - 1] != T[k, l])
                            {
                                isSame = false;
                                break;
                            }
                        }
                        if(!isSame)
                        {
                            break;
                        }
                    }

                    if(isSame)
                    {
                        Console.WriteLine($"{i} {j}");
                        return;
                    }
                }
            }

        }
    }
}
