
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_cw
    {
        //B24 - Many Boxes 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] X = new int[N+1];
            int[] Y = new int[N+1];

            List<(int, int)> XY = new List<(int, int)>();

            for (int i = 1; i <= N; i++)
            {
                int[] xy = ReadIntArray();
                X[i] = xy[0];
                Y[i] = xy[1];

                XY.Add((X[i], Y[i]));
            }

            XY.Sort((a,b) => a.Item1 - b.Item1 == 0 ? b.Item2 - a.Item2 : a.Item1 - b.Item1);

            List<int> A = XY.Select(a => a.Item2).ToList();
            A.Insert(0, 0);

            int answer = 1;
            List<int> B = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                int findIndex = B.BinarySearch(A[i]);

                if (findIndex < 0)
                {
                    findIndex = ~findIndex;
                    if (B.Count <= findIndex)
                    {
                        B.Insert(findIndex, A[i]);

                        answer = Math.Max(answer, B.Count);
                    }
                    else
                    {
                        if (A[i] < B[findIndex])
                        {
                            B[findIndex] = A[i];
                        }
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}
