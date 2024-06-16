namespace AtCoderCsharp.ABC.ABC132
{
    internal class abc132_c
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            string[] input2 = Console.ReadLine()!.Split(' ');
            int[] d = input2.Select(int.Parse).ToArray();

            int[] dSorted = d.Order().ToArray();

            int halfLeft = dSorted[N / 2 - 1];
            int halfRight = dSorted[N / 2];

            if(halfLeft == halfRight)
            {
                Console.WriteLine(0);
            }
            else
            {

                Console.WriteLine(halfRight-halfLeft);
            }
        }

    }
}
