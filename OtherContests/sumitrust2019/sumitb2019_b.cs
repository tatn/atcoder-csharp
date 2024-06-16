namespace AtCoderCsharp.OtherContests.sumitrust2019
{
    internal class sumitb2019_b
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            int price = (int)Math.Ceiling(N / 1.08);

            int recalc = (int)Math.Floor(price * 1.08);

            if (recalc == N)
            {
                Console.WriteLine(price);
                return;
            }

            price--;
            recalc = (int)Math.Floor(price * 1.08);

            if (recalc == N)
            {
                Console.WriteLine(price);
                return;
            }

            Console.WriteLine(":(");

        }

    }
}
