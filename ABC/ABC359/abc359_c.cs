namespace AtCoderCsharp.ABC.ABC359
{
    internal class abc359_c
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] S = ReadLongArray();
            long[] T = ReadLongArray();

            bool SIsLeftBlock = (S[0] + S[1]) % 2L == 0L;
            long[] SLeftBlockPosition = SIsLeftBlock ? S : new long[2] { S[0]- 1L, S[1]};

            bool TIsLeftBlock = (T[0] + T[1]) % 2L == 0L;
            long[] TLeftBlockPosition = TIsLeftBlock ? T : new long[2] { T[0] - 1L, T[1] };

            long XLength = Math.Abs(SLeftBlockPosition[0] - TLeftBlockPosition[0]) + Math.Abs(SLeftBlockPosition[1] - TLeftBlockPosition[1]);

            long YLength = Math.Abs(S[1] - T[1]);

            long answer = Math.Max(XLength/2, YLength);


            Console.WriteLine(answer);
        }
    }
}
