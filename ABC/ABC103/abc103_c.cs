namespace AtCoderCsharp.ABC.ABC103
{
    internal class abc103_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();
            long[] a = ReadLongArray();

            long answer = 0;
            for (int i = 0; i < N; i++)
            {
                answer += a[i] - (long)1;
            }

            Console.WriteLine(answer);
        }

        public void Main2()
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();
            long[] a = ReadLongArray();

            long lcm = a[0];
            for (int i = 0; i < N; i++)
            {
                lcm = GetLCM(lcm, a[i]);
            }

            long answer = 0;
            for (int i = 0; i < N; i++)
            {
                answer += a[i] - 1;
            }

            Console.WriteLine(answer);
        }

        long GetGCD(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }

            return GetGCD(b, a % b);
        }


        long GetLCM(long a, long b)
        {
            long gcd = GetGCD(a, b);
            return a * b / gcd;
        }
    }
}
