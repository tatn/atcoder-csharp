namespace AtCoderCsharp.OtherContests.code_festival_2016_quala
{
    internal class codefestival_2016_qualA_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] a = ReadIntArray();


            int answer = 0;
            for (int i = 0; i < N; i++)
            {
                if (a[i] == -1)
                {
                    continue;
                }

                if (a[a[i]-1] == i+1)
                {
                    answer++;
                    a[a[i] - 1] = -1;
                }
            }

            Console.WriteLine(answer);
        }

    }
}
