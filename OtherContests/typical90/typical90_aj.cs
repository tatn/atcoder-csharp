namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_aj
    {
        // 036 - Max Manhattan Distance（★5） ToDo
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[] X = new int[N+1];
            int[] Y = new int[N+1];
            int[] newX = new int[N + 1];
            int[] newY = new int[N + 1];

            int minX = int.MaxValue;
            int maxX = int.MinValue;
            int minY = int.MaxValue;
            int maxY = int.MinValue;

            for (int i = 1; i <= N; i++)
            {
                int[] xy = ReadIntArray();
                X[i] = xy[0];
                Y[i] = xy[1];

                newX[i] = X[i] + Y[i];
                newY[i] = X[i] - Y[i];   
                
                minX = Math.Min(minX, newX[i]);
                maxX = Math.Max(maxX, newX[i]);
                minY = Math.Min(minY, newY[i]);
                maxY = Math.Max(maxY, newY[i]);
            }

            int[] q = new int[Q+1];
            for (int i = 1; i <= Q; i++)
            {
                q[i] = ReadInt();
            }

            for (int i = 1; i <= Q; i++)
            {
                long answer1 = Math.Abs((long)minX - (long)newX[q[i]]);
                long answer2 = Math.Abs((long)maxX - (long)newX[q[i]]);
                long answer3 = Math.Abs((long)minY - (long)newY[q[i]]);
                long answer4 = Math.Abs((long)maxY - (long)newY[q[i]]);

                long answer = Math.Max(Math.Max(answer1, answer2), Math.Max(answer3, answer4));
                Console.WriteLine(answer);
            }

        }
    }
}
