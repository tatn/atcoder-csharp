using System.Numerics;

namespace AtCoderCsharp.ABC.ABC366
{
    internal class abc366_d
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[,,] A = new int[N + 2, N + 2, N + 2];
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    int[] Ainput = ReadIntArray();
                    for (int k = 1; k <= N; k++)
                    {
                        A[i,j,k] = Ainput[k-1];
                    }
                }
            }

            int Q = ReadInt();
            int[,] LR = new int[Q, 6];
            for (int i = 0; i < Q; i++)
            {
                int[] intputLR = ReadIntArray();
                LR[i, 0] = intputLR[0];
                LR[i, 1] = intputLR[1];
                LR[i, 2] = intputLR[2];
                LR[i, 3] = intputLR[3];
                LR[i, 4] = intputLR[4];
                LR[i, 5] = intputLR[5];
            }


            int[,,] SUM = new int[N + 2, N + 2, N + 2];
            for (int i = 1;i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    for (int k = 1; k <= N; k++)
                    {
                        SUM[i, j, k] = SUM[i, j, k - 1] + A[i, j, k];
                    }
                }
            }
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    for (int k = 1; k <= N; k++)
                    {
                        SUM[i, k, j] = SUM[i,k-1, j] + SUM[i, k, j];
                    }
                }
            }

            for (int i = 0; i < Q; i++)
            {
                int lx = LR[i, 0];
                int rx = LR[i, 1];
                int ly = LR[i, 2];
                int ry = LR[i, 3];
                int lz = LR[i, 4];
                int rz = LR[i, 5];

                int answer = 0;
                if (lx == rx)
                {
                    answer = SUM[lx, ry, rz] + SUM[lx, ly - 1, lz - 1] - SUM[lx, ly - 1, rz] - SUM[lx, ry, lz - 1];
                }
                else
                {
                    for(int x = lx; x <= rx; x++)
                    {
                        answer += SUM[x, ry, rz] + SUM[x, ly - 1, lz - 1] - SUM[x, ly - 1, rz] - SUM[x, ry, lz - 1];
                    }
                }

                Console.WriteLine(answer);

            }

        }
    }
}
