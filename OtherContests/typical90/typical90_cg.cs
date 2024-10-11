namespace AtCoderCsharp.OtherContests.typical90
{
    //  085 - Multiplication 085（★4） 

    internal class typical90_cg
    {
        public static void Main(string[] args)
        {
            long ReadLong() => long.Parse(Console.ReadLine()!);

            long K = ReadLong();

            long[] divisors = GetDivisors(K);
            long answer = 0;

            for (int i = 0; i < divisors.Length; i++)
            {
                for (int j = i; j< divisors.Length; j++)
                {
                    long temp = K / divisors[i];

                    if (temp % divisors[j] != 0)
                    {
                        continue;
                    }

                    long needNumber = temp / divisors[j];

                    if (needNumber == 0)
                    {
                        continue;
                    }

                    if (K % needNumber != 0)
                    {
                        continue;
                    }

                    if (divisors[j] <= needNumber)
                    {
                        answer++;
                    }
                }                
            }

            Console.WriteLine(answer);

            long[] GetDivisors(long x)
            {
                if (x == (long)1)
                {
                    return new long[] { (long)1 };
                }

                List<long> divisors = new List<long>();

                for (long i = 1; i * i <= x; i++)
                {
                    if (x % i == 0)
                    {
                        divisors.Add(i);
                        if (x / i != i)
                        {
                            divisors.Add(x / i);
                        }
                    }
                }

                divisors.Sort();

                return divisors.ToArray();
            }

        }
    }
}
