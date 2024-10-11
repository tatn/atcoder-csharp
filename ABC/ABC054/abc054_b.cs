using System.Numerics;

namespace AtCoderCsharp.ABC.ABC054
{

    //B. Template Matching

    internal class abc054_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            string[] A = new string[N+1];
            string[] B = new string[M+1];

            for (int i = 1; i <= N; i++)
            {
                A[i] = ReadString();
            }

            for (int i = 1; i <= M; i++)
            {
                B[i] = ReadString();
            }

            for (int i = 1; i <= N - M + 1 ; i++)
            {
                for (int j = 1; j <= N - M + 1; j++)
                {
                    bool isMatch = true;
                    for (int k = 1; k <= M; k++)
                    {
                        for (int l = 1; l <= M; l++)
                        {
                            if (A[i+k-1][j+l-2] != B[k][l-1])
                            {
                                isMatch = false;
                                break;
                            }
                        }

                        if (!isMatch)
                        {
                            break;
                        }

                    }

                    if (isMatch)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
            }

            Console.WriteLine("No");

        }
    }
}
