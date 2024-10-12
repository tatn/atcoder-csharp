using System.Numerics;

namespace AtCoderCsharp.ABC.ABC375
{
    // A - Seats
    internal class abc375_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            string S = ReadString();

            int answer = 0;
            for (int i = 1; i <= N-2; i++)
            {
                if (S[i - 1] == '#' && S[i + 1] == '#' && S[i] == '.')
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);

        }
    }
}
