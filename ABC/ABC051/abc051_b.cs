namespace AtCoderCsharp.ABC.ABC051
{
    internal class abc051_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] KS = ReadIntArray();
            int K = KS[0];
            int S = KS[1];

            long answer = 0L;
            for (int X = 0; X <= K; X++)
            {
                for (int Y = 0; Y <= K; Y++)
                {

                    int diff = S - X - Y;

                    if (diff < 0)
                    {
                        break;
                    }


                    if(diff <= K)
                    {
                        answer++;
                    }

                }
            }

            Console.WriteLine(answer);
        }

    }
}
