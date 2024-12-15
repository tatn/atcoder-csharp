using System.Numerics;

namespace AtCoderCsharp.ABC.ABC384
{
    internal class abc384_a
    {
        public static void Main(string[] args)
        {

            string ReadString() => Console.ReadLine()!;
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            string[] Nc1c2 = ReadStringArray();
            int N = int.Parse(Nc1c2[0]);
            string c1 = Nc1c2[1];
            string c2 = Nc1c2[2];

            string S = ReadString();

            
            foreach(char c in S)
            {
                if (c.ToString() == c1)
                {
                    Console.Write(c);
                }
                else
                {
                    Console.Write(c2);
                }

            }
        }
    }
}
