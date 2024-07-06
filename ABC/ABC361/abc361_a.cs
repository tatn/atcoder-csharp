using System.Numerics;
namespace AtCoderCsharp.ABC.ABC361
{
    internal class abc361_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NKX = ReadIntArray();
            int N = NKX[0];
            int K = NKX[1];
            int X = NKX[2];

            int[] A = ReadIntArray();

            List<int> B = A.ToList();

            B.Insert(K, X);

            Console.WriteLine(string.Join(" ",B));
        }
    }
}
