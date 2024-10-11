namespace AtCoderCsharp.OtherContests.typical90
{
    // 072 - Loop Railway Plan（★4）
    // バックトラック

    internal class typical90_bt
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            bool[,] isPlain = new bool[H + 2, W + 2];

            for (int i = 1; i <= H; i++)
            {
                string cInput = ReadString();
                for (int j = 1; j <= W; j++)
                {
                    isPlain[i, j] = cInput[j - 1] == '.';
                }
            }

            int[] dx = new int[4] { 0, 1, 0, -1 };
            int[] dy = new int[4] { 1, 0, -1, 0 };


            int answer = 0;
            bool[,] visited = new bool[H + 2, W + 2];

            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    answer = Math.Max(answer, DFS(i, j, i, j));
                }
            }

            Console.WriteLine(answer <= 2 ? -1 : answer);

            int DFS(int beginX, int beginY, int endX, int endY)
            {
                if(beginX ==  endX && beginY == endY && visited[endX,endY])
                {
                    return 0;
                }

                int distance = -300;
                visited[endX, endY] = true;

                for (int i = 0; i <= 3; i++)
                {
                    int nextX = endX + dx[i];
                    int nextY = endY + dy[i];

                    if (!isPlain[nextX,nextY])
                    {
                        continue;
                    }

                    if (visited[nextX,nextY] && (beginX != nextX || beginY != nextY))
                    {
                        continue;
                    }

                    int d = DFS(beginX, beginY, nextX, nextY);
                    distance = Math.Max(distance, d + 1);
                }

                visited[endX, endY] = false;

                return distance;
            }

        }
    }
}
