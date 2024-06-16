namespace AtCoderCsharp.ABC.ABC074
{
    internal class abc074_b
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            string input2 = Console.ReadLine()!;
            int K = int.Parse(input2);

            string[] input3 = Console.ReadLine()!.Split(' ');
            int[] x = new int[N];
            x = input3.Select(int.Parse).ToArray();

            int move = 0;

            for (int i = 0; i < N; i++)
            {
                if(K <= x[i])
                {
                    move += (x[i] - K) * 2;
                }
                else
                {
                    if (x[i] <= K / 2)
                    {
                        move += x[i] * 2;
                    }
                    else
                    {
                        move += (K - x[i]) * 2;
                    }

                }

            }

            Console.WriteLine(move);


        }
    }
}
