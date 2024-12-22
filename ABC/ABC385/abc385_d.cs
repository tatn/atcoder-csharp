using System.Collections.Generic;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC385
{
    internal class abc385_d
    {
        public static void Main(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split();
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NMSXSY = ReadIntArray();
            int N = NMSXSY[0];
            int M = NMSXSY[1];
            int Sx = NMSXSY[2];
            int Sy = NMSXSY[3];

            int[] X = new int[N + 1];
            int[] Y = new int[N + 1];

            Dictionary<long, SortedSet<long>> yIndexesByX = new Dictionary<long, SortedSet<long>>();
            Dictionary<long, SortedSet<long>> xIndexesByY = new Dictionary<long, SortedSet<long>>();

            for (int i = 1; i <= N; i++)
            {
                int[] XY = ReadIntArray();
                X[i] = XY[0];
                Y[i] = XY[1];

                if (!yIndexesByX.ContainsKey(X[i]))
                {
                    yIndexesByX.Add(X[i], new SortedSet<long>());
                }

                if (!xIndexesByY.ContainsKey(Y[i]))
                {
                    xIndexesByY.Add(Y[i], new SortedSet<long>());
                }

                yIndexesByX[X[i]].Add(Y[i]);
                xIndexesByY[Y[i]].Add(X[i]);
            }

            string[] D = new string[M + 1];
            long[] C = new long[M + 1];

            for (int i = 1; i <= M; i++)
            {
                string[] DC = ReadStringArray();
                D[i] = DC[0];
                C[i] = long.Parse(DC[1]);
            }

            long answer = 0L;
            long xPosition = Sx;
            long yPosition = Sy;
            for (int i = 1; i <= M; i++)
            {
                string direction = D[i];
                long cost = C[i];

                switch (direction)
                {
                    case "U":
                        if (yIndexesByX.ContainsKey(xPosition))
                        {
                            long nextPosition = yPosition + cost;
                            List<long> deleteIndexes = yIndexesByX[xPosition].GetViewBetween(yPosition, nextPosition).ToList();
                            answer += deleteIndexes.Count;
                            foreach (int delteIndex in deleteIndexes)
                            {
                                yIndexesByX[xPosition].Remove(delteIndex);
                                xIndexesByY[delteIndex].Remove(xPosition);
                            }                            
                        }                        
                        yPosition += cost;
                        break;
                    case "D":
                        if (yIndexesByX.ContainsKey(xPosition))
                        {
                            long nextPosition = yPosition - cost;
                            List<long> deleteIndexes = yIndexesByX[xPosition].GetViewBetween(nextPosition, yPosition).ToList();
                            answer += deleteIndexes.Count;
                            foreach (int delteIndex in deleteIndexes)
                            {
                                yIndexesByX[xPosition].Remove(delteIndex);
                                xIndexesByY[delteIndex].Remove(xPosition);
                            }
                        }
                        
                        yPosition -= cost;
                        break;
                    case "L":
                        if (xIndexesByY.ContainsKey(yPosition))
                        {
                            long nextPosition = xPosition - cost;
                            List<long> deleteIndexes = xIndexesByY[yPosition].GetViewBetween(nextPosition, xPosition).ToList();
                            answer += deleteIndexes.Count;
                            foreach (int delteIndex in deleteIndexes)
                            {
                                xIndexesByY[yPosition].Remove(delteIndex);
                                yIndexesByX[delteIndex].Remove(yPosition);
                            }
                        }
                        xPosition -= cost;
                        break;
                    case "R":                        
                        if (xIndexesByY.ContainsKey(yPosition))
                        {
                            long nextPosition = xPosition + cost;
                            List<long> deleteIndexes = xIndexesByY[yPosition].GetViewBetween(xPosition, nextPosition).ToList();
                            answer += deleteIndexes.Count;
                            foreach (int delteIndex in deleteIndexes)
                            {
                                xIndexesByY[yPosition].Remove(delteIndex);
                                yIndexesByX[delteIndex].Remove(yPosition);
                            }
                        }
                        xPosition += cost;
                        break;
                }
            }

            Console.WriteLine($"{xPosition} {yPosition} {answer}");



        }
    }
}
