using System.Diagnostics.Metrics;

namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ay
    {
        // 051 - Typical Shop（★5） 
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NKP = ReadLongArray();
            int N = (int)NKP[0];
            int K = (int)NKP[1];
            long P = NKP[2];

            List<long> A = ReadLongArray().ToList();
            A.Insert(0, 0);

            int K1 = N / 2;
            int K2 = N - K1;

            // 1, 2, ... ,K1
            List<(int, long)> countAndPrice1 = new List<(int, long)>();
            for (int i = 0; i < (1 << K1); i++)
            {
                int count = 0;
                long price = 0L;
                for (int j = 1; j <= K1; j++)
                {
                    bool useItem = (i & (1 << (j - 1))) != 0;

                    if (useItem)
                    {
                        count++;
                        price += A[j];
                    }
                }

                if(K < count)
                {
                    continue;
                }

                if(P < price)
                {
                    continue;
                }

                countAndPrice1.Add((count, price));
            }

            countAndPrice1.Sort((a, b) => a.Item1 == b.Item1 ? (a.Item2 > b.Item2 ? 1 : (a.Item2 < b.Item2 ? -1 : 0)) : a.Item1 - b.Item1);

            // K1+1, K1+2, ... ,K1+K2
            List<long>[] countAndPrice2 = new List<long>[K + 1];
            for (int i = 0; i < K + 1; i++)
            {
                countAndPrice2[i] = new List<long>();
            }

            for (int i = 0; i < (1 << K2); i++)
            {
                int count = 0;
                long price = 0L;
                for (int j = 1; j <= K2; j++)
                {
                    bool useItem = (i & (1 << (j - 1))) != 0;

                    if (useItem)
                    {
                        count++;
                        price += A[K1+ j];
                    }
                }


                if (K < count)
                {
                    continue;
                }

                if (P < price)
                {
                    continue;
                }

                countAndPrice2[count].Add(price);
            }
            for (int i = 0; i < K + 1; i++)
            {
                countAndPrice2[i].Sort();
            }

            long answer = 0L;

            for (int i = 0; i < countAndPrice1.Count; i++)
            {
                (int count1, long price1) = countAndPrice1[i];

                int needCount = K - count1;
                if (needCount < 0)
                {
                    continue;
                }

                long limitPrice = P - price1;

                int index = countAndPrice2[needCount].BinarySearch(limitPrice);

                if (index < 0)
                {
                    index = ~index;
                    answer += (long)index;
                }
                else
                {
                    answer += (long)(index + 1);
                }

            }

            Console.WriteLine(answer);

        }
    }
}
