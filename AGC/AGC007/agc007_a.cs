namespace AtCoderCsharp.AGC.AGC007
{
    internal class agc007_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            bool[,] moved = new bool[H + 2, W + 2];

            for (int i = 1; i <= H; i++)
            {
                string line = ReadString();

                for (int j = 1; j <= W; j++)
                {
                    moved[i, j] = line[j - 1] == '#';
                }
            }

            int[,] distance = new int[H + 1, W + 1];

            for (int i = 0; i <= H; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    distance[i, j] = -1;
                }
            }

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((1, 1));
            distance[1, 1] = 0;

            while (0 < queue.Count)
            {
                (int currentR, int currentC) = queue.Dequeue();

                if (!moved[currentR, currentC])
                {
                    continue;
                }

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if(i == 0 && j == 0)
                        {
                            continue;
                        }
                        if (i != 0 && j != 0)
                        {
                            continue;
                        }

                        if (!moved[currentR + i, currentC + j])
                        {
                            continue;
                        }

                        if (distance[currentR + i, currentC + j] != -1)
                        {
                            continue;
                        }

                        distance[currentR + i, currentC + j] = distance[currentR, currentC] + 1;

                        queue.Enqueue((currentR + i, currentC + j));
                    }
                }
            }

            int[] distanceCount = new int[H * W + 1];
            int maxDistance = 0;

            for (int i = 0; i <= H; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    if(distance[i, j] == -1)
                    {
                        continue;
                    }

                    distanceCount[distance[i, j]] += 1;

                    if(maxDistance < distance[i, j])
                    {
                        maxDistance = distance[i, j];
                    }
                }
            }

            int duplicateCount = distanceCount.Where(x => 1 < x).Count();

            Console.WriteLine(maxDistance == H +W - 2 && duplicateCount == 0 ? "Possible" : "Impossible");

        }
    }
}
