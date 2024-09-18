using System.Runtime.Intrinsics.Arm;

namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ad
    {
        // 030 - K Factors（★5） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] primeCount = new int[N+1];

            for (int i = 2; i <= N; i++)
            {
                if (1 <= primeCount[i])
                {
                    continue;
                }

                for (int j = i; j <= N; j+=i)
                {
                    primeCount[j]++;
                }
            }

            int answer = 0;
            for (int i = 2; i <= N; i++)
            {
                if(K <= primeCount[i])
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);


        }
    }
}
