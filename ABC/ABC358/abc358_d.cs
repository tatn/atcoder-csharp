namespace AtCoderCsharp.ABC.ABC358
{
    internal class abc358_d
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = ReadIntArray();
            int[] B = ReadIntArray();

            int[] ASorted = A.OrderBy(x => x).ToArray();
            int[] BSorted = B.OrderBy(x => x).ToArray();

            long answer = 0;
            bool isOK = true;

            int index = Array.BinarySearch(ASorted, 0, N, BSorted[0], new LowerBound<int>());

            if (index < 0)
            {
                index = ~index;
            }

            if (index < N)
            {
                answer = ASorted[index];

                for (int i = 1; i < M; i++)
                {
                    index = Array.BinarySearch(ASorted, index + 1, N - index - 1, BSorted[i], new LowerBound<int>());

                    if (index < 0)
                    {
                        index = ~index;
                    }

                    if (index < N)
                    {
                        answer += (long)ASorted[index];
                    }
                    else
                    {
                        isOK = false;
                        break;
                    }
                }
            }
            else
            {
                isOK = false;
            }

            Console.WriteLine(isOK ? answer : -1);
        }

        public class LowerBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T? x, T? y)
            {
                return 0 <= x?.CompareTo(y) ? 1 : -1;
            }
        }
    }

}
