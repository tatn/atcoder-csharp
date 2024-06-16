namespace AtCoderCsharp.ABC.ABC141
{
    internal class abc141_c
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split(' ');
            int N = int.Parse(input1[0]);
            int K = int.Parse(input1[1]);
            int Q = int.Parse(input1[2]);

            int[] A = new int[Q];

            for (int i = 0; i < Q; i++)
            {
                string input2 = Console.ReadLine()!;
                A[i] = int.Parse(input2);
            }

            int[] win = new int[N];
            for (int i = 0;i < Q; i++)
            {
                win[A[i]-1]++;
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(win[i] + K - Q <= 0 ? "No" : "Yes"); 
            }


        }

    }
}
