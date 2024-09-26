namespace AtCoderCsharp.ABC.ABC048
{
    // AtCoder Beginner Contest 048
    // B - Between a and b ... 
    internal class abc048_b
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] abx = ReadLongArray();
            long a = abx[0];
            long b = abx[1];
            long x = abx[2];

            long bCount = b / x;

            if(a == 0)
            {
                Console.WriteLine(bCount+1);
            }
            else
            {
                long aCount = (a - 1) / x;
                Console.WriteLine(bCount - aCount);
            }
        }
    }
}
