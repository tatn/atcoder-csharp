using System.Numerics;
namespace AtCoderCsharp.ABC.ABC361
{
    internal class abc361_c
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = ReadIntArray();

            List<int> ASorted = A.ToList();
            ASorted.Sort();

            long[] diff = new long[N - 1];

            for (int i = 0; i < N-1; i++)
            {
                diff[i] = (long)ASorted[i + 1] - (long)ASorted[i];
            }

            int sumSize = N - K - 1;

            long sum = diff.Take(sumSize).Sum();
            long answer = sum;

            for (int i = 1; i + sumSize <= N - 1 ; i++)
            {
                long newsum = sum + diff[i+sumSize-1] - diff[i - 1];

                if (newsum < answer)
                {
                    answer= newsum;
                }

                sum = newsum;
            }

            Console.WriteLine(answer);

        }
    }
}
