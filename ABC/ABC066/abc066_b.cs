namespace AtCoderCsharp.ABC.ABC066
{
    internal class abc066_b
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string s = ReadString();

            for (int i = 1; i < s.Length / 2; i++)
            {
                bool isEvenString = true;

                for (int j = 0; j < (s.Length - 2 * i) / 2 ; j++)
                {
                    if (s[j] != s[j + (s.Length - 2 * i) / 2])
                    {
                        isEvenString = false;
                        break;
                    }
                }

                if (isEvenString)
                {
                    Console.WriteLine(s.Length - i * 2);
                    break;
                }
            }

        }
    }
}
