namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_x
    {
        // 024 - Select +／- One（★2） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            List<int> B = ReadIntArray().ToList();
            B.Insert(0, 0);

            int needMinimumCount = 0;
            for (int i = 1; i <= N; i++)
            {
                needMinimumCount += Math.Abs(A[i] - B[i]);
            }

            if(K < needMinimumCount)
            {
                Console.WriteLine("No");
                return;
            }

            int remainCount = K - needMinimumCount;

            if(remainCount % 2 == 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
