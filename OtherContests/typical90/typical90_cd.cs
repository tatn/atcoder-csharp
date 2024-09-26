namespace AtCoderCsharp.OtherContests.typical90
{
    //  082 - Counting Numbers（★3） 

    internal class typical90_cd
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] LR = ReadLongArray();
            long L = LR[0];
            long R = LR[1];

            long mod = 1_000_000_007L;

            long countLeft = GetCharCount(L - 1);
            long countRight = GetCharCount(R);

            long answer = countRight - countLeft;
            if(answer < 0)
            {
                answer += mod;
            }

            Console.WriteLine(answer);

            long GetCharCount(long x)
            {
                long answer = 0L;

                long tenPowers = 1L;

                for (int i = 1; i <=19; i++)
                {
                    if(i == 19)
                    {
                        // 19桁の文字1...00が10^18個ある
                        answer = (answer + 19L* (1_000_000_000_000_000_000L % mod)  ) % mod;
                        break;
                    }

                    long left = tenPowers;
                    long right = tenPowers * 10L - 1L;

                    if(x < right)
                    {
                        right = x;
                    }

                    //　i桁の文字 left=tenPowers, tenPowers+1, tenPowers+2, ... , right = tenPowers*10-1 (or x) を数える
                    long length = (right - left + 1);
                    long firstAndLast = (left + right);

                    if( (right - left) % 2 == 0)
                    {
                        firstAndLast = firstAndLast / 2;
                    }
                    else
                    {
                        length = length / 2;
                    }

                    length %= mod;
                    firstAndLast %= mod;

                    long total = ((((i * length) % mod) * firstAndLast) % mod);

                    answer = (answer + total) % mod;

                    tenPowers *= 10L;

                    if(x < tenPowers)
                    {
                        break;
                    }
                }

                return answer;
            }

        }
    }
}
