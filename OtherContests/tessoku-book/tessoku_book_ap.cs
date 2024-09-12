
using System.Numerics;
using System.Reflection;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_ap
    {
        //A42 - Soccer 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = new int[N];
            int[] B = new int[N];

            for (int i = 0; i < N; i++)
            {
                int[] AB = ReadIntArray();
                A[i] = AB[0];
                B[i] = AB[1];
            }

            int answer = 0;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    int count = 0;
                    for (int k = 0; k < N; k++)
                    {
                        if(i <= A[k] && A[k] <= i + K && j <= B[k] && B[k] <= j + K)
                        {
                            count++;
                        }
                    }

                    answer = Math.Max(answer, count);
                }
            }

            Console.WriteLine(answer);

        }
    }
}