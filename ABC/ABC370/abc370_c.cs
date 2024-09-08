using System.Numerics;
namespace AtCoderCsharp.ABC.ABC370
{
    internal class abc370_c
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string S = ReadString();
            string T = ReadString();

            int N = S.Length;

            bool[] isSGreator = new bool[N + 1];
            bool[] isSame = new bool[N + 1];

            for (int i = 1; i <= N; i++)
            {
                isSGreator[i] = T[i - 1] < S[i - 1];
                isSame[i] = T[i - 1] == S[i - 1];
            }

            List<string> X = new List<string>();

            List<int> changedIndex = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                if (isSame[i])
                {
                    continue;
                }

                if (isSGreator[i])
                {
                    changedIndex.Add(i);
                }
            }

            for (int i = N; 1 <= i; i--)
            {
                if (isSame[i])
                {
                    continue;
                }

                if (!isSGreator[i])
                {
                    changedIndex.Add(i);
                }
            }

            Console.WriteLine(changedIndex.Count);

            char[] chars = S.ToCharArray();

            foreach (int index in changedIndex)
            {
                chars[index - 1] = T[index - 1];
                Console.WriteLine(string.Join("", chars));
            }
        }

        public static void Main1(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string S = ReadString();
            string T = ReadString();

            int N = S.Length;

            char[] currentString = S.ToCharArray();
            char[] targetString = T.ToCharArray();

            List<string> answer = new List<string>();

            while (currentString.Select((c, i) => new { c = c, index = i }).Any(x => x.c != targetString[x.index]))
            {
                char[] nextString = Enumerable.Range(0, N).Select(x => 'z').ToArray();
                for (int i = 1; i <= N; i++)
                {
                    if(currentString[i-1] == targetString[i-1])
                    {
                        continue;
                    }

                    char[] tempString = new char[N];
                    currentString.CopyTo(tempString, 0);
                    tempString[i-1] = targetString[i-1];

                    if ((new string(tempString).CompareTo(new string(nextString)) < 0))
                    {
                        nextString = tempString;
                    }
                }

                answer.Add(new string(nextString));
                currentString = nextString;
            }

            Console.WriteLine(answer.Count);
            foreach (string a in answer)
            {
                Console.WriteLine(a);
            }
        }

    }
}
