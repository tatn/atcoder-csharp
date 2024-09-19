namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ag
    {
        // 033 - Not Too Bright（★2） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            int brightCountInRow = (W + 1) / 2;

            int brightRowCount = (H + 1) / 2;

            if(H == 1 || W == 1)
            {
                Console.WriteLine(H*W);
            }
            else
            {
                Console.WriteLine(brightCountInRow * brightRowCount);
            }
        }
    }
}
