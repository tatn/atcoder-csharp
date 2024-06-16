namespace AtCoderCsharp.ABC.ABC150
{
    internal class abc150_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string ReadString() => Console.ReadLine()!;

            int N = ReadInt();
            string S = ReadString();

            int index = S.IndexOf("ABC");

            int answer = 0;
            while (-1 < index)
            {
                answer++;
                index = S.IndexOf("ABC", index + 3);
            }

            Console.WriteLine(answer);


        }
    }
}
