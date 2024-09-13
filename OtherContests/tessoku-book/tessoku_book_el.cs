using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_el
    {
        //B65 - Road to Promotion Hard 

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NT = ReadIntArray();
            int N = NT[0];
            int T = NT[1];

            int[] A = new int[N];
            int[] B = new int[N];
            for (int i = 1; i <= N-1; i++)
            {
                int[] ab = ReadIntArray();
                A[i] = ab[0];
                B[i] = ab[1];
            }

            List<int>[] G = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                G[i] = new List<int>();
            }

            for (int i = 1; i <= N-1; i++)
            {
                G[A[i]].Add(B[i]);
                G[B[i]].Add(A[i]);
            }

            List<int>[] H = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                H[i] = new List<int>();
            }

            bool[] visited = new bool[N + 1];
            void Search(int index)
            {
                visited[index] = true;

                foreach (int next in G[index])
                {
                    if (visited[next])
                    {
                        continue;
                    }

                    H[index].Add(next);
                    Search(next);
                }
            }

            Search(T);

            int[] answer = new int[N + 1];

            int GetPosition(int index)
            {
                int position = 0;
                foreach (int next in H[index])
                {
                    position = Math.Max(position, GetPosition(next) + 1);
                }

                answer[index] = position;
                return answer[index];
            }

            GetPosition(T);


            Console.WriteLine(string.Join(" ", answer.Skip(1)));
        }
    }
}