namespace AtCoderCsharp.ABC.ABC086
{
    internal class abc086_b
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split(' ');
            string a = input1[0];
            string b = input1[1];

            int n = int.Parse(a + b);


            string answer = "No";
            for (int i = 1; i < Math.Sqrt(n) + 1; i++)
            {
                if (i * i == n)
                {
                    answer = "Yes";
                    break;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
