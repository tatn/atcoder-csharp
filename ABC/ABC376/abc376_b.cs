using System.Numerics;
using System.Runtime.InteropServices;

namespace AtCoderCsharp.ABC.ABC376
{
    internal class abc376_b
    {

        public static void Main(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split();
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            string[] H = new string[Q + 1];
            int[] T = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                string[] HT = ReadStringArray();
                H[i] = HT[0];
                T[i] = int.Parse(HT[1]);
            }

            int answer = 0;

            int left = 1;
            int right = 2;
            for (int i = 1; i <= Q; i++)
            {
                string h = H[i];
                int t = T[i];

                int min = 0;
                int max = 0;
                int other = 0;

                if (h == "L")
                {
                    // 左手を動かす
                    if(left < t)
                    {
                        min = left;
                        max = t;
                    }
                    else
                    {
                        min = t;
                        max = left;
                    }

                    other = right;
                    left = t;
                }
                else
                {
                    // 右手を動かす
                    if (right < t)
                    {
                        min = right;
                        max = t;
                    }
                    else
                    {
                        min = t;
                        max = right;
                    }

                    other = left;
                    right = t;
                }


                if(min <= other && other <= max)
                {
                    answer += N - max + min;
                }
                else
                {
                    answer += max - min;
                }
            }

            Console.WriteLine(answer);
        }

        public static void Main2(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split();
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            string[] H = new string[Q + 1];
            int[] T = new int[Q + 1];

            for (int i = 1; i <= Q; i++)
            {
                string[] HT = ReadStringArray();
                H[i] = HT[0];
                T[i] = int.Parse(HT[1]);
            }

            int answer = 0;

            int left = 1;
            int right = 2;
            for (int i = 1; i <= Q; i++)
            {
                string h = H[i];
                int t = T[i];

                int min = left < right ? left : right;
                int max = left < right ? right : left;

                bool isInRange = min <= t && t <= max;

                if (isInRange)
                {
                    if(h == "L")
                    {
                        // 左手を動かす
                        int move = t- left;
                        answer += Math.Abs(move);

                        left = t;
                    }
                    else
                    {
                        // 右手を動かす
                        int move = t - right;
                        answer += Math.Abs(move);

                        right = t;
                    }
                }
                else
                {
                    if(min == left)
                    {
                        if (h == "L")
                        {
                            // 左手を動かす
                            if(t <= left)
                            {
                                int move = left - t;
                                answer += Math.Abs(move);

                            }
                            else
                            {
                                int move = left + N - t;
                                answer += Math.Abs(move);
                            }

                            left = t;
                        }
                        else
                        {
                            // 右手を動かす
                            if (right <= t)
                            {
                                int move = t - right;
                                answer += Math.Abs(move);

                            }
                            else
                            {
                                int move = t + N  - right;
                                answer += Math.Abs(move);
                            }

                            right = t;
                        }

                    }
                    else
                    {
                        if (h == "L")
                        {
                            // 左手を動かす
                            if (left <= t)
                            {
                                int move = t - left;
                                answer += Math.Abs(move);

                            }
                            else
                            {
                                int move = t + N - left;
                                answer += Math.Abs(move);
                            }

                            left = t;
                        }
                        else
                        {
                            // 右手を動かす
                            if (t <= right)
                            {
                                int move = right - t;
                                answer += Math.Abs(move);

                            }
                            else
                            {
                                int move = N + right - t;
                                answer += Math.Abs(move);
                            }

                            right = t;
                        }
                    }
                }
            }


            Console.WriteLine(answer);
        }
    }
}
