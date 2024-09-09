
using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_cv
    {
        //B23 - Traveling Salesman Problem 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] X = new int[N + 1];
            int[] Y = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] xy = ReadIntArray();
                X[i] = xy[0];
                Y[i] = xy[1];
            }

            double max = 100_000d;

            // dp[i,j] = 都市i(ビット)を通った状態で都市jにいるときの最短距離
            double[,] dp = new double[1 << N, N + 1];
            for (int i = 0; i < (1 << N); i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    dp[i, j] = max;
                }
            }

            //都市1からスタート
            dp[1,1] = 0d;

            for (int cityCount = 1; cityCount <= N-1; cityCount++)
            {
                //通過した都市の件数cityCountでループ

                for (int i = 1; i < (1 << N); i++)
                {

                    // 都市i(ビット)を経過した状態

                    for (int j = 1; j <= N; j++)
                    {
                        // 都市i(ビット)を経過した状態で都市jにいる

                        if (max <= dp[i, j])
                        {
                            continue;
                        }

                        // 都市の件数がcityCountの場合、都市jから次の都市に移動する
                        int bitCount = BitOperations.PopCount((uint)i);
                        if (bitCount != cityCount)
                        {
                            continue;
                        }

                        //都市kに移動した場合のコストを計算
                        for (int k = 2; k <= N; k++)
                        {
                            if ((i & (1 << (k - 1))) != 0)
                            {
                                //すでに都市kを通過している場合
                                continue;
                            }

                            int nextState = i + (1 << (k - 1));
                            double distance = Math.Sqrt( (X[j] - X[k])*(X[j] - X[k]) + (Y[j] - Y[k])* (Y[j] - Y[k]));   
                            dp[nextState, k] = Math.Min(dp[nextState, k], dp[i, j] + distance);
                        }
                    }
                }
            }

            double answer = max;
            for (int i = 2; i <= N; i++)
            {
                double distance = Math.Sqrt((X[i] - X[1]) * (X[i] - X[1]) + (Y[i] - Y[1]) * (Y[i] - Y[1]));
                answer = Math.Min(answer, dp[(1 << N) - 1, i] + distance);
            }

            Console.WriteLine(answer);
        }
    }
}
