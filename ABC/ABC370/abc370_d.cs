using System.Numerics;
namespace AtCoderCsharp.ABC.ABC370
{
    internal class abc370_d
    {
        public static void Main(string[] args)
        {
            //ToDo
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HWQ = ReadIntArray();
            int H = HWQ[0];
            int W = HWQ[1];
            int Q = HWQ[2];

            int[] R = new int[Q + 1];
            int[] C = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                int[] rcInput = ReadIntArray();
                R[i] = rcInput[0];
                C[i] = rcInput[1];
            }

            // brokenWallR[i] = i行目の壁ない列のリスト
            List<int>[] brokenWallR = new List<int>[H + 1];
            for (int i = 0; i <= H; i++)
            {
                brokenWallR[i] = new List<int>();
            }

            // brokenWallC[i] = i列目の壁がない行のリスト
            List<int>[] brokenWallC = new List<int>[W + 1];
            for (int i = 0; i <= W; i++)
            {
                brokenWallC[i] = new List<int>();
            }

            for (int i = 1; i <= Q; i++)
            {
                int rowHitIndex = R[i];
                int colHitIndex = C[i];

                int rowFoundIndex = brokenWallR[rowHitIndex].BinarySearch(colHitIndex);
                if (0 <= rowFoundIndex)
                {
                    int left1 = 1;
                    int right1 = colHitIndex;
                    int mid1 = (left1 + right1) / 2;
                    while(left1 < right1)
                    {
                        mid1 = (left1 + right1) / 2;

                        int index = brokenWallR[rowHitIndex].BinarySearch(mid1);
                        if(index < 0)
                        {
                            if(left1 == mid1)
                            {
                                left1++;
                            }
                            else
                            {
                                left1 = mid1;
                            }
                        }
                        else
                        {
                            if (colHitIndex - brokenWallR[rowHitIndex][index] == rowFoundIndex - index)
                            {
                                right1 = mid1;
                            }
                            else
                            {
                                if (left1 == mid1)
                                {
                                    left1++;
                                }
                                else
                                {
                                    left1 = mid1;
                                }
                            }
                        }
                    }

                    //Console.WriteLine($"1 {right1} {left1} {mid1}");

                    int left2 = colHitIndex;
                    int right2 = W;
                    int mid2 = (left2 + right2+1) / 2;
                    while (left2 < right2)
                    {
                        mid2 = (left2 + right2+1) / 2;
                        int index = brokenWallR[rowHitIndex].BinarySearch(mid2);
                        if (index < 0)
                        {
                            if (right2 == mid2)
                            {
                                right2--;
                            }
                            else
                            {
                                right2 = mid2;
                            }
                        }
                        else
                        {
                            if (colHitIndex - brokenWallR[rowHitIndex][index] == rowFoundIndex - index)
                            {
                                left2 = mid2;
                            }
                            else
                            {
                                if (right2 == mid2)
                                {
                                    right2--;
                                }
                                else
                                {
                                    right2 = mid2;
                                }
                            }
                        }
                    }

                    //Console.WriteLine($"2 {right2} {left2} {mid2}");

                    int lessValue = left2 + 1;
                    if (1<= lessValue && lessValue <= W)
                    {
                        int addColIndex1 = brokenWallR[rowHitIndex].BinarySearch(lessValue);
                        brokenWallR[rowHitIndex].Insert(~addColIndex1, lessValue);

                        int index = brokenWallC[lessValue].BinarySearch(rowHitIndex);
                        brokenWallC[lessValue].Insert(~index, rowHitIndex);
                    }

                    int moreValue = right1 - 1;
                    if (1 <= moreValue && moreValue <= W)
                    {
                        int addColIndex2 = brokenWallR[rowHitIndex].BinarySearch(moreValue);
                        brokenWallR[rowHitIndex].Insert(~addColIndex2, moreValue);

                        int index = brokenWallC[moreValue].BinarySearch(rowHitIndex);
                        brokenWallC[moreValue].Insert(~index, rowHitIndex);
                    }
                }
                else
                {
                    brokenWallR[rowHitIndex].Insert(~rowFoundIndex, colHitIndex);
                }

                int colFoundIndex = brokenWallC[colHitIndex].BinarySearch(rowHitIndex);
                if (0 <= colFoundIndex)
                {
                    int left1 = 1;
                    int right1 = rowHitIndex;
                    int mid1 = (left1 + right1) / 2;
                    while (left1 < right1)
                    {
                        mid1 = (left1 + right1) / 2;
                        int index = brokenWallC[colHitIndex].BinarySearch(mid1);
                        if (index < 0)
                        {
                            if (left1 == mid1)
                            {
                                left1++;
                            }
                            else
                            {
                                left1 = mid1;
                            }
                        }
                        else
                        {
                            if (rowHitIndex - brokenWallC[colHitIndex][index] == colFoundIndex - index)
                            {
                                right1 = mid1;
                            }
                            else
                            {
                                if (left1 == mid1)
                                {
                                    left1++;
                                }
                                else
                                {
                                    left1 = mid1;
                                }
                            }
                        }
                    }

                    //Console.WriteLine($"1 {right1} {left1} {mid1}");

                    int left2 = rowHitIndex;
                    int right2 = H;
                    int mid2 = (left2 + right2+1) / 2;
                    while (left2 < right2)
                    {
                        mid2 = (left2 + right2+1) / 2;
                        int index = brokenWallC[colHitIndex].BinarySearch(mid2);
                        if (index < 0)
                        {
                            if (right2 == mid2)
                            {
                                right2--;
                            }
                            else
                            {
                                right2 = mid2;
                            }
                        }
                        else
                        {
                            if (rowHitIndex - brokenWallC[colHitIndex][index] == colFoundIndex - index)
                            {
                                left2 = mid2;
                            }
                            else
                            {
                                if (right2 == mid2)
                                {
                                    right2--;
                                }
                                else
                                {
                                    right2 = mid2;
                                }
                            }
                        }
                    }

                    //Console.WriteLine($"2 {right2} {left2} {mid2}");

                    int lessValue = left2 + 1;
                    if (1 <= lessValue && lessValue <= W)
                    {
                        int addRowIndex1 = brokenWallC[colHitIndex].BinarySearch(lessValue);
                        brokenWallC[colHitIndex].Insert(~addRowIndex1, lessValue);

                        int index = brokenWallR[lessValue].BinarySearch(colHitIndex);
                        brokenWallR[lessValue].Insert(~index, colHitIndex);
                    }

                    int moreValue = right1 - 1;
                    if (1 <= moreValue && moreValue <= W)
                    {
                        int addRowIndex2 = brokenWallC[colHitIndex].BinarySearch(moreValue);
                        brokenWallC[colHitIndex].Insert(~addRowIndex2, moreValue);

                        int index = brokenWallR[moreValue].BinarySearch(colHitIndex);
                        brokenWallR[moreValue].Insert(~index, colHitIndex);
                    }

                }
                else
                {
                    brokenWallC[colHitIndex].Insert(~colFoundIndex, rowHitIndex);
                }

            }

            int answer = 0;
            for (int i = 1; i <= H; i++)
            {
                answer += brokenWallR[i].Count;
            }

            Console.WriteLine(H*W - answer);
        }

        public static void Main2(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HWQ = ReadIntArray();
            int H = HWQ[0];
            int W = HWQ[1];
            int Q = HWQ[2];

            int[] R = new int[Q + 1];
            int[] C = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                int[] rcInput = ReadIntArray();
                R[i] = rcInput[0];
                C[i] = rcInput[1];
            }

            // exitstWallR[i] = i行目の壁がある列のリスト
            List<int>[] exitstWallR = new List<int>[H + 1];
            for (int i = 0; i <= H; i++)
            {
                exitstWallR[i] = new List<int>();
                for (int j = 1; j <= W; j++)
                {
                    exitstWallR[i].Add(j);
                }
            }

            // exitstWallC[i] = i列目の壁がある列のリスト
            List<int>[] exitstWallC = new List<int>[W + 1];
            for (int i = 0; i <= W; i++)
            {
                exitstWallC[i] = new List<int>();
                for (int j = 1; j <= H; j++)
                {
                    exitstWallC[i].Add(j);
                }
            }

            for (int i = 1; i <= Q; i++)
            {
                int rowHitIndex = R[i];
                int colHitIndex = C[i];

                int rowFoundIndex = exitstWallR[rowHitIndex].BinarySearch(colHitIndex);
                if(0 <= rowFoundIndex)
                {
                    exitstWallR[rowHitIndex].RemoveAt(rowFoundIndex);
                }
                else
                {
                    rowFoundIndex = ~rowFoundIndex;

                    if(1 <= rowFoundIndex && rowFoundIndex - 1 < exitstWallR[rowHitIndex].Count)
                    {
                        int deleteColIndex = exitstWallR[rowHitIndex][rowFoundIndex - 1];
                        exitstWallR[rowHitIndex].RemoveAt(rowFoundIndex - 1);

                        int deleteIndex = exitstWallC[deleteColIndex].BinarySearch(rowHitIndex);    
                        exitstWallC[deleteColIndex].RemoveAt(deleteIndex);

                        rowFoundIndex--;
                    }

                    if(0 <= rowFoundIndex  && rowFoundIndex  < exitstWallR[rowHitIndex].Count)
                    {
                        int deleteColIndex = exitstWallR[rowHitIndex][rowFoundIndex];
                        exitstWallR[rowHitIndex].RemoveAt(rowFoundIndex);

                        int deleteIndex = exitstWallC[deleteColIndex].BinarySearch(rowHitIndex);
                        exitstWallC[deleteColIndex].RemoveAt(deleteIndex);
                    }
                }


                int colFoundIndex = exitstWallC[colHitIndex].BinarySearch(rowHitIndex);
                if(0 <= colFoundIndex)
                {
                    exitstWallC[colHitIndex].RemoveAt(colFoundIndex);
                }
                else
                {
                    colFoundIndex = ~colFoundIndex;

                    if (1 <= colFoundIndex && colFoundIndex - 1 < exitstWallC[colHitIndex].Count)
                    {
                        int deleteRowIndex = exitstWallC[colHitIndex][colFoundIndex - 1];
                        exitstWallC[colHitIndex].RemoveAt(colFoundIndex - 1);

                        int deleteIndex = exitstWallR[deleteRowIndex].BinarySearch(colHitIndex);
                        exitstWallR[deleteRowIndex].RemoveAt(deleteIndex);

                        colFoundIndex--;

                    }

                    if (0 <= colFoundIndex && colFoundIndex < exitstWallC[colHitIndex].Count)
                    {
                        int deleteRowIndex = exitstWallC[colHitIndex][colFoundIndex];
                        exitstWallC[colHitIndex].RemoveAt(colFoundIndex);

                        int deleteIndex = exitstWallR[deleteRowIndex].BinarySearch(colHitIndex);
                        exitstWallR[deleteRowIndex].RemoveAt(deleteIndex);
                    }
                } 

            }

            int answer = 0;
            for (int i = 1; i <= H; i++)
            {
                answer += exitstWallR[i].Count;
            }

            Console.WriteLine(answer);
        }

        public static void Main1(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HWQ = ReadIntArray();
            int H = HWQ[0];
            int W = HWQ[1];
            int Q = HWQ[2];

            int[] R = new int[Q + 1];
            int[] C = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                int[] rcInput = ReadIntArray();
                R[i] = rcInput[0];
                C[i] = rcInput[1];
            }

            bool[,] isBroken = new bool[H + 1, W + 1];

            for (int i = 1; i <= Q; i++)
            {
                if (isBroken[R[i], C[i]])
                {
                    int left = C[i] - 1;
                    while (1 <= left)
                    {
                        if (isBroken[R[i], left])
                        {
                            left--;
                        }
                        else
                        {
                            isBroken[R[i], left] = true;
                            break;
                        }
                    }

                    int right = C[i] + 1;
                    while (right <= W)
                    {
                        if (isBroken[R[i], right])
                        {
                            right++;
                        }
                        else
                        {
                            isBroken[R[i], right] = true;
                            break;
                        }
                    }

                    int up = R[i] - 1;
                    while (1 <= up)
                    {
                        if (isBroken[up, C[i]])
                        {
                            up--;
                        }
                        else
                        {
                            isBroken[up, C[i]] = true;
                            break;
                        }
                    }

                    int down = R[i] + 1;
                    while (down <= H)
                    {
                        if (isBroken[down, C[i]])
                        {
                            down++;
                        }
                        else
                        {
                            isBroken[down, C[i]] = true;
                            break;
                        }
                    }

                }
                else
                {
                    isBroken[R[i], C[i]] = true;
                }
            }

            int answer = 0;
            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    if (!isBroken[i, j])
                    {
                        answer++;
                    }
                }

            }

            Console.WriteLine(answer);
        }
    }
}
