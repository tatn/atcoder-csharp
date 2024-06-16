namespace AtCoderCsharp.ABC.ABC060
{
    internal class abc060_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int[] ABC = ReadIntArray();
            int A = ABC[0];
            int B = ABC[1];
            int C = ABC[2];

            if(A == 1)
            {
                // 1, 2, 3, ... ,
                // 任意の数字を選べるのでCを選択すればよい
                Console.WriteLine("YES");
                return;
            }

            if(B == 1)
            {
                // A, 2A, 3A, ... ,
                // 1で割ると必ず余り0のため、C=0の場合のみ選択可能
                Console.WriteLine(C == 0 ? "YES" : "NO");
                return;                
            }

            if (A == B)
            {
                // 余り0のため、C=0の場合のみ選択可能
                Console.WriteLine(C == 0 ? "YES" : "NO");
                return;
            }

            if (A % B == 0)
            {
                // 余り0のため、C=0の場合のみ選択可能
                Console.WriteLine(C == 0 ? "YES" : "NO");
                return;
            }

            if (B % A == 0)
            {
                // A = 6 , B = 30
                // 6, 12, 18, 24, 30, 36, ...
                // B=30で割ると
                // 6, 12, 18, 24, 0, 6, ...

                // CがB未満のAの倍数であればよい

                Console.WriteLine(C % A == 0 && C < B ? "YES" : "NO");
                return;
            }

            int gcd = GetGCD(A, B);

            if (gcd == 1)
            {
                // A = 5, B = 7
                // 5, 10, 15, 20, 25, 30, 35, 40
                // B=7で割ると
                // 5, 3, 1, 6, 4, 2, 0, 5, ...

                // CがB未満であればよい (A > Bでも同様)

                Console.WriteLine(C < B ? "YES" : "NO");
                return;
            }
            else
            {
                // A = 6, B = 10
                // 6, 12, 18, 24, 30, 36, ...
                // B=10で割ると
                // 6, 2, 8, 4, 0, 6, ...

                // CがB未満で最大公約で割り切れればよい (A > Bでも同様)
                Console.WriteLine(C % gcd == 0 && C < B ? "YES" : "NO");

            }

        }

        public static int GetGCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return GetGCD(b, a % b);
        }

    }
}
