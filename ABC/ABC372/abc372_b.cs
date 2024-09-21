namespace AtCoderCsharp.ABC.ABC372
{
    // 	
    internal class abc372_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int M = ReadInt();

            int remain = M;

            List<int> answers = new List<int>();
            for (int i = 1; i <= 20; i++)
            {
                int power = 0;
                int threePowers = 1;
                while (threePowers <= remain)
                {
                    threePowers *= 3;
                    power++;
                }

                threePowers /= 3;
                power--;

                if (10 < power)
                {
                    power = 10;
                }

                answers.Add(power);

                remain -= threePowers;

                if (remain == 0)
                {
                    break;
                }
            }

            answers.Sort();

            Console.WriteLine(answers.Count);
            Console.WriteLine(string.Join(" ", answers));
           
        }
    }
}
