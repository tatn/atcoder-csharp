
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_do
    {
        //B42 - Two Faced Cards 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] A = new int[N];
            int[] B = new int[N];
            for (int i = 0; i < N; i++)
            {
                int[] ab = ReadIntArray();
                A[i] = ab[0];
                B[i] = ab[1];
            }

            long sumOfPlusPlus = 0L;
            long sumOfPlusMinus = 0L;
            long sumOfMinusPlus = 0L;
            long sumOfMinusMinus = 0L;

            for (int i = 0; i < N; i++)
            {
                if (0 < A[i] + B[i])
                {
                    sumOfPlusPlus += A[i] + B[i];
                }

                if (0 < A[i] - B[i])
                {
                    sumOfPlusMinus += A[i] - B[i];
                }

                if (0 < - A[i] + B[i])
                {
                    sumOfMinusPlus += - A[i] + B[i];
                }

                if (0 < - A[i] - B[i])
                {
                    sumOfMinusMinus += - A[i] - B[i];
                }
            }

            long answer = Math.Max(sumOfPlusPlus, sumOfPlusMinus);
            answer = Math.Max(answer, sumOfMinusPlus);
            answer = Math.Max(answer, sumOfMinusMinus);

            Console.WriteLine(answer);
        }
    }
}