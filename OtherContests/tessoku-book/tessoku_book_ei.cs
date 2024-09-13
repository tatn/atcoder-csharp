using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_ei
    {
        //B62 - Print a Path 

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = new int[M + 1];
            int[] B = new int[M + 1];

            List<int>[] G = new List<int>[N + 1];
            for (int i = 0; i <= N; i++)
            {
                G[i] = new List<int>();
            }

            for (int i = 1; i <= M; i++)
            {
                int[] abInput = ReadIntArray();
                A[i] = abInput[0];
                B[i] = abInput[1];

                G[A[i]].Add(B[i]);
                G[B[i]].Add(A[i]);
            }

            List<int> path = new List<int>();

            bool[] visited = new bool[N + 1];
            visited[0] = true;

            DepthFirstSearch(1);

            void DepthFirstSearch(int index)
            {
                if (visited[N])
                {
                    return;
                }

                visited[index] = true;
                path.Add(index);

                foreach (int next in G[index])
                {
                    if (visited[next])
                    {
                        continue;
                    }
                    DepthFirstSearch(next);
                }

                if (!visited[N])
                {
                    path.Remove(index);
                }
            }

            Console.WriteLine(string.Join(" ",path));

        }
    }
}