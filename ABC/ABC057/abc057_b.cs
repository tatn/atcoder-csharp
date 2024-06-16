namespace AtCoderCsharp.ABC.ABC057
{
    internal class abc057_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] a = new int[N];
            int[] b = new int[N];
            for (int i = 0; i < N; i++)
            {
                int[] abInput = ReadIntArray();
                a[i] = abInput[0];
                b[i] = abInput[1];

            }

            int[] c = new int[M];
            int[] d = new int[M];
            for (int i = 0; i < M; i++)
            {
                int[] cdInput = ReadIntArray();
                c[i] = cdInput[0];
                d[i] = cdInput[1];
            }

            int[] answer = new int[N];

            for(int i = 0;i < N; i++)
            {
                int distance = 2_0000_0001;

                for (int j = 0; j < M; j++)
                {
                    int newDistance = Math.Abs(a[i] - c[j]) + Math.Abs(b[i] - d[j]);

                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        answer[i] = j;
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(answer[i]+1);
            }

        }
    }
}
