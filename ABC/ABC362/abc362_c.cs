namespace AtCoderCsharp.ABC.ABC362
{
    internal class abc362_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();
            long[] L = new long[N];
            long[] R = new long[N];

            long minSum = 0L;
            long maxSum = 0L;

            for (int i = 0; i < N; i++)
            {
                long[] LR = ReadLongArray();
                L[i] = LR[0];
                R[i] = LR[1];
                minSum += L[i];
                maxSum += R[i];
            }

            if(minSum <= 0L && 0L <= maxSum)
            {
                Console.WriteLine("Yes");

                if (minSum == 0L)
                {
                    Console.WriteLine(string.Join(" ",L));
                }
                else if (maxSum == 0L)
                {
                    Console.WriteLine(string.Join(" ", R));
                }
                else
                {
                    long remain = 0L - minSum;
                    long[] X = new long[N];

                    for (int i = 0; i < N; i++)
                    {
                        X[i] = L[i];

                        long width = R[i] -L[i];

                        if(width <= remain)
                        {
                            X[i] = X[i] + width;
                            remain = remain - width;
                        }
                        else
                        {
                            X[i] = X[i] + remain;
                            remain = 0;
                        }
                    }

                    Console.WriteLine(string.Join(" ", X));
                }


            }
            else
            {
                Console.WriteLine("No");

            }
        }
    }
}
