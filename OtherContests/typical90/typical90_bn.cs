namespace AtCoderCsharp.OtherContests.typical90
{
    // 066 - Various Arrays（★5） 

    internal class typical90_bn
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] L = new int[N + 1];
            int[] R = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] LR = ReadIntArray();
                L[i] = LR[0];
                R[i] = LR[1];
            }

            double answer = 0.0d;
            for (int i = 1; i <= N; i++)
            {
                int patternCountOfi = R[i] - L[i] + 1;

                for (int j = i+1; j <= N; j++)
                {
                    int patternCountOfj = R[j] - L[j] + 1;

                    int patternCount = 0;
                    if (L[j] < R[i])
                    {
                        for (int k = Math.Max(L[j] + 1,L[i]); k <= R[i]; k++)
                        {
                            for(int l = L[j]; l <= R[j]; l++)
                            {
                                if (k > l)
                                {
                                    patternCount++;
                                }

                            }

                        }
                    }

                    answer += (double)patternCount / ((double)patternCountOfi * (double)patternCountOfj);

                }
            }

            Console.WriteLine(answer);
        }

    }
}
