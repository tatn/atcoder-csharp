namespace AtCoderCsharp.AGC.AGC017
{
    internal class agc017_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NP = ReadIntArray();
            int N = NP[0];
            int P = NP[1];

            int[] A = ReadIntArray();

            int evenCount = A.Where(x => x % 2 == 0).Count();
            int oddCount = N - evenCount;

            if(oddCount == 0)
            {
                if(P == 0)
                {
                    Console.WriteLine(1L << evenCount);                    
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            else
            {
                Console.WriteLine(1L << (N - 1));
            }
        }
    }
}
