namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_t
    {
        // 020 - Log Inequality（★3） 
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] abc = ReadLongArray();
            long a = abc[0];
            long b = abc[1];
            long c = abc[2];

            long cPowerd = 1;

            for (int i = 1; i <= b; i++)
            {
                cPowerd *= c;
            }

            Console.WriteLine(a < cPowerd ? "Yes" : "No");
        }
    }
}
