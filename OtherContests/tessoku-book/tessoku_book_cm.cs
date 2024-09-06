using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_cm
    {
        //B14 - Another Subset Sum

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            if(N == 1)
            {
                Console.WriteLine(A[1] == K ? "Yes" : "No");
                return;
            }

            int halfCountX = N / 2;
            int halfCountY = N - halfCountX;

            // Aの 1,2,...,halfCountX1,halfCountX の和を列挙
            List<long> X = new List<long>();
            for (int bit = 0; bit < (1 << halfCountX); bit++)
            {
                long value = 0L;
                long bitValue = bit;
                for(int i = 1; i <= halfCountX; i++)
                {
                    if(bitValue % 2 == 1)
                    {
                        value += A[i];
                    }
                    bitValue /= 2;
                }

                X.Add(value);
            }

            X.Sort();

            // Aの halfCountX + 1,halfCountX+2,...,N-1,N の和を列挙
            List<long> Y = new List<long>();
            for (int bit = 0; bit < (1 << halfCountY); bit++)
            {
                long value = 0L;
                long bitValue = bit;
                for (int i = halfCountX + 1; i <= N; i++)
                {
                    if (bitValue % 2 == 1)
                    {
                        value += A[i];
                    }
                    bitValue /= 2;
                }

                Y.Add(value);
            }

            Y.Sort() ;


            bool exists = false ;

            foreach (long x in X)
            {
                int index = Y.BinarySearch(K - x);
                if(0 <= index)
                {
                    exists = true;
                    break;
                }
            }

            Console.WriteLine(exists ? "Yes" : "No");

        }
    }
}
