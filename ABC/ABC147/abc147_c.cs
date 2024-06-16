using System.Numerics;
namespace AtCoderCsharp.ABC.ABC147
{
    internal class abc147_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = new int[N];
            int[,] xy = new int [N,N];

            for (int i = 0; i < N; i++)
            {
                A[i] = ReadInt();
                for (int j = 0; j < N; j++)
                {
                    xy[i, j] = -1;
                }

                for (int j = 0; j < A[i]; j++)
                {
                    int[] inputXY = ReadIntArray();
                    xy[i, inputXY[0] - 1] = inputXY[1];
                }
            }

            int honestMaxNumber = 0;

            // 2^15 = 32768 ≒ 3 * 10^4
            for (int pattern = 0; pattern < (1 << N); pattern++)
            {
                bool isValid = true;

                for (int i = 0; i < N; i++)
                {
                    if (!isValid)
                    {
                        break;
                    }

                    bool iIsHonest = 0 < (pattern & (1 << i));
                    if (!iIsHonest)
                    {
                        continue;
                    }

                    for (int j = 0; j < N; j++)
                    {
                        bool jIsHonest = 0 < (pattern & (1 << j));
                        if (xy[i, j] == 1)
                        {
                            //人i+1による人j+1は正直者であるという証言

                            if (!jIsHonest)
                            {
                                isValid = false;
                                break;
                            }
                        }
                        else if (xy[i, j] == 0)
                        {
                            //人i+1による人j+1は不親切であるという証言
                            if (jIsHonest)
                            {
                                isValid = false;
                                break;
                            }
                        }
                    }
                }

                if (isValid)
                {
                    int honestNumer = BitOperations.PopCount((uint)pattern);
                    if (honestMaxNumber < honestNumer)
                    {
                        honestMaxNumber = honestNumer;
                    }
                }

            }

            Console.WriteLine(honestMaxNumber);
            

        }
    }
}
