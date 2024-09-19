using System.Collections.Specialized;

namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ak
    {
        // 037 - Don't Leave the Spice（★5） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] WN = ReadIntArray();
            int W = WN[0];
            int N = WN[1];

            int[] L = new int[N + 1];
            int[] R = new int[N + 1];
            int[] V = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] LRV = ReadIntArray();
                L[i] = LRV[0];
                R[i] = LRV[1];
                V[i] = LRV[2];
            }
        }
    }
}
