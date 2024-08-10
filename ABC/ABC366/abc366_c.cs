using System.Numerics;

namespace AtCoderCsharp.ABC.ABC366
{
    internal class abc366_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int Q = ReadInt();

            int[,] queryArray = new int[Q, 2];
            for (int i = 0; i < Q; i++)
            {
                int[] query = ReadIntArray();
                queryArray[i, 0] = query[0];
                if (query[0] != 3)
                {
                    queryArray[i, 1] = query[1];
                }
            }

            int[] ballCount = new int[1_000_000 + 1];
            int count = 0;
            for (int i = 0; i < Q; i++)
            {
                switch (queryArray[i,0])
                {
                    case 1:
                        ballCount[queryArray[i,1]]++;
                        if (ballCount[queryArray[i, 1]] == 1)
                        {
                            count++;
                        }
                        break;
                    case 2:
                        ballCount[queryArray[i, 1]]--;
                        if (ballCount[queryArray[i, 1]] == 0)
                        {
                            count--;
                        }
                        break;
                    case 3:
                        Console.WriteLine(count);
                        break;
                }
            }

        }
    }
}
