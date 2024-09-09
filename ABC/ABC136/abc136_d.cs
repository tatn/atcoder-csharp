namespace AtCoderCsharp.ABC.ABC136
{
    internal class abc136_d
    {
        // D - Gathering Children 
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string S = ReadString();
            int N = S.Length;

            // dp[i,j] jの位置にいた子供が2^i回移動した後で位置
            // 2^17 = 131072 ≒ 1.3 * 10^5のため i=17まで計算する
            int[,] dp = new int[17+1,N+1];

            for (int i = 1; i <= N; i++)
            {
                dp[0, i] = S[i-1] == 'R' ? i + 1 : i - 1;
            }

            for (int i = 1; i <= 17; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    dp[i, j] = dp[i - 1, dp[i - 1, j]];
                }
            }

            int[] answer = new int[N+1];
            for (int i = 1; i <= N; i++)
            {
                answer[dp[17, i]]++;
            }

            for (int i = 1; i <= N; i++)
            {
                Console.Write(answer[i]);
                if(i != N)
                {
                    Console.Write(" ");
                }
            }

        }

        public static void Main2(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string S = ReadString();


            int[] rContinueCount = new int[S.Length];
            int countR = 0;

            for (int i = 0; i < S.Length - 1; i++)
            {
                char current = S[i];
                char next = S[i + 1];


                if(current == 'R')
                {
                    countR++;
                }
                else
                {
                    countR = 0;
                }

                if(current == 'R' && next == 'L')
                {
                    rContinueCount[i] = countR;
                }
                else
                {
                    rContinueCount[i] = 0;
                }
            }


            int[] lContinueCount = new int[S.Length];
            int countL = 0;

            for (int i = S.Length - 1; 0 < i; i--)
            {
                char current = S[i];
                char prev = S[i - 1];


                if (current == 'L')
                {
                    countL++;
                }
                else
                {
                    countL = 0;
                }

                if (current == 'L' && prev == 'R')
                {
                    lContinueCount[i] = countL;
                }
                else
                {
                    lContinueCount[i] = 0;
                }
            }

            int[] answer = new int[S.Length];

            for (int i = 0; i < S.Length - 1; i++)
            {
                int r = rContinueCount[i];

                if(r == 0)
                {
                    continue;
                }

                int l = lContinueCount[i + 1];

                int leftCount = ((r+1) / 2) + (l / 2);
                int rightCount = (r / 2) + ( (l+1) / 2);

                answer[i] = leftCount;
                answer[i + 1] = rightCount;
            }

            Console.WriteLine(String.Join(" ",answer));

        }
    }
}
