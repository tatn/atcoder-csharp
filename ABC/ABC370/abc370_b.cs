using System.Numerics;
namespace AtCoderCsharp.ABC.ABC370
{
    internal class abc370_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[,] A = new int[N + 1, N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] aInput = ReadIntArray();

                for (int j = 1; j <= i; j++)
                {
                    A[i, j] = aInput[j - 1];
                }
            }

            int target = 1;
            for (int i = 1; i <= N; i++)
            {
                if (target >= i)
                {
                    target = A[target, i];
                }
                else
                {
                    target = A[i, target];
                }
            }

            Console.WriteLine(target);
        }
    }
}
