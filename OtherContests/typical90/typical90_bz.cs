namespace AtCoderCsharp.OtherContests.typical90
{
    // 078 - Easy Graph Problem（★2） 

    internal class typical90_bz
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] a = new int[M + 1];
            int[] b = new int[M + 1];

            List<int>[] G = new List<int>[N + 1];
            for (int i = 1; i <= N; i++)
            {
                G[i] = new List<int>();
            }

            for (int i = 1; i <= M; i++)
            {
                int[] ab = ReadIntArray();
                a[i] = ab[0];
                b[i] = ab[1];

                G[a[i]].Add(b[i]);
                G[b[i]].Add(a[i]);
            }

            for (int i = 1; i <= N; i++)
            {
                G[i].Sort();
            }

            int answer = 0;


            for (int i = 1; i <= N; i++)
            {
                int index = G[i].BinarySearch(i);
                if(~index == 1)
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);

        }
    }
}
