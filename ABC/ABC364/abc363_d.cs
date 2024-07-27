using System.Numerics;

namespace AtCoderCsharp.ABC.ABC364
{
    internal class abc364_d
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[] aArray = ReadIntArray();

            int[] bArray = new int[Q];
            int[] kArray = new int[Q];

            for (int i = 0; i < Q; i++)
            {
                int[] bk = ReadIntArray();

                bArray[i] = bk[0];
                kArray[i] = bk[1];
            }

            int[] aSorted = aArray.OrderBy(x => x).ToArray();

            int[] answer = new int[Q];


            for (int i = 0; i < Q; i++)
            {
                int b = bArray[i];
                int k = kArray[i];

                Func<int, int> getIndexRange = (int distance) =>
                {
                    int lowerBound = LowerBound(aSorted, b - distance);
                    int upperBound = UpperBound(aSorted, b + distance);

                    return upperBound - lowerBound;
                }
                ;

                int left = -1;
                int right = (int)1e9;

                while(right - left > 1)
                {
                    int mid = (left + right) / 2;

                    int rangeNumber = getIndexRange(mid);

                    if(k <= rangeNumber)
                    {
                        right = mid;
                    }
                    else
                    {
                        left = mid;
                    }
                }

                answer[i] = right;

            }

            for (int i = 0; i < Q; i++)
            {
                Console.WriteLine(answer[i]);
            }

        }


        public static int LowerBound<T>(T[] a, T x)
        {
            return LowerBound(a, x, Comparer<T>.Default);
        }


        public static int LowerBound<T>(T[] a, T x, Comparer<T> cmp)
        {
            int left = 0;
            int right = a.Length - 1;
            while (left <= right)
            {
                int m = left + (right - left) / 2;

                if (cmp.Compare(a[m], x) == -1)
                {
                    left = m + 1;
                }
                else
                {
                    right = m - 1;
                }
            }

            return left;
        }

        public static int UpperBound<T>(T[] a, T x)
        {
            return UpperBound(a, x, Comparer<T>.Default);
        }

        public static int UpperBound<T>(T[] a, T x, Comparer<T> cmp)
        {
            int left = 0;
            int right = a.Length - 1;
            while (left <= right)
            {
                int m = left + (right - left) / 2;

                if (cmp.Compare(a[m], x) <= 0)
                {
                    left = m + 1;
                }
                else
                {
                    right = m - 1;
                }
            }

            return left;
        }
    }
}
