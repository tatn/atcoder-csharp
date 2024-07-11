namespace AtCoderCsharp.AGC.AGC031
{
    internal class agc031_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            string S = ReadString();

            long[] charCount = new long['z' - 'a' + 1];

            foreach (char c in S)
            {
                charCount[c - 'a'] += 1L;
            }

            long mode = 1_000_000_000L + 7L;

            long answer = 1;

            foreach (long count in charCount.Where(x => 0 < x))
            {
                answer *= (count + 1L);
                answer %= mode;
            }

            Console.WriteLine(answer-1L);
        }

    }
}
