using static System.Formats.Asn1.AsnWriter;

namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_k
    {
        //011 - Gravy Jobs（★6） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] D = new int[N + 1];
            int[] C = new int[N + 1];
            int[] S = new int[N + 1];

            List<(int, int, int)> DCS = new List<(int, int, int)>();

            for (int i = 1; i <= N; i++)
            {
                int[] input = ReadIntArray();
                D[i] = input[0];
                C[i] = input[1];
                S[i] = input[2];
                DCS.Add((D[i], C[i], S[i]));
            }

            DCS.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            DCS.Insert(0, (0, 0, 0));

            // dp[i,j]  i日番目までの仕事を任意に選択した場合のj日目終了時の報酬の最大値
            long[,] dp = new long[N + 1, 5001];

            for (int i = 1; i <= N; i++)
            {
                (int deadline, int cost, int score) = DCS[i];

                for (int d = 0; d <= deadline; d++)
                {
                    dp[i, d ] = Math.Max(dp[i, d],dp[i - 1, d]);
                    if (d + cost <= deadline)
                    {
                        dp[i, d + cost] = Math.Max(dp[i, d + cost], dp[i - 1, d] + (long)score);
                    }
                }
            }

            long answer = 0L;
            for (int d = 0; d <= 5000; d++)
            {
                answer = Math.Max(answer, dp[N, d]);
            }

            Console.WriteLine(answer);
        }
    }
}
