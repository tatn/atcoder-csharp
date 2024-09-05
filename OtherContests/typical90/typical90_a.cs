using System.Security.Cryptography;

namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_a
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NL = ReadIntArray();
            int N = NL[0];
            int L = NL[1];

            int K = ReadInt();

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            int GetCutCount(int score)
            {
                int prevCutPoint = 0;
                int cutCount = 0;

                for (int i = 1; i <= N; i++)
                {
                    int length = A[i] - prevCutPoint;
                    if (score <= length)
                    {
                        cutCount++;
                        prevCutPoint = A[i];
                    }
                }

                if(score <= L - prevCutPoint)
                {
                    return cutCount + 1;

                }
                else
                {
                    return cutCount;
                }
            }

            int left = -1;
            int right = L+1;

            while (left + 1 < right)
            {
                int mid = (left + right) / 2;

                int cutCount = GetCutCount(mid);

                if (K + 1 <= cutCount)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            Console.WriteLine(left);
        }
    }
}
