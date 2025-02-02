using System.Numerics;

namespace AtCoderCsharp.ABC.ABC391
{
    internal class abc391_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            string D = ReadString();

            for (int i = 0; i < D.Length; i++)
            {
                switch (D[i])
                {
                    case 'N':
                        Console.Write('S');
                        break;
                    case 'S':
                        Console.Write('N');
                        break;
                    case 'W':
                        Console.Write('E');
                        break;
                    case 'E':
                        Console.Write('W');
                        break;
                }
            }

            Console.WriteLine();

        }
    }
}
