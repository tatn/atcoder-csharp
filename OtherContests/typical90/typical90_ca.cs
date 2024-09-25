namespace AtCoderCsharp.OtherContests.typical90
{
    // 079 - Two by Two（★3）  ToDo

    internal class typical90_ca
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            long[,] A = new long[H + 1, W + 1];
            long[,] B = new long[H + 1, W + 1];

            for (int i = 1; i <= H; i++)
            {
                long[] a = ReadLongArray();
                for (int j = 1; j <= W; j++)
                {
                    A[i, j] = a[j - 1];
                }
            }

            for (int i = 1; i <= H; i++)
            {
                long[] b = ReadLongArray();
                for (int j = 1; j <= W; j++)
                {
                    B[i, j] = b[j - 1];
                }
            }

            bool canMatch = true;
            long answer = 0L;
            for (int i = 1; i <= H-1; i++)
            {
                for (int j = 1; j <= W-1; j++)
                {
                    if (A[i,j] == B[i, j])
                    {
                        continue;
                    }

                    long diff = B[i, j] - A[i, j];

                    answer += Math.Abs(diff);
                    A[i, j] += diff;
                    A[i + 1, j] += diff;
                    A[i, j + 1] += diff;
                    A[i + 1, j + 1] += diff;
                }

                if (A[i,W] != B[i, W])
                {
                    canMatch = false;
                    break;              
                }
            }

            for (int j = 1; j <= W; j++)
            {
                if (A[H, j] != B[H, j])
                {
                    canMatch = false;
                    break;
                }
            }

            if (canMatch)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine("No");
            }





        }
    }
}
