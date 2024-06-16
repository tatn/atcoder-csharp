namespace AtCoderCsharp.ABC.ABC055
{
    internal class abc055_b
    {
        public static void Main(string[] args)
        {
            long ReadLong() => long.Parse(Console.ReadLine()!);
            long N = ReadLong();

            long m = (long)Math.Pow(10, 9) + (long)7;

            long answer = 1;
            for (int i = 1; i <= N; i++)
            {
                answer = ( answer * i ) % m;
            }

            Console.WriteLine(answer);


        }
    }
}
