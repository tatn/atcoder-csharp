using System.Numerics;

namespace AtCoderCsharp.ABC.ABC368
{
    internal class abc368_d
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = new int[N];
            int[] B = new int[N];

            for (int i = 1; i <= N-1; i++)
            {
                int[] AB = ReadIntArray();

                A[i] = AB[0];
                B[i] = AB[1];
            }

            int[] vInput = ReadIntArray();
            int[] V = new int[K+1];

            for (int i = 1; i <= K; i++)
            {
                V[i] = vInput[i-1];
            }

            List<int>[] G = new List<int>[N+1];
            for(int i = 0;i < N+1; i++)
            {
                G[i] = new List<int>();
            }

            for (int i = 1; i <= N - 1; i++)
            {
                G[A[i]].Add(B[i]);
                G[B[i]].Add(A[i]);
            }

            bool[] deleteNode = new bool[N+1];
            bool[] visited = new bool[N+1]; 

            bool CanDelete(int node)
            {
                bool candelete = true;
                if (V.Contains(node))
                {
                    candelete = false;
                }

                visited[node] = true;

                foreach (int i in G[node])
                {
                    if (visited[i])
                    {
                        continue;
                    }

                    bool childCanDelete = CanDelete(i);

                    candelete = candelete && childCanDelete;
                }

                deleteNode[node] = candelete;
                return candelete;
            }

            CanDelete(1);

            Console.WriteLine(deleteNode.Skip(1).Count(a => !a));


        }
    }
}
