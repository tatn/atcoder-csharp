using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class math_and_algorithm_am
    {
        //A62 - Depth First Search 

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = new int[M+1];
            int[] B = new int[M+1];

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

            bool[] visited = new bool[N+1];
            visited[0] = true;

            DepthFirstSearch(1);

            void DepthFirstSearch(int index)
            {
                visited[index] = true;

                foreach (int next in G[index])
                {
                    if (visited[next])
                    {
                        continue;
                    }
                    DepthFirstSearch(next);
                }
            }

            Console.WriteLine(visited.All(x => x) ? "The graph is connected." : "The graph is not connected.");

        }
    }
}