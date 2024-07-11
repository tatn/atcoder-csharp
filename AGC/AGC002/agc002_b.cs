namespace AtCoderCsharp.AGC.AGC002
{
    internal class agc002_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] x = new int[M];
            int[] y = new int[M];
            for (int i = 0; i < M; i++)
            {
                int[] xy = ReadIntArray();
                x[i] = xy[0];
                y[i] = xy[1];
            }

            bool[] isPossibilityRed = new bool[N];
            isPossibilityRed[0] = true;

            int[] countBall = new int[N];
            Array.Fill(countBall, 1);

            for (int i = 0; i < M; i++)
            {
                if (isPossibilityRed[x[i]-1])
                {
                    isPossibilityRed[y[i]-1] = true;

                    if(countBall[x[i] - 1] == 1)
                    {
                        isPossibilityRed[x[i] - 1] = false;
                    }
                }

                countBall[x[i] - 1]--;
                countBall[y[i] - 1]++;
            }

            Console.WriteLine(isPossibilityRed.Where(x => x).Count());

        }
    }
}
