namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_al
    {
        // 038 - Large LCM（★3） 
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] AB = ReadLongArray();
            long A = AB[0];
            long B = AB[1];

            long gcd = GetGCD(A, B);

            double logValue = Math.Log10(A) + Math.Log10(B) - Math.Log10(gcd);

            if (logValue <= 18.9)
            {
                long lcm = (A / gcd) * B;

                if (1_000_000_000_000_000_000 < lcm)
                {
                    Console.WriteLine("Large");
                }
                else
                {
                    Console.WriteLine(lcm);
                }

            }
            else
            {
                Console.WriteLine("Large");
            }


            long GetGCD(long a, long b)
            {
                if (b == 0)
                {
                    return a;
                }

                return GetGCD(b, a % b);
            }


        }
    }
}
