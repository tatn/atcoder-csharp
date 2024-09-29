namespace AtCoderCsharp.OtherContests.typical90
{
    // 060 - Chimera（★5）
    // 最長増加部分列(LIS Longest Increasing Subsequence)

    internal class typical90_bh
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();
            List<int> B = A.ToList();
            B.Reverse();
            A.Insert(0, 0);
            B.Insert(0, 0);

            int[] ALength = new int[N + 1];
            int[] BLength = new int[N + 1];

            List<int> AWork = new List<int>();
            List<int> BWork = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                int a = A[i];
                int index = AWork.BinarySearch(a);

                if (index < 0)
                {
                    index = ~index;

                    if (index == AWork.Count)
                    {
                        AWork.Add(a);

                        ALength[i] = AWork.Count;
                    }
                    else
                    {
                        ALength[i] = index + 1;
                        AWork[index] = a;
                    }

                }
                else
                {
                    ALength[i] = index + 1;
                }
            }

            for (int i = 1; i <= N; i++)
            {
                int b = B[i];
                int index = BWork.BinarySearch(b);

                if (index < 0)
                {
                    index = ~index;

                    if (index == BWork.Count)
                    {
                        BWork.Add(b);

                        BLength[i] = BWork.Count;
                    }
                    else
                    {
                        BLength[i] = index + 1;
                        BWork[index] = b;
                    }

                }
                else
                {
                    BLength[i] = index + 1;
                }
            }

            int answer = 0;
            for (int i = 1; i <= N; i++)
            {
                answer = Math.Max(answer, ALength[i] + BLength[N - i + 1] - 1);
            }

            Console.WriteLine(answer);


        }

    }
}
