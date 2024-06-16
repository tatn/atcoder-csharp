namespace AtCoderCsharp.OtherContests.code_festival_2017_qualb
{
    internal class code_festival_2017_qualb_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] D = ReadIntArray();
            int M = ReadInt();
            int[] T = ReadIntArray();

            Dictionary<int,int> dicProblems = new Dictionary<int,int>();
            for (int i = 0; i < N; i++)
            {
                if (dicProblems.ContainsKey(D[i]))
                {
                    dicProblems[D[i]]++;
                }
                else
                {
                    dicProblems.Add(D[i], 1);
                }
            }

            bool isNotFound = false;

            for (int i = 0; i < M; i++)
            {
                if (dicProblems.ContainsKey(T[i]))
                {
                    dicProblems[T[i]]--;

                    if (dicProblems[T[i]] < 0)
                    {
                        isNotFound = true;
                        break;
                    }
                }
                else
                {
                    isNotFound = true;
                    break;
                }
            }

            Console.WriteLine(isNotFound ? "NO" : "YES");
        }
    }
}
