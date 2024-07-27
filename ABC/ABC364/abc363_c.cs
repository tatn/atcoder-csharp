using System.Numerics;

namespace AtCoderCsharp.ABC.ABC364
{
    internal class abc364_c
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NXY = ReadLongArray();
            long N = NXY[0];
            long X = NXY[1];
            long Y = NXY[2];

            long[] A = ReadLongArray();
            long[] B = ReadLongArray();


            List<long> ASorted = A.ToList();
            ASorted.Sort();
            ASorted.Reverse();

            List<long> BSorted = B.ToList();
            BSorted.Sort();
            BSorted.Reverse();

            long[] ASum = new long[N];
            long[] BSum = new long[N];

            ASum[0] = ASorted[0];
            BSum[0] = BSorted[0];

            for (int i = 1; i < N; i++)
            {
                ASum[i] = ASorted[i] + ASum[i - 1];
                BSum[i] = BSorted[i] + BSum[i - 1];
            }

            int ACount = 0;
            for (int i = 0; i < N; i++)
            {
                ACount++;

                if (X < ASum[i])
                {
                    break;
                }
            }

            int BCount = 0;
            for (int i = 0; i < N; i++)
            {
                BCount++;

                if (Y < BSum[i])
                {
                    break;
                }
            }


            int answer = Math.Min(ACount, BCount);

            Console.WriteLine(answer);
        }
    }
}
