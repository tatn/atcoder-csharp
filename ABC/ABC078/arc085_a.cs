namespace AtCoderCsharp.ABC.ABC078
{
    internal class arc085_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int X = (1900 * M + (N - M) * 100) * (1 << M);

            Console.WriteLine(X);
        }

    }
}
