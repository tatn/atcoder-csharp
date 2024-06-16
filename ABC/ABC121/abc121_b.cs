namespace AtCoderCsharp.ABC.ABC121
{
    internal class abc121_b
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split(' ');
            int N = int.Parse(input1[0]);
            int M = int.Parse(input1[1]);
            int C = int.Parse(input1[2]);

            string[] input2 = Console.ReadLine()!.Split(' ');
            int[] B = new int[M];
            B = input2.Select(int.Parse).ToArray();

            int[,] A = new int[N,M];
            for (int i = 0; i < N; i++)
            {
                string[] input3 = Console.ReadLine()!.Split(" ");
                int[] input3Int = new int[M];
                input3Int = input3.Select(int.Parse).ToArray();

                for (int j = 0; j < M; j++)
                {
                    A[i,j] = input3Int[j];
                }
            }

            int answer = 0;

            for (int i = 0; i < N; i++)
            {
                int v = C;
                for (int j = 0; j < M; j++)
                {
                    v += A[i, j] * B[j];
                }

                if(0 < v)
                {
                    answer++;
                }

            }


            Console.WriteLine(answer);

        }

    }
}
