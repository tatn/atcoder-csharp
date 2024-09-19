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

            for (int i = 1; i <= N; i++)
            {
                int[] xy = ReadIntArray();
                X[i] = xy[0];
                Y[i] = xy[1];
                
            }

            int[] q = new int[Q+1];
            for (int i = 1; i <= Q; i++)
            {
                q[i] = ReadInt();
            }

        }
    }
}
