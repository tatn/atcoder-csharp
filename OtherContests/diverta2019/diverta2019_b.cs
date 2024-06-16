namespace AtCoderCsharp.OtherContests.diverta2019
{
    internal class diverta2019_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int[] input = ReadIntArray();
            int R = input[0];
            int G = input[1];
            int B = input[2];
            int N = input[3];

            int rMax = N / R;
            int gMax = N / G;
            int bMax = N / B;

            int answer = 0;
            for (int i = 0; i <= rMax; i++)
            {
                for (int j = 0; j <= gMax; j++)
                {
                    int diff = N - R * i - G * j;

                    if(0<= diff && diff <= bMax * B && diff % B == 0)
                    {
                        answer++;
                    }

                    if(diff <= 0)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(answer);
        }

    }
}
