namespace AtCoderCsharp.OtherContests.typical90
{
    //  084 - There are two types of characters（★3） 

    internal class typical90_cf
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string ReadString() => Console.ReadLine()!;

            int N = ReadInt();
            string S = ReadString();

            int prevIndex = 0;
            char c = S[0];
            List<int> continueCount = new List<int>();

            for (int i = 1; i < N; i++)
            {
                if (S[i] != c)
                {
                    c = S[i];
                    continueCount.Add(i - prevIndex);
                    prevIndex = i;
                }
            }

            if(2<=N && S[N-1]== S[N - 2])
            {
                continueCount.Add(N - prevIndex);
            }
            else
            {
                continueCount.Add(1);
            }

            long ngCount = 0L;
            foreach (int i in continueCount)
            {
                ngCount += ((long)i * ((long)i - 1L) / 2L);
            }

            long answer = (long)N*((long)N -1L)/2L - ngCount;

            Console.WriteLine(answer);


        }
    }
}
