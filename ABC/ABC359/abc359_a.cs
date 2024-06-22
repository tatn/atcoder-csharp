namespace AtCoderCsharp.ABC.ABC359
{
    internal class abc359_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            int answer = 0;
            for (int i = 0; i < N; i++)
            {
                string S = ReadString();

                if(S == "Takahashi")
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
