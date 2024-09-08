namespace AtCoderCsharp.ABC.ABC370
{
    internal class abc370_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] LR = ReadIntArray();
            int L = LR[0];
            int R = LR[1];

            if(L == 1 && R == 0)
            {
                Console.WriteLine("Yes");
            }
            else if (L == 0 && R == 1)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
