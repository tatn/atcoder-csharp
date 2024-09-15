namespace AtCoderCsharp.OtherContests.typical90
{
    //004 - Cross Sum（★2） 
    internal class typical90_d
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            List<int>[] A = new List<int>[H+1];
            A[0] = new List<int>();
            for (int i = 1; i <= H; i++)
            {
                int[] aInput = ReadIntArray();
                A[i] = aInput.ToList();
                A[i].Insert(0, 0);
            }

            int[] rowSum = new int[H + 1];
            int[] colSum = new int[W + 1];

            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    rowSum[i] = rowSum[i] + A[i][j];
                    colSum[j] = colSum[j] + A[i][j];
                }
            }

            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    Console.Write(rowSum[i] + colSum[j] - A[i][j]);
                    Console.Write(" ");
                }

                if(i != H)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
