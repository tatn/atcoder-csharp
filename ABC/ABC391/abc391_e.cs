using System.Numerics;

namespace AtCoderCsharp.ABC.ABC391
{
    internal class abc391_e
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            string S = ReadString();

            int pow3n = (int)BigInteger.Pow(3, N);

            // AOpreted[i, j] = i(i=0,1,...,N)回操作後、j(j=1,2,...,3^(N-i))番目の文字
            int[,] AOpreted = new int[N + 1, pow3n + 1];

            int[] A = new int[pow3n + 1];
            for (int i = 1; i <= pow3n; i++)
            {
                A[i] = S[i - 1] == '0' ? 0 : 1;
                AOpreted[0, i] = A[i];
            }

            for (int i = 1; i <= N ; i++)
            {
                for (int j = 1; j <= (int)BigInteger.Pow(3, N-i); j++)
                {
                    int zeroCount = 0;
                    int oneCount = 0;

                    for (int k = 0; k <= 2; k++)
                    {

                        if (AOpreted[i - 1, 3 * j - k] == 1)
                        {
                            oneCount++;
                        }
                        else
                        {
                            zeroCount++;
                        }
                    }

                    AOpreted[i,j] = zeroCount < oneCount ?  1 : 0;
                }
            }

            // dp[i, j, k] = i(i=0,1,...,N)回操作後、j(j=1,2,...,3^(N-i))番目の文字をk(k=0,1)にするための最小の変更回数
            int[,,] dp = new int[N + 1, pow3n + 1, 2];

            // i=0のとき
            for (int j = 1; j <= pow3n; j++)
            {
                dp[0, j, 0] = AOpreted[0, j] == 0 ? 0 : 1;
                dp[0, j, 1] = AOpreted[0, j] == 1 ? 0 : 1;
            }

            // i=1,2,...,Nのとき
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= (int)BigInteger.Pow(3, N - i); j++)
                {
                    for(int k = 0; k <= 1; k++)
                    {
                        if(k == AOpreted[i, j])
                        {
                            dp[i, j, k] = 0;
                        }
                        else
                        {
                            int costSum = 0;
                            int maxCost = 0;
                            for(int m = 0; m <= 2; m++)
                            {
                                costSum += dp[i - 1, 3 * j - m, k];
                                maxCost = Math.Max(maxCost, dp[i - 1, 3 * j - m, k]);
                            }

                            dp[i, j, k] = costSum - maxCost;
                        }
                    }
                }
            }

            int aValue = AOpreted[N, 1];
            int changeValue = aValue == 0 ? 1 : 0;

            Console.WriteLine(dp[N,1,changeValue]);

        }
    }
}
