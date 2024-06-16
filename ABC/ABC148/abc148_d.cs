namespace AtCoderCsharp.ABC.ABC148
{
    internal class abc148_d
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            string[] input2 = Console.ReadLine()!.Split();
            int[] a = input2.Select(int.Parse).ToArray();

            bool findOne = false;
            int countup = 1;
            for (int i = 0; i < N; i++)
            {
                if(countup == a[i])
                {
                    findOne = true;
                    countup++;
                }
            }

            Console.WriteLine(findOne ? N - countup + 1 : -1);
        }

    }
}
