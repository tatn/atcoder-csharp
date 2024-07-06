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



            Console.WriteLine(1);
        }
    }
}
