using System;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC385
{
    internal class abc385_b
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HWXY = ReadIntArray();
            int H = HWXY[0];
            int W = HWXY[1];
            int X = HWXY[2];
            int Y = HWXY[3];

            string[,] S = new string[H + 2, W + 2];

            for (int i = 1; i <= H; i++)
            {
                string line = ReadString();
                for (int j = 1; j <= W; j++)
                {
                    S[i, j] = line[j - 1].ToString();
                }               
            }

            for (int i = 0; i <= H+1; i++)
            {
                S[i, 0] = "#";
                S[i, W + 1] = "#";
            }

            for (int j = 0; j <= W + 1; j++)
            {
                S[0, j] = "#";
                S[H + 1, j] = "#";
            }

            string T = ReadString();

            bool[,] visited = new bool[H + 2, W + 2];
            int passedHouse = 0;

            if (S[X,Y] == "@")
            {
                passedHouse = 1;
                visited[X,Y] = true;
            }

            for (int i = 0; i < T.Length ; i++)
            {
                char tChar = T[i];
                int nextX = X;
                int nextY = Y;
                switch (tChar)
                {
                    case 'U':
                        nextX--;
                        break;
                    case 'D':
                        nextX++;
                        break;
                    case 'L':
                        nextY--;
                        break;
                    case 'R':
                        nextY++;
                        break;
                }

                if (S[nextX, nextY] == ".")
                {
                    X = nextX;
                    Y = nextY;
                }
                else if (S[nextX, nextY] == "@")
                {
                    X = nextX;
                    Y = nextY;

                    if (!visited[X, Y])
                    {
                        visited[X, Y] = true;
                        passedHouse++;
                    }
                }
            }

            Console.WriteLine($"{X} {Y} {passedHouse}");
        }
    }
}
