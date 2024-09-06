using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_cl
    {
        //B13 - Supermarket 2

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);


            long[] sum = new long[N + 1];
            for (int i = 1; i <= N ; i++)
            {
                sum[i] = sum[i - 1] + A[i];
            }

            int[] R = new int[N + 1];
            R[0] = 0;
            for (int i = 1; i <= N; i++)
            {
                R[i] = R[i - 1];

                for (int j = R[i]; j <= N; j++)
                {
                    if (sum[j] - sum[i-1] <= K)
                    {
                        R[i] = j;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            long answer = 0L;
            for (int i = 1; i <= N; i++)
            {
                answer +=  R[i] - i + 1;
            }

            Console.WriteLine(answer);
        }
    }
}
