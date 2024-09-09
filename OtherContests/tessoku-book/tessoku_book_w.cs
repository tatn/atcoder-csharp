
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_w
    {
        //A23 - All Free

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[,] A = new int[M+1, N+1];
            for (int i = 1; i <= M; i++)
            {
                int[] aInput = ReadIntArray();
                for (int j = 1; j <= N; j++)
                {
                    A[i,j] = aInput[j-1];
                }                
            }

            int max = 200;
            int[,] dp = new int[M + 1, 1 << N];
            for (int i = 0; i <= M; i++)
            {
                for (int j = 0;j < (1<<N); j++)
                {
                    dp[i, j] = max;
                }
            }
            dp[0, 0] = 0;

            for (int i = 0; i <= M - 1; i++)
            {
                for (int j = 0; j < (1 << N); j++)
                {
                    if (dp[i,j] == max)
                    {
                        continue;
                    }

                    //　クーポンi+1を使わない場合
                    dp[i + 1, j] = Math.Min(dp[i + 1, j], dp[i, j]);

                    // クーポンi+1を使う場合

                    // クーポンを対応するビットに変換
                    int coupon = 0;
                    for (int k = 1; k <= N; k++)
                    {
                        if (A[i+1,k] == 1)
                        {
                            coupon += 1 << (k - 1);
                        }
                    }

                    // 状態jでクーポンを使った後の状態nextを計算
                    int next = j | coupon;
                    next = next & ((1 << N) - 1);

                    // 状態nextに対して、クーポンi+1を使った場合のコストを計算
                    dp[i + 1, next] = Math.Min(dp[i + 1, next], dp[i, j] + 1);
                }
            }

            int answer = dp[M, (1 << N) - 1];
            Console.WriteLine(answer == max ? -1 : answer);
        }
    }
}
