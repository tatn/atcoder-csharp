using System.Runtime.Intrinsics.Arm;

namespace AtCoderCsharp.OtherContests.typical90
{
    // 075 - Magic For Balls（★3） 

    internal class typical90_bw
    {
        public static void Main(string[] args)
        {
            long ReadLong() => long.Parse(Console.ReadLine()!);

            long N = ReadLong();

            long target = N;
            List<long> divisors = new List<long>();

            while (true)
            {
                bool found = false;
                for (int i = 2; i <= Math.Sqrt(target)+1; i++)
                {
                    if(target % i == 0)
                    {
                        divisors.Add(i);
                        target /= i;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    continue;
                }

                if(target != 1)
                {
                    divisors.Add(target);
                }
                break;
            }

            //Console.WriteLine(string.Join(" ", divisors));

            // 2^40 = 1.0e+12
            int[] dp = new int[41];
            for (int i = 2; i <= 40; i++)
            {
                dp[i] = Math.Max(dp[i / 2], dp[i - i / 2]) + 1;
            }

            Console.WriteLine(dp[divisors.Count]);

        }
    }
}
