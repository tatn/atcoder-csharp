using System.Numerics;
namespace AtCoderCsharp.ABC.ABC364
{
    internal class abc364_b
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            int[] Sij = ReadIntArray();
            int Si = Sij[0];
            int Sj = Sij[1];

            bool[,] canMove = new bool[H + 2, W + 2];
            for (int i = 0; i < H; i++)
            {
                string line  = ReadString();

                for (int j = 0; j < W; j++)
                {
                    canMove[i+1, j+1] = line[j] == '.';

                }

            }

            string X = ReadString();

            int row = Si;
            int col = Sj;

            for (int i = 0; i < X.Length; i++)
            {
                char c = X[i];
                switch (c)
                {
                    case 'L':
                        if (canMove[row, col - 1])
                        {
                            col--;
                        }
                        break;
                    case 'R':
                        if (canMove[row, col + 1])
                        {
                            col++;
                        }
                        break;
                    case 'U':
                        if (canMove[row-1, col])
                        {
                            row--;
                        }
                        break;
                    case 'D':
                        if (canMove[row + 1, col])
                        {
                            row++;
                        }
                        break;
                     default:
                        break;
                }
            }


            Console.WriteLine($"{row} {col}");
        }
    }
}
