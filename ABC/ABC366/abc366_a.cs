using System.Numerics;
namespace AtCoderCsharp.ABC.ABC366
{
    internal class abc366_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NTA = ReadIntArray();

            int N = NTA[0];
            int T = NTA[1];
            int A = NTA[2];

            if( N / 2 + 1 <= T || N / 2 + 1 <= A)
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
