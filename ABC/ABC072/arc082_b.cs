namespace AtCoderCsharp.ABC.ABC072
{
    internal class arc082_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] p = ReadIntArray();

            int answer = 0;
            int sameIndex = FindSameIndex(p);
            while (sameIndex != -1)
            {
                if(sameIndex == N)
                {
                    int swap = p[sameIndex - 2];
                    p[sameIndex - 2] = p[sameIndex-1];
                    p[sameIndex-1] = swap;
                }
                else
                {
                    int swap = p[sameIndex - 1];
                    p[sameIndex - 1] = p[sameIndex];
                    p[sameIndex] = swap;
                }

                answer++;
                sameIndex = FindSameIndex(p);
            }


            Console.WriteLine(answer);
        }

        public static int FindSameIndex(int[] p)
        {
            for (int i = 0;i < p.Length; i++)
            {
                if (p[i] == i + 1)
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
