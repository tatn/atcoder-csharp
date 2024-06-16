namespace AtCoderCsharp.OtherContests.code_festival_2016_qualc
{
    internal class code_festival_2017_qualc_b
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] ABC = ReadLongArray();
            long A = ABC[0];
            long B = ABC[1];
            long C = ABC[2];

            if (A % 2 == 0 || B % 2 == 0 || C % 2 == 0)
            {
                Console.WriteLine(0);
                return;
            }

            long ab = A * B;
            long bc = B * C;
            long ca = C * A;

            long answer = Math.Min(ab, bc);
            answer = Math.Min(answer,ca);

            Console.WriteLine(answer);
        }

    }
}
