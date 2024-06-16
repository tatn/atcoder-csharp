namespace AtCoderCsharp.AGC.AGC
{
    internal class agc037_a
    {
        public static void Main(string[] args)
        {
            char[] s = Console.ReadLine()!.ToCharArray();
            int n = s.Length;

            if (n <= 1)
            {
                Console.WriteLine(1);
                return;
            }

            if (n == 2)
            {
                Console.WriteLine(s[0] == s[1] ? 1 : 2);
                return;
            }

            int[] dp = new int[n + 1];

            dp[0] = 0;
            dp[1] = 1;
            dp[2] = s[0] == s[1] ? 1 : 2;

            for (int i = 3; i <= n; i++)
            {
                if (s[i - 2] == s[i - 1])
                {
                    dp[i] = dp[i - 3] + 2;
                }
                else
                {
                    dp[i] = dp[i - 1] + 1;
                }
            }


            Console.WriteLine(dp[n]);

        }

        public void Main()
        {
            char[] s = Console.ReadLine()!.ToCharArray();
            int n = s.Length;

            if (n <= 1)
            {
                Console.WriteLine(1);
                return;
            }

            if (n == 2)
            {
                Console.WriteLine(s[0] == s[1] ? 1 : 2);
                return;
            }

            int[] dp = new int[n+1];

            dp[0] = 0;
            dp[1] = 1;
            dp[2] = s[0] == s[1] ? 1 : 2;

            for (int i = 3; i <= n; i++)
            {
                if (s[i - 2] == s[i-1])
                {
                    // 前の文字と連続している場合 xa <- a

                    if (s[i-3] == s[i - 2])
                    {
                        // yaa <- a
                        dp[i] = dp[i - 2] + 1;

                    }
                    else
                    {
                        // yba <- a
                        // y|b|a   yb|a  に aを増やした場合 
                        dp[i] = dp[i - 1];
                    }



                    int prevDiff = dp[i-1] - dp[i-2];

                    if(prevDiff == 0)
                    {
                        //　前の文字が連続している場合 yaa <- a
                        dp[i] = dp[i - 3] + 2;

                    }
                    else
                    {
                        dp[i] = dp[i - 3] + 2;
                    }

                }
                else
                {
                    // 前の文字が連続していない場合 xa <- b
                    dp[i] = dp[i - 1] + 1;
                }
            }


            Console.WriteLine(dp[n]);

        }
    }
}
