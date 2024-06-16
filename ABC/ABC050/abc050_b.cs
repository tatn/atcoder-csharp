namespace AtCoderCsharp.ABC.ABC050
{
    internal class abc050_b
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            string[] input2 = Console.ReadLine()!.Split();
            int[] T = input2.Select(int.Parse).ToArray();

            string input3 = Console.ReadLine()!;
            int M = int.Parse(input3);

            int[] P = new int[M];
            int[] X = new int[M];
            for (int i = 0; i < M; i++)
            {
                string[] input4 = Console.ReadLine()!.Split();
                P[i] = int.Parse(input4[0]);
                X[i] = int.Parse(input4[1]);
            }

            int sumT = T.Sum();

            for (int i = 0; i < M; i++)
            {
                Console.WriteLine(sumT - T[P[i]-1] + X[i]);
            }


        }

    }
}
