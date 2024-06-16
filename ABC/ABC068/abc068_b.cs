namespace AtCoderCsharp.ABC.ABC068
{
    internal class abc068_b
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            int answer = 1;
            for (int i = 0; i <= 7; i++)
            {
                int twoPower = 1 << i;

                if(twoPower <= N)
                {
                    answer = twoPower;
                }
            }

            Console.WriteLine(answer);


        }
    }
}
