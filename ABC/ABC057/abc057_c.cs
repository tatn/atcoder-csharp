namespace AtCoderCsharp.ABC.ABC057
{
    internal class abc057_c
    {
        public static void Main(string[] args)
        {
            long ReadLong() => long.Parse(Console.ReadLine()!);
            long N = ReadLong();

            int answer = N.ToString().Length;
            for (long i = 1; i * i <= N; i++)
            {
                if (N % i == 0)
                {
                    int length1 = i.ToString().Length;
                    int length2 = (N / i).ToString().Length;

                    if(Math.Max(length1, length2) < answer)
                    {
                        answer = Math.Max(length1, length2);
                    }

                }
            }

            Console.WriteLine(answer);

        }


    }
}
