using System.Numerics;

namespace AtCoderCsharp.ABC.ABC357
{
    internal class abc357_d
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string s = ReadString();

            BigInteger N = BigInteger.Parse(s);
            BigInteger l = s.Length;

            BigInteger m = (BigInteger)998244353;

            //long Vn = N * ((long)Math.Pow(10, l * N) - 1) / ((long)Math.Pow(10, l) - 1);

            //BigInteger pow10_ln = BigInteger.ModPow((BigInteger)10, l * N, m);
            BigInteger pow10_ln = GetModPow((BigInteger)10, l * N, m);
            BigInteger pow10_ln_minus1 = pow10_ln - BigInteger.One;
            if (pow10_ln_minus1 < BigInteger.Zero)
            {
                pow10_ln_minus1 += m;
            }

            //BigInteger pow10_l_minus1 = BigInteger.ModPow(10, l, m) - BigInteger.One;
            BigInteger pow10_l_minus1 = GetModPow(10, l, m) - BigInteger.One;
            if (pow10_l_minus1 < BigInteger.Zero)
            {
                pow10_l_minus1 += m;
            }

            //BigInteger powDivided = BigInteger.ModPow(pow10_l_minus1, m - 2, m);
            BigInteger powDivided = GetModPow(pow10_l_minus1, m - 2, m);

            BigInteger Vn = N % m;
            Vn = (Vn * pow10_ln_minus1) % m;
            Vn = (Vn * powDivided) % m;

            Console.WriteLine(Vn);
        }

        //## フェルマーの小定理
        //M:素数、bをMで割り切れない整数とするとき、
        //Mで割った余りを求めたいとき「÷b」と「×b^(M-2)」は等価

        public static BigInteger GetModPow(BigInteger b, BigInteger exponent, BigInteger m)
        {
            if (b == BigInteger.One)
            {
                return BigInteger.One;
            }

            if (exponent == BigInteger.Zero)
            {
                return BigInteger.One;
            }

            BigInteger bitNumber = BigInteger.Log2(exponent) + (BigInteger)2;

            BigInteger answer = BigInteger.One;
            BigInteger power = b;
            BigInteger exponentWork = exponent;
            for (BigInteger i = 0; i < bitNumber; i++)
            {
                if (exponentWork % (BigInteger)2 == BigInteger.One)
                {
                    answer = (answer * power) % m;
                }
                power = (power * power) % m;

                exponentWork = exponentWork / (BigInteger)2;

                if (exponentWork == BigInteger.Zero)
                {
                    break;
                }
            }

            return answer;
        }


    }
}
