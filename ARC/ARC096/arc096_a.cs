namespace AtCoderCsharp.ARC.ARC096
{
    internal class arc096_a
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();
            long[] longs = ReadLongArray();

            long A = longs[0];
            long B = longs[1];
            long C = longs[2];
            long X = longs[3];
            long Y = longs[4];

            long aAndBLowPrice = A + B;
            if ((long)2 * C < aAndBLowPrice)
            {
                aAndBLowPrice = (long)2 * C;
            }

            if (X < Y)
            {
                // X (A and B) and  Y - X (B)

                long bLowPrice = Math.Min(B, C * (long)2);


                Console.WriteLine(aAndBLowPrice * X + (Y - X)*bLowPrice );

            }
            else if (Y < X)
            {
                // Y (A and B) and  X - Y (A)

                long aLowPrice = Math.Min(A, C * (long)2);

                Console.WriteLine(aAndBLowPrice * Y + (X - Y) * aLowPrice);
            }
            else
            {
                // X == Y

                Console.WriteLine(aAndBLowPrice * X);
            }


        }
    }
}
