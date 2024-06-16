using System.Numerics;

namespace AtCoderCsharp.ABC.ABC131
{
    internal class abc131_c
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] ABCD = ReadLongArray();
            long A = ABCD[0];
            long B = ABCD[1];
            long C = ABCD[2];
            long D = ABCD[3];


            long numberOfDivisorsOfC_UnderAMinusOne = (A-1) / C;
            long numberOfDivisorsOfC_UnderB = B / C;

            long numberOfDivisorsOfD_UnderAMinusOne = (A - 1) / D;
            long numberOfDivisorsOfD_UnderB = B / D;

            long lcmOfCAndD = GetLCM(C, D);

            long numberOfDivisorsOfLCM_UnderAMinusOne = (A - 1) / lcmOfCAndD;
            long numberOfDivisorsOfLCM_UnderB = B / lcmOfCAndD;

            long numberOfUnderAMinusOne = (A - 1) - (numberOfDivisorsOfC_UnderAMinusOne + numberOfDivisorsOfD_UnderAMinusOne - numberOfDivisorsOfLCM_UnderAMinusOne);
            long numberOfUnderB = B - (numberOfDivisorsOfC_UnderB + numberOfDivisorsOfD_UnderB - numberOfDivisorsOfLCM_UnderB);

            Console.WriteLine(numberOfUnderB- numberOfUnderAMinusOne);

        }

        static long GetGCD(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }

            return GetGCD(b, a % b);
        }

        static long GetLCM(long a, long b)
        {
            long gcd = GetGCD(a, b);
            return a * b / gcd;
        }
    }
}
