namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_v
    {
        // 022 - Cubic Cake（★2） 
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] ABC = ReadLongArray();

            long A = ABC[0];
            long B = ABC[1];
            long C = ABC[2];

            long gcd = GetGCD(GetGCD(A, B), C);

            long answer = (A / gcd - 1) + (B / gcd - 1) + (C / gcd - 1);
            Console.WriteLine(answer);

            long GetGCD(long a, long b)
            {
                if (b == 0)
                {
                    return a;
                }

                return GetGCD(b, a % b);
            }

        }

    }
}
