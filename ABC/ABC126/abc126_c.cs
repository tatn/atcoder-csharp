namespace AtCoderCsharp.ABC.ABC126
{
    internal class abc126_c
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int[] input = ReadIntArray();
            int N = input[0];
            int K = input[1];

            int maxNeedFrontTimes = (int)Math.Ceiling(Math.Log2(K));
            int[] patternCount = new int[maxNeedFrontTimes + 1];

            for (int n = 1; n <= N; n++)
            {
                int needFrontTimes =  (int)Math.Ceiling(Math.Log2((double)K / (double)n));

                if(needFrontTimes < 0)
                {
                    needFrontTimes = 0;
                }

                patternCount[needFrontTimes]++;
            }

            double answer = 0.0;
            for (int i = 0 ; i <= maxNeedFrontTimes; i++)
            {
                int count = patternCount[i];
                answer += ((double)count) / (double)(1 << i);
            }

            Console.WriteLine(answer/(double)N);
        }

    }
}
