using System.Numerics;

namespace AtCoderCsharp.ABC.ABC391
{
    internal class abc391_d
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NW = ReadIntArray();
            int N = NW[0];
            int W = NW[1];

            int[] X = new int[N + 1];
            int[] Y = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                int[] xy = ReadIntArray();
                X[i] = xy[0];
                Y[i] = xy[1];
            }

            int Q = ReadInt();
            int[] T = new int[Q + 1];
            int[] A = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                int[] ta = ReadIntArray();
                T[i] = ta[0];
                A[i] = ta[1];
            }

            List<(int, int)>[] sortedYListAtX = new List<(int, int)>[W + 1];
            for (int i = 0; i <= W; i++)
            {
                sortedYListAtX[i] = new List<(int, int)>();
            }

            CustomComparer customComparer = new CustomComparer();
            for (int i = 1; i <= N; i++)
            {
                int index = sortedYListAtX[X[i]].BinarySearch((Y[i], i), customComparer);
                if (index < 0)
                {
                    index = ~index;
                }
                sortedYListAtX[X[i]].Insert(index, (Y[i], i));
            }

            int[] vanishTime = new int[N + 2];
            for (int i = 1; i <= W; i++)
            {
                int yCountAtX = sortedYListAtX[i].Count;
                for (int j = 1; j <= yCountAtX; j++)
                {
                    vanishTime[j] = Math.Max(vanishTime[j], sortedYListAtX[i][j - 1].Item1);
                }

                vanishTime[yCountAtX + 1] = int.MaxValue;
            }

            for (int i = 2; i <= N; i++)
            {
                vanishTime[i] = Math.Max(vanishTime[i], vanishTime[i - 1]);
            }

            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            for (int i = 1; i <= Q; i++)
            {
                int blockIndex = A[i];
                int x = X[blockIndex];
                int y = Y[blockIndex];

                int blockYIndex = sortedYListAtX[x].BinarySearch((y, blockIndex), customComparer) + 1;

                Console.WriteLine(vanishTime[blockYIndex] <= T[i] ? "No" : "Yes");
            }
            Console.Out.Flush();
        }

        public class CustomComparer : IComparer<(int, int)>
        {
            public int Compare((int, int) a, (int, int) b)
            {
                return a.Item1.CompareTo(b.Item1);
            }
        }
    }
}
