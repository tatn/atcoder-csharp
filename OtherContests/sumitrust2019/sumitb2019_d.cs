namespace AtCoderCsharp.OtherContests.sumitrust2019
{
    internal class sumitb2019_d
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string ReadString() => Console.ReadLine()!;

            int N = ReadInt();
            string S = ReadString();

            int[] dp1 = new int[10];
            int[,] dp2 = new int[10, 10];
            int[,,] dp3 = new int[10, 10, 10];

            for (int i = 0; i < 10; i++)
            {
                dp1[i] = S.IndexOf(i.ToString().First());
            }

            for (int i = 0; i < 10; i++)
            {
                if (dp1[i] < 0)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        dp2[i, j] = -1;
                    }
                }
                else
                {
                    for (int j = 0; j < 10; j++)
                    {
                        dp2[i, j] = S.IndexOf(j.ToString().First(), dp1[i] + 1);
                    }
                }

            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (dp2[i,j] < 0)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            dp3[i, j, k] = -1;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            dp3[i, j, k] = S.IndexOf(k.ToString().First(), dp2[i,j] + 1);
                        }
                    }

                }
            }

            int answer = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if(dp3[i, j, k] != -1)
                        {
                            answer++;
                        }
                    }
                }
            }

            Console.WriteLine(answer);
            

        }
    }
}
