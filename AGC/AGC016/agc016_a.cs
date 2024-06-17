namespace AtCoderCsharp.AGC.AGC016
{
    internal class agc016_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string S = ReadString();

            char[] chars = S.Distinct().OrderBy(x => x).ToArray();

            int answer = S.Length - 1;
            for (int i = 0; i < chars.Length; i++)
            {
                char targetChar = chars[i];
                int count = GetOperationCount(S, targetChar);

                answer = Math.Min(answer, count);
            }

            Console.WriteLine(answer);
        }

        public static int GetOperationCount(string S , char taregetChar)
        {
            List<char> workChars = S.ToList();

            int count = 0;
            while (1 < workChars.Distinct().Count())
            {
                for (int i = 0; i < S.Length - count - 1 ; i++)
                {
                    if (workChars[i] == taregetChar)
                    {
                        continue;
                    }

                    if (workChars[i+1] == taregetChar)
                    {
                        workChars[i] = taregetChar;
                    }                    
                }

                workChars.RemoveAt(workChars.Count - 1);

                count++;
            }

            return count;
        }

    }
}
