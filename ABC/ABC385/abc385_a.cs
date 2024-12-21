using System.Numerics;

namespace AtCoderCsharp.ABC.ABC385
{
    internal class abc385_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] ABC = ReadIntArray();
            int A = ABC[0];
            int B = ABC[1];
            int C = ABC[2];

            if (A + B == C || B + C == A || C + A == B)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                if (A == B && B == C)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }

            }


        }
    }
}
