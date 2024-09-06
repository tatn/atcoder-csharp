using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_cq
    {

        //B18 - Subset Sum with Restoration

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
            canCalculate[0, 0] = true;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= S; j++)
                {
                    canCalculate[i, j] = canCalculate[i - 1, j] || (0 <= j - A[i] && canCalculate[i - 1, j - A[i]]);
                }
            }

            if(canCalculate[N, S])
            {
                List<int> cards = new List<int>();
                int currentSum = S;

                for (int i = N; 1<=i ; i--)
                {
                    if (canCalculate[i,currentSum])
                    {
                        if(!canCalculate[i - 1, currentSum])
                        {
                            cards.Add(i);
                            currentSum -= A[i];
                        }
                    }

                }
                cards.Reverse();
                Console.WriteLine(cards.Count);
                Console.WriteLine(String.Join(" ", cards));

            }
            else
            {

                Console.WriteLine(-1);
            }
        }
    }
}
