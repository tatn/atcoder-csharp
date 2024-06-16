namespace AtCoderCsharp.ABC.ABC097
{
    internal class abc097_b
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine()!;
            int X = int.Parse(s);

            int answer = 1;
            for (int i = 2; i <= Math.Sqrt(1000); i++)
            {
                if (X < i*i)
                {
                    break;
                }

                for (int j = 2; j <= 10 ; j++)
                {
                    int power = (int)Math.Pow(i, j);
                    if(X < power)
                    {
                        break;
                    }

                    if(answer < power)
                    {
                        answer = power;
                    }
                }
            }

            Console.WriteLine(answer);

           


        }
    }
}
