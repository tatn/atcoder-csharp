using System.Numerics;

namespace AtCoderCsharp.ABC.ABC390
{
    internal class abc390_c
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            char[,] S = new char[H + 1, W + 1];

            for (int i = 1;i <= H; i++)
            {
                string sInput = ReadString();
                for (int j = 1; j <= W; j++)
                {
                    S[i, j] = sInput[j - 1];
                }
            }

            int blackLeft = W + 1;
            int blackRight = 0;
            int blackUp = H+1;
            int blackDown = 0 ;
            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    if (S[i,j] == '#')
                    {
                        blackLeft = j < blackLeft ? j : blackLeft;
                        blackRight = j > blackRight ? j : blackRight;
                        blackUp = i < blackUp ? i : blackUp;
                        blackDown = i > blackDown ? i : blackDown;
                    }
                }
            }

            for (int i = blackUp; i <= blackDown; i++)
            {
                for (int j = blackLeft; j <= blackRight; j++)
                {
                    if (S[i, j] == '.')
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }

            Console.WriteLine("Yes");
        }
    }
}
