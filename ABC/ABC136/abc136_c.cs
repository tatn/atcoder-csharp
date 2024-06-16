namespace AtCoderCsharp.ABC.ABC136
{
    internal class abc136_c
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            string[] input2 = Console.ReadLine()!.Split();
            int[] h = input2.Select(int.Parse).ToArray();

            if(h.Length == 1)
            {
                Console.WriteLine("Yes");
                return;
            }

            int[] maxSequence = new int[N];
            int[] differenceSequence = new int[N];

            int max = h[0];
            for (int i = 0; i < N; i++)
            {
                if (max < h[i])
                {
                    max = h[i];
                }

                maxSequence[i] = max;
                differenceSequence[i] = h[i] - max;
            }

            Console.WriteLine(differenceSequence.All(x => -1 <= x) ? "Yes" : "No");

        }
    }
}
