namespace AtCoderCsharp.ABC.ABC371
{
    //C - Make Isomorphic 

    internal class abc371_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int Mg = ReadInt();

            int[] u = new int[Mg + 1];
            int[] v = new int[Mg + 1];

            List<int>[] G = new List<int>[N + 1];
            List<int>[] H = new List<int>[N + 1];
            for (int i = 0; i <= N; i++)
            {
                G[i] = new List<int>();
                H[i] = new List<int>();
            }

            for (int i = 1; i <= Mg; i++)
            {
                int[] input = ReadIntArray();
                u[i] = input[0];
                v[i] = input[1];

                G[u[i]].Add(v[i]);
                G[v[i]].Add(u[i]);
            }

            int Mh = ReadInt();

            int[] a = new int[Mh + 1];
            int[] b = new int[Mh + 1];
            for (int i = 1; i <= Mh; i++)
            {
                int[] input = ReadIntArray();
                a[i] = input[0];
                b[i] = input[1];

                H[a[i]].Add(b[i]);
                H[b[i]].Add(a[i]);
            }

            int[,] A = new int[N, N + 1];
            for (int i = 1; i <= N-1; i++)
            {
                int[] input = ReadIntArray();

                for (int j = i+1; j <= N; j++)
                {
                    A[i,j] = input[j-i-1];
                }
            }

            int[] nodeIndexes = new int[N];
            for (int i = 1;i <= N; i++)
            {
                nodeIndexes[i-1] = i;
            }

            int answer = 1_000_000_000;
            foreach (int[] indexes in GetPermutations(nodeIndexes))
            {
                // 5! = 120
                int cost = 0;

                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= N; j++)
                    {
                        if(i == j)
                        {
                            continue;
                        }

                        if (G[i].Contains(j) && H[indexes[i - 1]].Contains(indexes[j - 1]))
                        {
                            continue;
                        }

                        if (!G[i].Contains(j) && !H[indexes[i - 1]].Contains(indexes[j-1]))
                        {
                            continue;
                        }

                        if (indexes[i - 1] < indexes[j - 1])
                        {
                            cost += A[indexes[i - 1], indexes[j - 1]];
                        }
                        else
                        {
                            cost += A[indexes[j - 1], indexes[i - 1]];
                        }
                    }
                }

                answer = Math.Min(answer,cost/2);
            }

            Console.WriteLine(answer);

            List<T[]> GetPermutations<T>(params T[] array) where T : IComparable
            {
                var a = new List<T>(array).ToArray();
                var res = new List<T[]>();
                res.Add(new List<T>(a).ToArray());
                var n = a.Length;
                var next = true;
                while (next)
                {
                    next = false;

                    int i;
                    for (i = n - 2; i >= 0; i--)
                    {
                        if (a[i].CompareTo(a[i + 1]) < 0) break;
                    }
                    if (i < 0)
                    {
                        break;
                    }

                    var j = n;
                    do
                    {
                        j--;
                    } while (a[i].CompareTo(a[j]) > 0);

                    if (a[i].CompareTo(a[j]) < 0)
                    {
                        var tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                        Array.Reverse(a, i + 1, n - i - 1);
                        res.Add(new List<T>(a).ToArray());
                        next = true;
                    }
                }
                return res;
            }
        }
    }
}
