namespace AtCoderCsharp.ABC.ABC358
{
    internal class abc358_c
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            string[] S = new string[N];
            for (int i = 0; i < N; i++)
            {
                S[i] = ReadString();
            }

            int answer = N;
            for (int i = 0; i < (1<<N); i++)
            {
                HashSet<int> hs = new HashSet<int>();
                for (int j = 0; j < M; j++)
                {
                    hs.Add(j);
                }

                int counter = 0;

                for (int j = 0; j < N; j++)
                {
                    if (0 < (i & 1 << j))
                    {
                        counter++;
                        string s = S[j];
                        for (int k = 0; k < M; k++)
                        {
                            if (hs.Contains(k) && s[k] == 'o')
                            {
                                hs.Remove(k);
                            }

                            if(hs.Count() == 0)
                            {
                                break;
                            }
                        }
                    }
                }

                if (hs.Count() == 0)
                {
                    answer = Math.Min(answer, counter);
                }
            }

            Console.WriteLine(answer);
        }
    }
}
