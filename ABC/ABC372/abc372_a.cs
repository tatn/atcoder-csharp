namespace AtCoderCsharp.ABC.ABC372
{
    // 	
    internal class abc372_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            string S = ReadString();

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] != '.')
                {
                    Console.Write(S[i]);
                }
            }
            Console.WriteLine();

        }
    }
}
