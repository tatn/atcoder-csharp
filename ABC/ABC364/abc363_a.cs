using System.Numerics;
namespace AtCoderCsharp.ABC.ABC364
{
    internal class abc364_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            string[] S = new string[N];
            for (int i = 0; i < N; i++)
            {

                S[i] = ReadString();
            }

            string prevString = string.Empty;

            bool canEatAll = true;
            for (int i = 0; i < N; i++)
            {
                string s = S[i];

                if (s == "sweet")
                {
                    if (prevString == "sweet" && i != N - 1)
                    {
                        canEatAll = false;
                    }
                }

                prevString = s;
            }

            Console.WriteLine(canEatAll ? "Yes" : "No");
        }
    }
}
