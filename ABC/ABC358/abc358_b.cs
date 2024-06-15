namespace AtCoderCsharp.ABC.ABC358
{
    internal class abc358_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NA = ReadIntArray();
            int N = NA[0];
            int A = NA[1];

            int[] T = ReadIntArray();

            int[] answer = new int[N];
            answer[0] = T[0] + A;
            for (int i = 1; i < N; i++)
            {
                answer[i] = Math.Max(answer[i - 1], T[i]) + A;
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(answer[i]);
            }

        }
    }
}
