﻿namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_aq
    {
        // 043 - Maze Challenge with Lack of Sleep（★4） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            int[] rcStart = ReadIntArray();
            int rStart = rcStart[0];
            int cStart = rcStart[1];

            int[] rcGoal = ReadIntArray();
            int rGoal = rcGoal[0];
            int cGoal = rcGoal[1];

            bool[,] isWall = new bool[H+2,W+2];
            for (int i = 1; i <= H; i++)
            {
                string S = ReadString();
                for (int j = 1; j <= W; j++)
                {
                    isWall[i,j] = S[j-1] == '#';
                }
            }

            for (int i = 1; i <= H; i++)
            {
                isWall[i, 0] = true;
                isWall[i, W + 1] = true;
            }

            for (int j = 1; j <= W; j++)
            {
                isWall[0, j] = true;
                isWall[H + 1, j] = true;
            }

            int[,] turnCount = new int[H + 2, W + 2];
            for (int i = 0; i <= H+1; i++)
            {
                for (int j = 0; j <= W+1; j++)
                {
                    turnCount[i,j] = int.MaxValue;
                }
            }

            PriorityQueue<(int,int,int,Direction),int> queue = new PriorityQueue<(int, int, int, Direction), int>();
            queue.Enqueue((rStart, cStart, 0, Direction.Up),0);
            queue.Enqueue((rStart, cStart, 0, Direction.Down), 0);
            queue.Enqueue((rStart, cStart, 0, Direction.Left), 0);
            queue.Enqueue((rStart, cStart, 0, Direction.Right), 0);

            while (0 < queue.Count)
            {
                (int row, int col, int cost, Direction direction) = queue.Dequeue();
                Walk(row, col, cost, direction);
            }

            int ans = turnCount[rGoal, cGoal] == int.MaxValue ? -1 : turnCount[rGoal, cGoal];
            Console.WriteLine(ans);

            void Walk(int row,int col, int cost, Direction direction)
            {
                if(turnCount[row, col] < cost)
                {
                    return;
                }

                turnCount[row, col] = cost;

                if (!isWall[row-1,col])
                {
                    queue.Enqueue((row-1, col, cost + (direction == Direction.Up ? 0 : 1), Direction.Up), cost + (direction == Direction.Up ? 0: 1));
                }
                if (!isWall[row + 1, col])
                {
                    queue.Enqueue((row+1, col, cost + (direction == Direction.Down ? 0 : 1), Direction.Down), cost + (direction == Direction.Down ? 0 : 1));
                }
                if (!isWall[row, col - 1])
                {
                    queue.Enqueue((row, col-1, cost + (direction == Direction.Left ? 0 : 1), Direction.Left), cost + (direction == Direction.Left ? 0 : 1));
                }
                if (!isWall[row, col + 1])
                {
                    queue.Enqueue((row, col+1, cost + (direction == Direction.Right ? 0 : 1), Direction.Right), cost + (direction == Direction.Right ? 0 : 1));
                }
            }
        }

        enum Direction
        {
            Up, Down, Left, Right,
        }
    }
}