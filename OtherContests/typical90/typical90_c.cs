
namespace AtCoderCsharp.OtherContests.typical90
{
    // 003 - Longest Circular Road（★4） 

    internal class typical90_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] A = new int[N + 1];
            int[] B = new int[N + 1];

            List<int>[] G = new List<int>[N + 1];
            for (int i = 0; i <= N; i++)
            {
                G[i] = new List<int>();
            }

            int[] connectedCount = new int[N + 1];
            int maxConnectedIndex = -1;
            int maxConnectedCount = 0;

            for (int i = 1; i <= N-1; i++)
            {
                int[] AB = ReadIntArray();
                A[i] = AB[0];
                B[i] = AB[1];

                G[A[i]].Add(B[i]);
                G[B[i]].Add(A[i]);

                connectedCount[A[i]]++;
                connectedCount[B[i]]++;

                int c = connectedCount[A[i]] < connectedCount[B[i]] ? connectedCount[B[i]] : connectedCount[A[i]];
                if(maxConnectedCount < c)
                {
                    maxConnectedCount = c;

                    if(connectedCount[A[i]] < connectedCount[B[i]])
                    {
                        maxConnectedIndex = B[i];
                    }
                    else
                    {
                        maxConnectedIndex = A[i];
                    }

                }
            }

            bool[] visited = new bool[N + 1];
            int[] length = new int[N + 1];

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(maxConnectedIndex);
            length[maxConnectedCount] = 0;

            int maxLength = 0;
            int maxIndex = 0;

            while (0 < queue.Count)
            {
                int index = queue.Dequeue();
                visited[index] = true;

                foreach (int next in G[index])
                {
                    if (visited[next])
                    {
                        continue;
                    }

                    length[next] = length[index] + 1;

                    if (maxLength < length[next])
                    {
                        maxLength = length[next];
                        maxIndex = next;
                    }

                    queue.Enqueue(next);
                }
            }


            bool[] visited2 = new bool[N + 1];
            int[] length2 = new int[N + 1];

            Queue<int> queue2 = new Queue<int>();

            queue2.Enqueue(maxIndex);
            length2[maxIndex] = 0;

            int answer = 0;
            while (0 < queue2.Count)
            {
                int index = queue2.Dequeue();
                visited2[index] = true;

                foreach (int next in G[index])
                {
                    if (visited2[next])
                    {
                        continue;
                    }

                    length2[next] = length2[index] + 1;

                    if (answer < length2[next])
                    {
                        answer = length2[next];
                    }

                    queue2.Enqueue(next);
                }
            }

            Console.WriteLine(answer + 1);
        }
    }
}
