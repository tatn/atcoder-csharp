namespace AtCoderCsharp.OtherContests.panasonic2020
{
    internal class panasonic2020_b
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split(' ');
            long H = long.Parse(input1[0]);
            long W = long.Parse(input1[1]);

            if (H == 1 || W == 1)
            {
                Console.WriteLine(1);
                return;
            }

            if(H % 2 == 0 && W % 2 == 0)
            {
                Console.WriteLine(H*W/ (long)2);
            }
            else if(H %2 == 0 && W %2 == 1)
            {
                Console.WriteLine((H * W / (long)2));

            }
            else if (H % 2 == 1 && W % 2 == 0)
            {
                Console.WriteLine((H * W / (long)2));
            }
            else
            {
                Console.WriteLine((H * W / (long)2)+1);

            }
        }
    }
}
