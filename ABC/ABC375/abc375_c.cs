using System.Numerics;

namespace AtCoderCsharp.ABC.ABC375
{
    // C - Spiral Rotation
    internal class abc375_c
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            string[] A = new string[N + 1];
            char[][] B = new char[N + 1][];

            for (int i = 1; i <= N; i++)
            {
                A[i] = ReadString();
                B[i] = new char[N + 1];
            }

            int count = 1;
            int length = N;

            for (int i = 1; i <= N / 2; i++)
            {
                for (int j = i; j <= i + length - 1; j++)
                {
                    int rotateCount = count % 4;

                    (int newX_1, int newY_1) = GetRotatedPosition(i, j, rotateCount);
                    (int newX_2, int newY_2) = GetRotatedPosition(i + length - 1, j, rotateCount);
                    (int newX_3, int newY_3) = GetRotatedPosition(j, i, rotateCount);
                    (int newX_4, int newY_4) = GetRotatedPosition(j, i + length - 1, rotateCount);

                    B[i][j] = A[newX_1][newY_1 - 1];
                    B[i + length - 1][j] = A[newX_2][newY_2 - 1];
                    B[j][i] = A[newX_3][newY_3 - 1];
                    B[j][i + length - 1] = A[newX_4][newY_4 - 1];
                }

                count++;
                length -= 2;
            }

            (int, int) GetRotatedPosition(int x, int y, int rotateCount)
            {
                int newX, newY;
                rotateCount = rotateCount % 4;
                switch (rotateCount)
                {
                    case 0:
                        newX = x;
                        newY = y;
                        break;
                    case 1:
                        newX = N + 1 - y;
                        newY = x;
                        break;
                    case 2:
                        newX = N + 1 - x;
                        newY = N + 1 - y;
                        break;
                    case 3:
                        newX = y;
                        newY = N + 1 - x;
                        break;
                    default:
                        newX = x;
                        newY = y;
                        break;
                }

                return (newX, newY);
            }

            //// コンソール出力の高速化
            //var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            //Console.SetOut(sw);
            //for (int i = 1; i <= N; i++)
            //{
            //    for (int j = 1; j <= N; j++)
            //    {
            //        Console.Write(B[i][j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.Out.Flush();

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(string.Join("", B[i].Skip(1)));
            }
            Console.WriteLine();
        }
    }
}
