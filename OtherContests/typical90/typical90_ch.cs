namespace AtCoderCsharp.OtherContests.typical90
{
    //  086 - Snuke's Favorite Arrays（★5） 

    internal class typical90_ch
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[] x = new int[Q+1];
            int[] y = new int[Q+1];
            int[] z = new int[Q+1];
            long[] w = new long[Q+1];

            // 右からiビット目(2^i桁目)を取り出す
            int[,] wbits = new int[Q + 1, 61];

            for (int i = 1; i <= Q; i++)
            {
                long[] xyzw = ReadLongArray();
                x[i] = (int)xyzw[0];
                y[i] = (int)xyzw[1];
                z[i] = (int)xyzw[2];
                w[i] = xyzw[3];

                int[] wb = GetBitsLong(w[i], 60);
                for (int j = 1; j <= 60; j++)
                {
                    wbits[i, j] = wb[j];
                }
            }

            long[] patternCount = new long[61];

            for (int digit = 1; digit <= 60; digit++)
            {
                //2進数の各桁ごとに、条件を満たすパターン数を求める

                int count = 0;
                for(int bits = 0; bits < (1 << N); bits++)
                {
                    // Aの桁digitのパターンを列挙し、条件を満たすかどうかを判定する
                    int[] bitsPattern = GetBits(bits, 60);

                    bool isOk = true;
                    for (int q = 1; q <= Q; ++q)
                    {
                        int orValue = bitsPattern[x[q]] | bitsPattern[y[q]] | bitsPattern[z[q]];
                        if (orValue != wbits[q, digit])
                        {
                            isOk = false;
                            break;
                        }
                    }

                    if (isOk)
                    {
                        count++;
                    }
                }

                patternCount[digit] = count;
            }

            long answer = 1L;
            for (int digit = 1; digit <= 60; digit++)
            {
                answer = answer * patternCount[digit] % 1000000007L;
            }

            Console.WriteLine(answer);

            int[] GetBits(int value, int digit)
            {
                int[] bits = new int[digit+1];

                for (int i = 1; i <= digit; i++)
                {
                    bits[i] = value % 2;
                    value /= 2;
                }

                return bits;
            }

            int[] GetBitsLong(long value, int digit)
            {
                int[] bits = new int[digit + 1];

                for (int i = 1; i <= digit; i++)
                {
                    bits[i] = (int) (value % 2L);
                    value /= 2L;
                }

                return bits;
            }

        }
    }
}
