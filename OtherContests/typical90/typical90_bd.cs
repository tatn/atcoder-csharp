namespace AtCoderCsharp.OtherContests.typical90
{
    // 056 - Lucky Bag（★5） 

    internal class typical90_bd
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NS = ReadIntArray();
            int N = NS[0];
            int S = NS[1];

            int[] A = new int[N + 1];
            int[] B = new int[N + 1];

            (int,string)[] minimum = new (int, string)[N + 1];
            (int, string)[] maximum = new (int, string)[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] AB = ReadIntArray();
                A[i] = AB[0];
                B[i] = AB[1];

                if (A[i] <= B[i])
                {
                    minimum[i].Item1 = minimum[i-1].Item1 + A[i];
                    minimum[i].Item2 = "A";

                    maximum[i].Item1 = maximum[i-1].Item1 + B[i];
                    maximum[i].Item2 = "B";
                }
                else
                {
                    minimum[i].Item1 = minimum[i - 1].Item1 + B[i];
                    minimum[i].Item2 = "B";

                    maximum[i].Item1 = maximum[i - 1].Item1 + A[i];
                    maximum[i].Item2 = "A";
                }
            }

            Stack<(int, int, List<string>)> stack = new Stack<(int, int, List<string>)>();
            stack.Push((N, S, new List<string>()));

            List<string> answer = new List<string>();

            while (0 < stack.Count)
            {
                (int index, int needPrice ,List<string> choices) = stack.Pop();

                if( N - index < choices.Count)
                {
                    choices.RemoveRange(N - index, choices.Count - (N - index));
                }

                bool isMatch = true;

                for (int i = index; 1 <= i; i--)
                {
                    if (minimum[i].Item1 == needPrice)
                    {
                        choices.Add(minimum[i].Item2);
                        needPrice -= minimum[i].Item2 == "A" ? A[i] : B[i];
                        continue;
                    }

                    if (maximum[i].Item1 == needPrice)
                    {
                        choices.Add(maximum[i].Item2);
                        needPrice -= maximum[i].Item2 == "A" ? A[i] : B[i];
                        continue;
                    }

                    if (needPrice < minimum[i].Item1 || maximum[i].Item1 < needPrice)
                    {
                        isMatch = false;
                        break;
                    }

                    if(i == 1)
                    {
                        isMatch = false;
                        continue;
                    }

                    int lessPrice = A[i] <= B[i] ? A[i] : B[i];
                    int morePrice = A[i] <= B[i] ? B[i] : A[i];

                    int lessCandidate = needPrice - morePrice;
                    int moreCandidate = needPrice - lessPrice;

                    if (lessCandidate == moreCandidate)
                    {
                        // 同じ金額の場合

                        if (minimum[i - 1].Item1 <= lessCandidate && lessCandidate <= maximum[i - 1].Item1)
                        {
                            //金額が選択可能な場合
                            needPrice = lessCandidate;
                            choices.Add("A");
                        }
                    }
                    else
                    {

                        if (minimum[i - 1].Item1 <= lessCandidate && lessCandidate <= maximum[i - 1].Item1)
                        {
                            // 小さい方が選択可能な場合

                            if (minimum[i - 1].Item1 <= moreCandidate && moreCandidate <= maximum[i - 1].Item1)
                            {
                                // 大きい方が選択可能な場合

                                // 片方をスタックに入れ、片方続行
                                List<string> copyList = choices.ToList();
                                copyList.Add(A[i] <= B[i] ? "B" : "A");
                                stack.Push((i-1, lessCandidate  , copyList));

                                needPrice = moreCandidate;
                                choices.Add(A[i] <= B[i] ? "A" : "B");

                            }
                            else
                            {
                                // 大きい方が選択不可の場合

                                needPrice = lessCandidate;
                                choices.Add(A[i] <= B[i] ? "B" : "A");
                            }
                        }
                        else
                        {
                            // 小さい方が選択不可の場合

                            if (minimum[i - 1].Item1 <= moreCandidate && moreCandidate <= maximum[i - 1].Item1)
                            {
                                // 大きい方が選択可能な場合

                                needPrice = moreCandidate;
                                choices.Add(A[i] <= B[i] ? "A" : "B");
                            }

                        }
                    }

                }

                if (isMatch)
                {
                    answer = choices;
                    break;
                }
            }

            if (answer.Count == 0)
            {
                Console.WriteLine("Impossible");
            }
            else
            {
                answer.Reverse();
                Console.WriteLine(String.Join("", answer));
            }

        }
    }
}
