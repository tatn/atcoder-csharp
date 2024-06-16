namespace AtCoderCsharp.ABC.ABC109
{
    internal class abc109_b
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            string[] W = new string[N];

            for (int i = 0; i < N; i++)
            {
                string input2 = Console.ReadLine()!;
                W[i] = input2;
            }

            if (W.Distinct().Count() < N)
            {
                Console.WriteLine("No");
                return;
            }

            string answer = "Yes";
            char lastChar = W[0].ToCharArray().Last();
            for (int i = 1; i < N; i++)
            {
                if(lastChar != W[i].First())
                {
                    answer = "No";
                    break;
                }

                lastChar = W[i].Last();
            }

            Console.WriteLine(answer);
        }

    }
}
