namespace AtCoderCsharp.OtherContests.typical90
{
    // 070 - Plant Planning（★4） ToDo

    internal class typical90_br
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] X = new int[N + 1];
            int[] Y = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] xy = ReadIntArray();
                X[i] = xy[0];
                Y[i] = xy[1];

            }





        }

    }
}
