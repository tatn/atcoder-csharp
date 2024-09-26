namespace AtCoderCsharp.OtherContests.typical90
{
    //  081 - Friendly Group（★5） ToDo

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
