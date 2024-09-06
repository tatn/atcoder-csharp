using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_m
    {
        //A13 - Close Pairs

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            int[] R = new int[N+1];
            R[0] = 1;
            R[1] = 1;

            for (int i = 1; i <= N-1; i++)
            {
                R[i] = R[i - 1];

                for (int j = R[i]; j <= N; j++)
                {
                    if (A[j] - A[i] <= K)
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
            for (int i = 1; i <= N - 1; i++)
            {
                answer += (long)(R[i] - i);
            }

            Console.WriteLine(answer);
        }

        public static void Main1(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            int currentIndex = 1;
            long answer = 0;
            for (int i = 1; i <= N - 1; i++)
            {
                for (int j = currentIndex; j <= N; j++)
                {

                    if (A[j] - A[i] <= K)
                    {
                        currentIndex = j;
                    }
                    else
                    {
                        break;
                    }
                }
                answer += (long)(currentIndex - i);
            }

            Console.WriteLine(answer);
        }
    }
}
