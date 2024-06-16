namespace AtCoderCsharp.AGC.AGC
{
    internal class agc003_a
    {
        public static void Main(string[] args)
        {
            char[] s = Console.ReadLine()!.ToCharArray();
            char[] sdistinct = s.Distinct().ToArray();

            if(sdistinct.Length == 4)
            {
                Console.WriteLine("Yes");
            }
            else if(sdistinct.Length == 2)
            {
                if (sdistinct.Contains('N') && sdistinct.Contains('S'))
                {
                    Console.WriteLine("Yes");

                }
                else if (sdistinct.Contains('W') && sdistinct.Contains('E'))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
