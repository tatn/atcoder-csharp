namespace AtCoderCsharp.ABC.ABC075
{
    internal class abc075_b
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            char[,] stringMap = new char[H+2,W+2];
            for (int i = 0; i <= W+1; i++)
            {
                stringMap[0, i] = '.';
                stringMap[H+1, i] = '.';
            }
            for (int i = 1; i <= H; i++)
            {
                string s = ReadString();
                for (int j = 1; j <= W; j++)
                {
                    stringMap[i, j] = s[j-1];
                }
                stringMap[i, 0] = '.';
                stringMap[i, W + 1] = '.';
            }

            int[, ] map = new int[H+2,W+2];

            for (int h = 1; h <= H; h++)
            {
                for (int w = 1; w <= W ; w++)
                {
                    int c = 0;
                    if(stringMap[h - 1, w - 1] == '#')
                    {
                        c++;
                    }
                    if (stringMap[h - 1, w ] == '#')
                    {
                        c++;
                    }
                    if (stringMap[h - 1, w + 1] == '#')
                    {
                        c++;
                    }

                    if (stringMap[h , w - 1] == '#')
                    {
                        c++;
                    }
                    if (stringMap[h , w] == '#')
                    {
                        c++;
                    }
                    if (stringMap[h , w + 1] == '#')
                    {
                        c++;
                    }

                    if (stringMap[h + 1, w - 1] == '#')
                    {
                        c++;
                    }
                    if (stringMap[h + 1, w] == '#')
                    {
                        c++;
                    }
                    if (stringMap[h + 1, w + 1] == '#')
                    {
                        c++;
                    }

                    map[h,w] = c;
                }
            }


            for (int h = 1; h <= H; h++)
            {
                for (int w = 1; w <= W; w++)
                {
                    if (stringMap[h,w] == '#')
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write(map[h,w]);
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
