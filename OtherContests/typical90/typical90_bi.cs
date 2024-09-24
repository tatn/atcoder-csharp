namespace AtCoderCsharp.OtherContests.typical90
{
    // 061 - Deck（★2） 

    internal class typical90_bi
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int Q = ReadInt();

            int[] t = new int[Q+1];
            int[] x = new int[Q+1];

            for (int i = 1; i <= Q; i++)
            {
                int[] input = ReadIntArray();
                t[i] = input[0];
                x[i] = input[1];
            }

            List<int> deckTop = new List<int>();
            List<int> deckBottom = new List<int>();

            for (int i = 1; i <= Q; i++)
            {
                if (t[i] == 1)
                {
                    deckTop.Add(x[i]);
                }
                else if (t[i] == 2)
                {
                    deckBottom.Add(x[i]);
                }
                else
                {
                    if (x[i] <= deckTop.Count)
                    {
                        Console.WriteLine(deckTop[deckTop.Count - x[i]]);
                    }
                    else
                    {
                        int bottomIndex = x[i] - deckTop.Count;

                        Console.WriteLine(deckBottom[bottomIndex - 1]);
                    }
                }
            }

        }

    }
}
