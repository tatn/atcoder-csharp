namespace AtCoderCsharp.OtherContests.typical90
{
    // 055 - Select 5（★2） 


    internal class typical90_bc
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NPQ = ReadIntArray();
            int N = NPQ[0];
            int P = NPQ[1];
            int Q = NPQ[2];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            long ans = 0L;

            for (int i = 1; i <= N; i++)
            {
                for (int j = i + 1; j <= N; j++)
                {
                    for (int k = j + 1; k <= N; k++)
                    {
                        for (int l = k + 1; l <= N; l++)
                        {
                            for (int m = l + 1; m <= N; m++)
                            {
                                long mul = (long)A[i] % P * A[j] % P * A[k] % P * A[l] % P * A[m] % P;
                                
                                if(mul == Q)
                                {
                                    ans++;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(ans);

        }
    }
}
