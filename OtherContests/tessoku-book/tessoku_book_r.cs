using System.Numerics;
using System.Runtime.Intrinsics.Arm;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_r
    {
        //A18 - Subset Sum

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NS = ReadIntArray();
            int N = NS[0];
            int S = NS[1];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            // canCalculate[i,j] i番目までのカードを作って、合計jを作れる場合 true
            bool[,] canCalculate = new bool[N + 1, S + 1];
            canCalculate[0,0] = true;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= S; j++)
                {
                    canCalculate[i, j] = canCalculate[i - 1, j] || (0 <= j - A[i] && canCalculate[i - 1, j - A[i]]);
                }
            }

            Console.WriteLine(canCalculate[N,S] ? "Yes" : "No");
        }
    }
}
