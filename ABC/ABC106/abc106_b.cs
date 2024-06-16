namespace AtCoderCsharp.ABC.ABC106
{
    internal class abc106_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            int answer = 0;

            for (int i = 1;i <= N; i++)
            {
                int devideNumber = 0;
                for (int j = 1; j <= N; j++)
                {
                    if(i % j == 0)
                    {
                        devideNumber++;
                    }
                }

                if(devideNumber == 8 && i % 2 == 1)
                {
                    answer++;
                }

            }

            Console.WriteLine(answer);


        }
    }
}
