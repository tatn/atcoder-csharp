namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_av
    {
        // 048 - I will not drop out（★3） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = new int[N + 1];
            int[] B = new int[N + 1];
            List<(int,int)> AB = new List<(int, int)>();

            for (int i = 1; i <= N; i++)
            {
                int[] abInput = ReadIntArray();
                A[i] = abInput[0];
                B[i] = abInput[1];
                AB.Add((A[i], B[i]));
            }

            AB.Sort((a, b) => b.Item2 - a.Item2 == 0 ? b.Item1 - a.Item1 : b.Item2 - a.Item2);

            List<int> mantenList = new List<int>();

            long answer = 0L;
            int partIndex = 0;
            for (int i = 1; i <= K; i++)
            {
                int partScore = -1;
                if (partIndex <= N - 1)
                {
                    partScore = AB[partIndex].Item2;
                }

                int mantenAddScore = -1;
                if (0 < mantenList.Count)
                {
                    mantenAddScore = mantenList.Last();
                }

                if (mantenAddScore <= partScore)
                {
                    answer += (long)partScore;

                    int addScore = AB[partIndex].Item1 - AB[partIndex].Item2;
                    int index = mantenList.BinarySearch(addScore);

                    if (index < 0)
                    {
                        index = ~index;
                    }

                    mantenList.Insert(index, addScore);

                    partIndex++;
                }
                else
                {
                    answer += (long)mantenAddScore;
                    mantenList.RemoveAt(mantenList.Count - 1);
                }
            }

            Console.WriteLine(answer);
        }
    }
}
