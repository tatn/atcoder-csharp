namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_af
    {
        // 032 - AtCoder Ekiden（★3） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[,] A = new int[N + 1, N + 1];
            for (int i = 1; i <= N; i++)
            {
                int[] aInput = ReadIntArray();
                for (int j = 1; j <= N; j++)
                {
                    A[i, j] = aInput[j - 1];
                }                
            }

            int M = ReadInt();

            List<int>[] G = new List<int>[N+1];
            for(int i = 0;i <= N; i++)
            {
                G[i] = new List<int>();
            }

            int[] X = new int[M + 1];
            int[] Y = new int[M + 1];
            for (int i = 1; i <= M; i++)
            {
                int[] xyInput = ReadIntArray();
                X[i] = xyInput[0];
                Y[i] = xyInput[1];

                G[X[i]].Add(Y[i]);
                G[Y[i]].Add(X[i]);
            }

            for (int i = 1; i <= N; i++)
            {
                G[i].Sort();
            }

            int answer = 20_000;
            int[] oneToN = Enumerable.Range(1, N).ToArray();
            do
            {
                if (!CanRun(oneToN))
                {
                    continue;
                }

                int time = GetTime(oneToN);
                answer = Math.Min(answer, time);
            } while (NextPermutation(oneToN));

            Console.WriteLine(answer == 20_000 ? -1 : answer);

            bool CanRun(int[] array)
            {

                for (int i = 0; i < N - 1; i++)
                {
                    if(0 <= G[array[i]].BinarySearch(array[i + 1]))
                    {
                        return false;
                    }
                }

                return true;
            }

            int GetTime(int[] array)
            {
                return array.Select((value,index)=>new { value, index }).Aggregate(0, (acc, x) => acc + A[x.value,x.index + 1]);
            }

            bool NextPermutation(int[] array)
            {
                int n = array.Length;
                int i = n - 2;

                // Find the largest index i such that array[i] < array[i + 1]
                while (i >= 0 && array[i] >= array[i + 1])
                {
                    i--;
                }

                if (i < 0)
                {
                    // The array is in descending order
                    Array.Reverse(array);
                    return false; // This was the last permutation
                }

                int j = n - 1;
                // Find the largest index j such that array[i] < array[j]
                while (array[i] >= array[j])
                {
                    j--;
                }

                // Swap array[i] and array[j]
                Swap(array, i, j);

                // Reverse the sequence from array[i + 1] to array[n - 1]
                Array.Reverse(array, i + 1, n - (i + 1));

                return true; // Next permutation was found
            }

            void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

        }
    }
}
