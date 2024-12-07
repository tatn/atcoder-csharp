using System;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC383
{
    internal class abc383_b
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] hwd = ReadIntArray();
            int H = hwd[0];
            int W = hwd[1];
            int D = hwd[2];

            string[,] S = new string[H + 1, W + 1];
            for (int i = 1; i <= H; i++)
            {
                string strin = ReadString();
                for (int j = 1; j <= W; j++)
                {
                    S[i, j] = strin[j - 1].ToString();
                }
            }

            //int[,,,] floorCount = new int[H + 1, W + 1, H + 1, W + 1];
            int max = 0;
            for (int i1 = 1; i1 <= H; i1++)
            {
                for (int j1 = 1; j1 <= W; j1++)
                {
                    if (S[i1, j1] == "#")
                    {
                        continue;
                    }

                    for (int i2 = i1; i2 <= H; i2++)
                    {
                        int colBegin = i1 == i2 ? j1+1 : 1;
                        for (int j2 = colBegin; j2 <= W; j2++)
                        {

                            if (S[i2, j2] == "#")
                            {
                                continue;
                            }

                            int count = 0;
                            for(int i=1; i<=H; i++)
                            {
                                for(int j=1; j<=W; j++)
                                {
                                    if (S[i, j] == "#")
                                    {
                                        continue;
                                    }

                                    int distance1 = Math.Abs(i - i1) + Math.Abs(j - j1);
                                    int distance2 = Math.Abs(i - i2) + Math.Abs(j - j2);

                                    if(distance1 <= D ||  distance2 <= D)
                                    {
                                        count++;
                                    }
                                }
                            }

                            //floorCount[i1, j1, i2, j2] = count;
                            if(count > max)
                            {
                                max = count;
                            }
                        }
                    }

                }
            }

            Console.WriteLine(max);
        }
    }
}
