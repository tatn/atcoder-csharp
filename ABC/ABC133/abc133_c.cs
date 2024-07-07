namespace AtCoderCsharp.ABC.ABC133
{
    internal class abc133_c
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] LR = ReadIntArray();
            int L = LR[0];
            int R = LR[1];

            long answer = 2019;
            for (int i = L; i <= R-1; i++)
            {
                for (int j = i+1; j <= R; j++)
                {
                    long ijmod = ((i % 2019) * (j % 2019)) % 2019;

                    if(ijmod < answer)
                    {
                        answer = ijmod;
                    }
                    
                    if(answer == 0)
                    {
                        break;
                    }
                }
                if (answer == 0)
                {
                    break;
                }
            }

            Console.WriteLine(answer);

        }

    }
}
