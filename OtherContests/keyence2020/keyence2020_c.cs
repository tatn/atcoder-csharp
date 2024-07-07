namespace AtCoderCsharp.OtherContests.keyence2020
{
    internal class keyence2020_c
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int[] input = ReadIntArray();
            int N = input[0];
            int K = input[1];
            int S = input[2];

            List<int> answer = new List<int>();

            if(S == 1_000_000_000)
            {
                for (int i = 0; i < K; i++)
                {
                    answer.Add(S);
                }

                for (int i = 0; i < N - K; i++)
                {
                    answer.Add(1);
                }
            }
            else
            {
                for (int i = 0; i < K; i++)
                {
                    answer.Add(S);
                }

                for (int i = 0; i < N-K; i++)
                {
                    answer.Add(S+1);
                }
            }

            Console.WriteLine(string.Join(" ", answer));

        }
    }
}
