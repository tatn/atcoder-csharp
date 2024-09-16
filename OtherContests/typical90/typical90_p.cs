namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_p
    {
        // 016 - Minimum Coins（★3） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] ABC = ReadIntArray();
            int A = ABC[0];
            int B = ABC[1];
            int C = ABC[2];

            int answer = 9999;
            for (int cointCountA = 0; cointCountA <= 9999; cointCountA++)
            {
                for (int cointCountB = 0; cointCountB <= 9999 - cointCountA; cointCountB++)
                {
                    long remainPrice = (long)N - ((long)A * (long)cointCountA + (long)B * (long)cointCountB);

                    if (remainPrice < 0)
                    {
                        break;
                    }

                    if (remainPrice % C == 0)
                    {
                       answer = Math.Min(answer, cointCountA + cointCountB + (int)remainPrice / C);
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}
