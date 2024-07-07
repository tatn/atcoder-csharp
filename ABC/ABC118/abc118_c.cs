namespace AtCoderCsharp.ABC.ABC118
{
    internal class abc118_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            int gcd = GetGCD(A[0], A[1]);

            for (int i = 2; i < N; i++)
            {
                gcd = GetGCD(gcd, A[i]);
            }

            Console.WriteLine(gcd);
        }

        static int GetGCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return GetGCD(b, a % b);
        }
    }
}
