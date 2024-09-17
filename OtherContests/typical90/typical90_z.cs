namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_z
    {
        // 026 - Independent Set on a Tree（★4） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            List<int>[] G = new List<int>[N + 1];
            for (int i = 0; i <= N; i++)
            {
                G[i] = new List<int>();
            }

            int[] nodeType = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                nodeType[i] = -1;
            }

            for (int i = 1; i <= N - 1; i++)
            {
                int[] AB = ReadIntArray();
                G[AB[0]].Add(AB[1]);
                G[AB[1]].Add(AB[0]);                
            }

            SetNodeType(1, 1);

            void SetNodeType(int nodeIndex,int type)
            {
                if (nodeType[nodeIndex] != -1)
                {
                    return;
                }

                nodeType[nodeIndex] = type;

                foreach (int next in G[nodeIndex])
                {
                    SetNodeType(next, 1-type);
                }
            }

            List<int> zeroIndexes = new List<int>();
            List<int> oneIndexes = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                if (nodeType[i] == 0)
                {
                    zeroIndexes.Add(i);
                }
                else if (nodeType[i] == 1)
                {
                    oneIndexes.Add(i);
                }
            }

            if(zeroIndexes.Count < oneIndexes.Count)
            {

                Console.WriteLine(string.Join(" ", oneIndexes.Take(N / 2)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", zeroIndexes.Take(N / 2)));
            }


        }
    }
}
