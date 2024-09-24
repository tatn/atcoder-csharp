namespace AtCoderCsharp.OtherContests.typical90
{
    // 062 - Paint All（★6） ToDo

    internal class typical90_bj
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            int[,] P = new int[H+1, W+1];

            for (int i = 1; i <= H; i++)
            {
                int[] ints = ReadIntArray();

                for (int j = 1; j <= W; j++)
                {
                    P[i,j] = ints[j-1]; 
                }
            }

            int answer = 0;

            // 2^8 = 256
            for (int bit = 1; bit < (1 << H); bit++)
            {
                List<int> selectedRows = new List<int>();

                for (int row = 1; row <= H; row++)
                {
                    if((bit & (1 << (row-1))) != 0)
                    {
                        selectedRows.Add(row);
                    }
                }

                Dictionary<int,int> allSameColumnCount = new Dictionary<int, int>();

                int maxtSameColumnCount = 0;

                // 10^4
                for (int col = 1; col <= W; col++)
                {
                    List<int> numbers = selectedRows.Select(r => P[r, col]).Distinct().ToList();
                    bool isSame = numbers.Count() == 1;

                    if (isSame)
                    {
                        if (allSameColumnCount.ContainsKey(numbers[0]))
                        {
                            allSameColumnCount[numbers[0]]++;

                        }
                        else
                        {
                            allSameColumnCount.Add(numbers[0], 1);
                        }
                        maxtSameColumnCount = Math.Max(maxtSameColumnCount, allSameColumnCount[numbers[0]]);
                    }
                }

                answer = Math.Max(answer, selectedRows.Count * maxtSameColumnCount);

            }

            Console.WriteLine(answer);

        }

    }
}
