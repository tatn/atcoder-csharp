namespace AtCoderCsharp.ABC.ABC160
{
    internal class abc160_c
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split(' ');
            int K = int.Parse(input1[0]);
            int N = int.Parse(input1[1]);

            string[] input2 = Console.ReadLine()!.Split(' ');
            int[] A = input2.Select(int.Parse).ToArray();


            int[] distance = new int[N];
            for (int i = 0; i < N-1; i++)
            {
                distance[i] = A[i+1] - A[i];
            }

            distance[N - 1] = K - A[N - 1] + A[0];

            Console.WriteLine(K - distance.Max());

        }

    }
}
