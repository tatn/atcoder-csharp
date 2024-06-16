namespace AtCoderCsharp.AGC.AGC
{
    internal class agc002_a
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split(' ');
            int a = int.Parse(input1[0]);
            int b = int.Parse(input1[1]);

            if (0 < a)
            {
                Console.WriteLine("Positive");
            }
            else if (a == 0)
            {
                Console.WriteLine("Zero");
            }
            else
            {
                // a is Negative

                if (0 <= b)
                {
                    Console.WriteLine("Zero");
                }
                else
                {
                    // b is Negative
                    int count = b - a + 1;

                    Console.WriteLine(count % 2 == 0 ? "Positive" : "Negative ");

                }

            }

        }
    }
}
