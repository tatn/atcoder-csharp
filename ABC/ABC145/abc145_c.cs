namespace AtCoderCsharp.ABC.ABC145
{
    internal class abc145_c
    {
        public static void Main(string[] args)
        {

            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] x = new int[N];
            int[] y = new int[N];

            for (int i = 0; i < N; i++)
            {
                int[] inputxy = ReadIntArray();
                x[i] = inputxy[0];
                y[i] = inputxy[1];
            }

            double[,] d = new double[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = i+1; j < N; j++)
                {
                    d[i, j] = Math.Sqrt((x[i] - x[j]) * (x[i] - x[j]) + (y[i] - y[j]) * (y[i] - y[j]));
                    d[j, i] = d[i, j];
                }
            }

            List<int> towns = Enumerable.Range(0, N).ToList();
            var permutationsEnumerable = GetPermutations(towns);
            var permutations = permutationsEnumerable.Select(x=>x.ToArray()).ToArray();

            double sumOfDistannce = 0.0;
            int patternNumber = 0;
            foreach (int[] permutation in permutations)
            {
                double distance = 0.0;
                for(int i = 0;i < N-1; i++)
                {
                    distance += d[permutation[i], permutation[i + 1]];
                }
                sumOfDistannce += distance;
                patternNumber++;
            }

            Console.WriteLine(sumOfDistannce/(double)patternNumber);
        
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int? length = null)
        {
            if (length == null)
            {
                length = list.Count();
            }

            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                            (t1, t2) => t1.Concat(new T[] { t2 }));
        }

    }
}
