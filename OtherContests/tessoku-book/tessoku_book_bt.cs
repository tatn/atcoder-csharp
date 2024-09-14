
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_bt
    {
        //A72 - Tile Painting 

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] HWK = ReadIntArray();
            int H = HWK[0];
            int W = HWK[1];
            int K = HWK[2];

            bool[,] isBlack = new bool[H + 1, W + 1];
            for (int i = 1; i <= H; i++)
            {
                string input = ReadString();
                for (int j = 1; j <= W; j++)
                {
                    isBlack[i, j] = input[j - 1] == '#';
                }
            }

            int answer = 0;

            for (int bit = 0; bit < (1 << H); bit++)
            {
                List<int> paintedRows = new List<int>();

                for (int row = 1; row <= H; row++)
                {
                    if( (bit & (1 <<(row-1))) == 0)
                    {
                        continue;
                    }

                    paintedRows.Add(row);
                }

                int paintedRowsCount = paintedRows.Count;
                int needColPaintCount = K - paintedRowsCount;

                if(needColPaintCount < 0)
                {
                    continue;
                }

                List<int> colsBlackCount = new List<int>();

                for (int col = 1; col <= W; col++)
                {
                    int blackCount = 0;
                    for (int row = 1; row <= H; row++)
                    {
                        if (paintedRows.Contains(row))
                        {
                            continue;
                        }

                        if (isBlack[row, col])
                        {
                            blackCount++;
                        }
                    }

                    colsBlackCount.Add(blackCount);
                }
                colsBlackCount.Sort();

                int allBlackCount = colsBlackCount.Skip(needColPaintCount).Sum();
                allBlackCount += paintedRowsCount * W;

                answer = Math.Max(answer, allBlackCount);
            }

            Console.WriteLine(answer);


        }
    }
}
