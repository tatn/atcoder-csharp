namespace AtCoderCsharp.ABC.ABC371
{
    // D - 1D Country

    internal class abc371_d
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> X = ReadIntArray().ToList();
            List<int> P = ReadIntArray().ToList();

            int Q = ReadInt();
            int[] L = new int[Q + 1];
            int[] R = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                int[] input = ReadIntArray();
                L[i] = input[0];
                R[i] = input[1];
            }

            List<long> sum = new List<long>();
            sum.Add(P[0]);
            for (int i = 1; i < N; i++)
            {
                sum.Add(sum[i-1] + P[i]);
            }

            for (int i = 1; i <= Q; i++)
            {
                int l = L[i];
                int r = R[i];

                int leftIndex = X.BinarySearch(l);
                if(leftIndex < 0)
                {
                    leftIndex = ~leftIndex;
                }

                int rightIndex = X.BinarySearch(r);
                if(rightIndex < 0)
                {
                    rightIndex = ~rightIndex;
                    rightIndex--;
                }

                long answer = (rightIndex < 0 ? 0 : sum[rightIndex]) - (leftIndex - 1 < 0 ? 0 : sum[leftIndex - 1]);
                Console.WriteLine(answer);
            }
        }
    }
}
