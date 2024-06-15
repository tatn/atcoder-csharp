namespace AtCoderCsharp.ABC.ABC156
{
    internal class abc156_c
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            string[] input2 = Console.ReadLine()!.Split(' ');
            long[] X = input2.Select(long.Parse).ToArray();

            long maxX = X.Max();

            long answer = 0;
            for (long i = 1; i <= maxX; i++)
            {
                long ps = X.Select(x => (x - i) * (x - i)).Sum();

                if (answer == 0 || ps < answer)
                {
                    answer = ps;
                }
            }

            Console.WriteLine(answer);

        }

    }
}
