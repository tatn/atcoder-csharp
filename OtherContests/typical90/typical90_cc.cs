namespace AtCoderCsharp.OtherContests.typical90
{
    //  081 - Friendly Group（★5）

    internal class typical90_cc
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = new int[N + 1];
            int[] B = new int[N + 1];

            int[,] studentCount = new int[5001, 5001];

            for (int i = 1; i <= N; i++)
            {
                int[] ab = ReadIntArray();
                A[i] = ab[0];
                B[i] = ab[1];

                studentCount[A[i], B[i]]++;
            }

            int[,] sum = new int[5001, 5001];
            
            for (int i = 1; i <= 5000; i++)
            {
                for (int j = 1; j <= 5000; j++)
                {
                    sum[i, j] = sum[i, j - 1] + studentCount[i, j];
                }
            }

            for (int i = 1; i <= 5000; i++)
            {
                for (int j = 1; j <= 5000; j++)
                {
                    sum[j, i] = sum[j, i] + sum[j - 1, i];
                }
            }

            int answer = 0;

            for (int i = 1; i <= 5000; i++)
            {
                for (int j = 1; j <= 5000; j++)
                {
                    // (i,j) - (i+k, j+k) の範囲の生徒数
                    int heightMax = i + K;
                    heightMax = 5000 < heightMax ? 5000 : heightMax;

                    int widthMax = j + K;
                    widthMax = 5000 < widthMax ? 5000 : widthMax;
                    int count = sum[heightMax, widthMax] - sum[heightMax, j - 1] - sum[i - 1, widthMax] + sum[i - 1, j - 1];
                    
                    answer = Math.Max(answer, count);
                }
            }

            Console.WriteLine(answer);

        }

        public static void Main2(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = new int[N + 1];
            int[] B = new int[N + 1];

            List<(int, int)> AB = new List<(int, int)>();

            int aMin = 5000;
            int aMax = 1;
            int bMin = 5000;
            int bMax = 1;

            for (int i = 1; i <= N; i++)
            {
                int[] ab = ReadIntArray();
                A[i] = ab[0];
                B[i] = ab[1];
                AB.Add((A[i], B[i]));

                aMin = Math.Min(aMin, A[i]);
                aMax = Math.Max(aMax, A[i]);

                bMin = Math.Min(bMin, B[i]);
                bMax = Math.Max(bMax, B[i]);
            }

            AB.Sort((a, b) => a.Item1 - b.Item1);

            int answer = 0;

            for (int a = aMin; a <= aMax; a++)
            {
                for (int b = bMin; b <= bMax; b++)
                {
                    int aIndexLeft = AB.BinarySearch((a, b), Comparer<(int, int)>.Create((x, y) => 0 <= x.Item1 - y.Item1 ? 1 :-1));
                    int aIndexright = AB.BinarySearch((a+K, b), Comparer<(int, int)>.Create((x, y) => 0 < x.Item1 - y.Item1 ? 1 : -1));

                    if (aIndexLeft < 0)
                    {
                        aIndexLeft = ~aIndexLeft;
                    }

                    if (AB.Count <= aIndexLeft)
                    {
                        continue;
                    }

                    if(aIndexright < 0)
                    {
                        aIndexright = ~aIndexright;
                        aIndexright -= 1;
                    }


                    if (aIndexright < aIndexLeft)
                    {
                        continue;
                    }

                    int countStudent = aIndexright - aIndexLeft + 1;

                    if(countStudent <= answer)
                    {
                        continue;
                    }

                    for (int i = aIndexLeft; i <= aIndexright; i++)
                    {
                        if (AB[i].Item2 < b || b + K < AB[i].Item2 )
                        {
                            countStudent--;
                        }

                        if (countStudent <= answer)
                        {
                            break;
                        }
                    }

                    answer = Math.Max(answer, countStudent);
                }
            }

            Console.WriteLine(answer);


        }
    }
}
