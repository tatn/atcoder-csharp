using System.Numerics;

namespace AtCoderCsharp.ABC.ABC154
{
    internal class abc154_d
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] P = ReadIntArray();

            int[] PPlusOne = P.Select(x => x+1).ToArray();

            int sum = 0;
            for (int i = 0; i < K; i++)
            {
                sum += PPlusOne[i]; 
            }

            int[] SumArray = new int[N - K + 1];
            SumArray[0] = sum;

            for (int i = 1; i < N-K+1; i++)
            {
                sum = sum + PPlusOne[i + K - 1] - PPlusOne[i + -1];
                SumArray[i] = sum;
            }

            int maxSum = SumArray.Max();

            Console.WriteLine(((double)maxSum)/2.0d);
        }
    }
}
