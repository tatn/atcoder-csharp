namespace AtCoderCsharp.OtherContests.typical90
{
    // 064 - Uplift（★3） 

    internal class typical90_bl
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            int[] L = new int[Q + 1];
            int[] R = new int[Q + 1];
            int[] V = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                int[] LRV = ReadIntArray();
                L[i] = LRV[0];
                R[i] = LRV[1];
                V[i] = LRV[2];
            }

            long[] diff = new long[N + 1];
            long score = 0L;
            for (int i = 1; i <= N-1; i++)
            {
                diff[i] = A[i+1] - A[i];
                score += (long)Math.Abs(diff[i]);
            }

            for (int i = 1; i <= Q; i++)
            {
                long scoreDiff = 0L;

                int leftIndex = L[i];
                int rightIndex = R[i];

                if(1 < leftIndex)
                {
                    scoreDiff += Math.Abs(diff[leftIndex - 1] + V[i]) - Math.Abs(diff[leftIndex - 1]);
                    diff[leftIndex - 1] += V[i];
                }

                if (rightIndex < N)
                {
                    scoreDiff += Math.Abs(diff[rightIndex] - V[i]) - Math.Abs(diff[rightIndex]);
                    diff[rightIndex] -= V[i];
                }

                score += scoreDiff;
                Console.WriteLine(score);
            }

        }
    }
}
