namespace AtCoderCsharp.OtherContests.hitachi2020
{
    internal class hitachi2020_b
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split(' ');
            int A = int.Parse(input1[0]);
            int B = int.Parse(input1[1]);
            int M = int.Parse(input1[2]);

            string[] input2 = Console.ReadLine()!.Split(' ');
            int[] a = input2.Select(int.Parse).ToArray();

            string[] input3 = Console.ReadLine()!.Split(' ');
            int[] b = input3.Select(int.Parse).ToArray();

            int[] x = new int[M];
            int[] y = new int[M];
            int[] c = new int[M];

            for (int i = 0; i < M; i++)
            {
                string[] input4 = Console.ReadLine()!.Split(' ');
                x[i] = int.Parse(input4[0]);
                y[i] = int.Parse(input4[1]);
                c[i] = int.Parse(input4[2]);
            }

            int answer = a.Min() + b.Min();

            for (int i = 0; i < M; i++)
            {
                int price = a[x[i]-1] + b[y[i] - 1] - c[i];

                if(price < answer)
                {
                    answer = price;
                }
            }

            Console.WriteLine(answer);
        }

    }
}
