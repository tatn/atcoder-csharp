namespace AtCoderCsharp.AGC.AGC040
{
    internal class agc040_a
    {
        public static void Main(string[] args)
        {
            char[] input1 = Console.ReadLine()!.ToCharArray();
            int N = input1.Length + 1;

            long[] a = new long[N + 2];
            a[0] = ((long)Math.Pow(10, 5)) +1;
            for (int i = 1; i <= N; i++)
            {
                a[i] = -1;
            }
            a[N + 1] = ((long)Math.Pow(10, 5)) + 1;

            char[] chars = new char[N + 1];
            chars[0] = '>';
            for (int i = 0; i < N - 1; i++)
            {
                chars[i + 1] = input1[i];
            }
            chars[N] = '<';


            if (N == 2)
            {
                Console.WriteLine(1);
                return;
            }

            HashSet<int> indexes = new HashSet<int>(N);
            for (int i = 1; i <= N; i++)
            {
                indexes.Add(i);
            }


            Queue<int> targetIndex = new Queue<int>(N);

            while (true)
            {
                if(targetIndex.Count == 0)
                {
                    foreach (int i in indexes)
                    {

                        if (chars[i - 1] == '>' && chars[i] == '<')
                        {
                            targetIndex.Enqueue(i);
                        }
                        else if (chars[i - 1] == '>' && chars[i] == '>')
                        {
                            if (0 <= a[i + 1])
                            {
                                targetIndex.Enqueue(i);
                            }
                        }
                        else if (chars[i - 1] == '<' && chars[i] == '<')
                        {
                            if (0 <= a[i - 1])
                            {
                                targetIndex.Enqueue(i);
                            }
                        }
                        else if (chars[i - 1] == '<' && chars[i] == '>')
                        {
                            if(0 <= a[i - 1] && 0 <= a[i + 1])
                            {
                                targetIndex.Enqueue(i);
                            }
                        }
                    }
                }

                if (targetIndex.Count == 0)
                {
                    break;
                }

                while (0 < targetIndex.Count)
                {
                    int index = targetIndex.Dequeue();

                    if (chars[index-1] == '>' && chars[index] == '<')
                    {
                        a[index] = 0;
                        indexes.Remove(index);
                        if (1 <= index - 1)
                        {
                            targetIndex.Enqueue(index - 1);
                        }
                        if (index + 1 <= N)
                        {
                            targetIndex.Enqueue(index + 1);
                        }

                    }
                    else if (chars[index - 1] == '>' && chars[index] == '>')
                    {
                        if (0 <= a[index + 1])
                        {
                            a[index] = a[index + 1] + 1;
                            indexes.Remove(index);

                            if (1 <= index - 1)
                            {
                                targetIndex.Enqueue(index - 1);
                            }
                        }
                    }
                    else if (chars[index - 1] == '<' && chars[index] == '<')
                    {
                        if (0 <= a[index - 1])
                        {
                            a[index] = a[index - 1] + 1;
                            indexes.Remove(index);

                            if (index + 1 <= N)
                            {
                                targetIndex.Enqueue(index + 1);
                            }
                        }
                    }
                    else if (chars[index - 1] == '<' && chars[index] == '>')
                    {
                        if (0 <= a[index - 1] && 0 <= a[index + 1])
                        {
                            a[index] = Math.Max(a[index - 1], a[index + 1]) + 1;
                            indexes.Remove(index);
                        }
                    }
                }

            }

            long answer = 0;
            for (int i = 1; i <= N; i++)
            {
                answer += a[i];
            }

            Console.WriteLine(answer);

            //"<>>><<><<<<<>>><"
            //"0<>>>0<<>0<<<<<>>>0<"
            //"0<>2>1>0<1<>0<1<2<3<4<>2>1>0<1"
            //"0<3>2>1>0<1<2>0<1<2<3<4<5>2>1>0<1"

            //"0<3>2>1>0<1<2>0<1<2<3<4<5>2>1>0<1"
            //"3+2+1+1+2+1+2+3+4+5+2+1+0+1"
        }

    }
}
