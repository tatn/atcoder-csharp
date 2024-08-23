namespace AtCoderCsharp.ABC.ABC136
{
    internal class abc139_d
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string S = ReadString();


            int[] rContinueCount = new int[S.Length];
            int countR = 0;

            for (int i = 0; i < S.Length - 1; i++)
            {
                char current = S[i];
                char next = S[i + 1];


                if(current == 'R')
                {
                    countR++;
                }
                else
                {
                    countR = 0;
                }

                if(current == 'R' && next == 'L')
                {
                    rContinueCount[i] = countR;
                }
                else
                {
                    rContinueCount[i] = 0;
                }
            }


            int[] lContinueCount = new int[S.Length];
            int countL = 0;

            for (int i = S.Length - 1; 0 < i; i--)
            {
                char current = S[i];
                char prev = S[i - 1];


                if (current == 'L')
                {
                    countL++;
                }
                else
                {
                    countL = 0;
                }

                if (current == 'L' && prev == 'R')
                {
                    lContinueCount[i] = countL;
                }
                else
                {
                    lContinueCount[i] = 0;
                }
            }

            int[] answer = new int[S.Length];

            for (int i = 0; i < S.Length - 1; i++)
            {
                int r = rContinueCount[i];

                if(r == 0)
                {
                    continue;
                }

                int l = lContinueCount[i + 1];

                int leftCount = ((r+1) / 2) + (l / 2);
                int rightCount = (r / 2) + ( (l+1) / 2);

                answer[i] = leftCount;
                answer[i + 1] = rightCount;
            }

            Console.WriteLine(String.Join(" ",answer));

        }
    }
}
