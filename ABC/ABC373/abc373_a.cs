namespace AtCoderCsharp.ABC.ABC373
{
    // A - September
    internal class abc373_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            int answer = 0;
            for (int i = 1; i <= 12; i++)
            {
                string s = ReadString();
                if (s.Length == i)
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
