namespace AtCoderCsharp.ABC.ABC149
{
    internal class abc149_c
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int X = int.Parse(input1);

            for (int i = X; i < Math.Pow(10,6); i++)
            {
                if (IsPrimeNumber(i))
                {
                    Console.WriteLine(i);
                    return;
                }

            }
 
        }

        public static bool IsPrimeNumber(int n)
        {
            bool result = true;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    result = false;
                }

            }
            return result;

        }

    }
}
