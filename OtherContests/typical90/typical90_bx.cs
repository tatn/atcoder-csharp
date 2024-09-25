namespace AtCoderCsharp.OtherContests.typical90
{
    // 076 - Cake Cut（★3） 

    internal class typical90_bx
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();
            List<long> A = ReadLongArray().ToList();
            A.Insert(0, 0);

            long sizeTotal = A.Sum();
            long needSize = sizeTotal / 10L;

            if (needSize * 10 != sizeTotal)
            {
                Console.WriteLine("No");
                return;
            }

            long[] sum = new long[2 * N];
            for (int i = 1; i <= N; i++)
            {
                sum[i] = sum[i - 1] + A[i];
            }
            for (int i = N+1; i <= 2*N - 1; i++)
            {
                sum[i] = sum[i - 1] + A[i - N];
            }

            bool isExist = false;

            int rightIndexStart = 1;
            for (int leftIndex = 1; leftIndex <= N; leftIndex++)
            {
                // leftIndex~rightIndexまでのケーキのサイズ

                for (int rightIndex = rightIndexStart; rightIndex <= 2*N - 1; rightIndex++)
                {
                    long cakeSize = sum[rightIndex] - sum[leftIndex - 1];

                    if (cakeSize == needSize)
                    {
                        isExist = true;
                        break;
                    }

                    if(needSize < cakeSize)
                    {
                        rightIndexStart = Math.Max(rightIndexStart, rightIndex - 1);
                        break;
                    }

                }

                if (isExist)
                {
                    break;
                }
            }

            Console.WriteLine(isExist ? "Yes" : "No");

        }
    }
}
