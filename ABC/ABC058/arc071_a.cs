using System.Text;

namespace AtCoderCsharp.ABC.ABC058
{
    internal class arc071_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int n = ReadInt();

            string[] S = new string[n];
            List<int[]> charCountList = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                S[i] = ReadString();

                int[] charCount = new int['z'-'a' + 1];

                foreach (int c in S[i])
                {
                    charCount[c - 'a']++;
                }

                charCountList.Add(charCount);
            }

            int[] minCharCount = new int['z' - 'a' + 1];
            Array.Fill(minCharCount, 100);
            foreach (int[] charCount in charCountList)
            {
                for(char c = 'a';c <= 'z'; c++)
                {
                    int minCount = minCharCount[c - 'a'];
                    int count = charCount[c - 'a'];

                    if(count < minCount)
                    {
                        minCharCount[c - 'a'] = count;
                    }

                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (char c = 'a'; c <= 'z'; c++)
            {
                int minCount = minCharCount[c - 'a'];

                if(minCount == 100)
                {
                    continue;
                }

                for (int i = 0; i < minCount; i++)
                {
                    stringBuilder.Append(c);
                }
            }

            Console.WriteLine(stringBuilder.ToString());

        }
    }
}
