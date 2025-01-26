using System.Numerics;

namespace AtCoderCsharp.ABC.ABC390
{
    internal class abc390_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] A = ReadIntArray();

            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i +1; j < A.Length; j++)
                {
                    if(A[i] > A[j])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count == 1 ? "Yes" : "No");

        }
    }
}
