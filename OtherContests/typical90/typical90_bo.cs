namespace AtCoderCsharp.OtherContests.typical90
{
    // 067 - Base 8 to 9（★2） 

    internal class typical90_bo
    {
        public static void Main(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            string[] NK = ReadStringArray();
            string N = NK[0];
            int K = int.Parse(NK[1]);

            string answer = N;
            for (int i = 1; i <= K; i++)
            {
                answer = GetNumberOfBase10FromBase8(answer);
                answer = GetNumberOfBase9Replaced(long.Parse(answer));
            }

            Console.WriteLine(answer);

            string GetNumberOfBase10FromBase8(string nString)
            {
                long base10Number = 0L;
                for (int i = nString.Length - 1; 0 <= i; i--)
                {
                    base10Number += long.Parse(nString[i].ToString()) * (1L << (3 * (nString.Length-i-1)  ));
                }

                return base10Number.ToString();
            }

            string GetNumberOfBase9Replaced(long n)
            {
                if(n == 0L)
                {
                   return "0";
                }

                List<int> base9Numbers = new List<int>();

                while (0 < n)
                {
                    base9Numbers.Add((int)(n % 9L));

                    n /= 9L;
                }

                base9Numbers.Reverse();
                string base9String = string.Join("", base9Numbers.Select(x => x == 8 ? 5 : x));

                return base9String;
            }

        }

    }
}
