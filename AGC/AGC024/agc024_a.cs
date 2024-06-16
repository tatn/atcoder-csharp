namespace AtCoderCsharp.AGC.AGC
{
    internal class agc024_a
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split();
            long A = long.Parse(input1[0]);
            long B = long.Parse(input1[1]);
            long C = long.Parse(input1[2]);
            long K = long.Parse(input1[3]);

            Console.WriteLine(K % 2 == 0 ? A - B  : B - A );


        }
    }
}
