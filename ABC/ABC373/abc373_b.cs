using System;

namespace AtCoderCsharp.ABC.ABC373
{
    // B - 1D Keyboard
    internal class abc373_b
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            string S = ReadString();

            char A = 'A';
            int indexPrev = S.IndexOf(A);

            int answer = 0;

            for (int i = 1; i < 26; i++)
            {
                char c = (char)(A + i);

                int index = S.IndexOf(c);
                answer += Math.Abs(index - indexPrev);
                indexPrev = index;
            }

            Console.WriteLine(answer);
        }
    }
}
