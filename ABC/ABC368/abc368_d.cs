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

            for (int i = 1; i <= N - 1; i++)
            {
                int[] AB = ReadIntArray();

                A[i] = AB[0];
                B[i] = AB[1];
            }

            int[] vInput = ReadIntArray();
            bool[] keepTarget = new bool[N + 1];

            for (int i = 0; i < K; i++)
            {
                keepTarget[vInput[i]] = true;
            }

            HashSet<int>[] G = new HashSet<int>[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                G[i] = new HashSet<int>();
            }

            for (int i = 1; i <= N - 1; i++)
            {
                G[A[i]].Add(B[i]);
                G[B[i]].Add(A[i]);
            }

            Stack<int> removeNodes = new Stack<int>();
            for (int i = 1; i <=N ; i++)
            {
                if (keepTarget[i])
                {
                    continue;
                }

                if (G[i].Count == 1)
                {
                    removeNodes.Push(i);
                }
            }

            int answer = N;
            while(0 < removeNodes.Count)
            {
                int removeNode = removeNodes.Pop();
                int nextNode = G[removeNode].First();

                G[removeNode].Remove(nextNode);
                G[nextNode].Remove(removeNode);
                answer--;

                if (keepTarget[nextNode])
                {
                    continue;
                }

                if (1 < G[nextNode].Count)
                {
                    continue;
                }

                removeNodes.Push(nextNode);
            }

            Console.WriteLine(answer);

        }


        public static void MainOther(string[] args)
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
            bool[] keepTarget = new bool[N+1];

            for (int i = 0; i < K; i++)
            {
                keepTarget[vInput[i]] = true;
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
                if (visited[node])
                {
                    return deleteNode[node];
                }
                visited[node] = true;

                bool candelete = true;
                if (keepTarget[node])
                {
                    candelete = false;
                }

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

            CanDelete(vInput[0]);

            Console.WriteLine(deleteNode.Skip(1).Count(a => !a));


        }
    }
}
