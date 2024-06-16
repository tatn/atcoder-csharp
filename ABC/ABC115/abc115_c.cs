namespace AtCoderCsharp.ABC.ABC115
{
    internal class abc115_c
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split();
            int N = int.Parse(input1[0]);
            int K = int.Parse(input1[1]);

            int[] h = new int[N];
            for (int i = 0; i < N; i++)
            {
                string input2 = Console.ReadLine()!;
                h[i] = int.Parse(input2);
            }

            int[] hSorted = h.OrderBy(x => x).ToArray();

            int answer = hSorted.Last();
            for (int i = 0; i <= N - K ; i++)
            {
                int min = hSorted[i];
                int max = hSorted[i + K - 1];

                int diff = max - min; ;

                if (diff <= answer)
                {
                    answer = diff;
                }
            }

            Console.WriteLine(answer);

        }
    }
}
