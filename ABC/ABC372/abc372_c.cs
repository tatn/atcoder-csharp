namespace AtCoderCsharp.ABC.ABC372
{
    // 	
    internal class abc372_c
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            string S = ReadString();

            int[] X = new int[Q+1];
            string[] C = new string[Q+1];

            for (int i = 1; i <= Q; i++)
            {
                string[] xc = ReadStringArray();
                X[i] = int.Parse(xc[0]);
                C[i] = xc[1];
            }

            char[] chars = S.ToCharArray();

            int abcCount = 0;
            for (int i = 0; i <= N-3; i++)
            {
                if (chars[i] == 'A' && chars[i+1] == 'B' && chars[i+2] == 'C')
                {
                    abcCount++;
                }
            }

            for (int i = 1; i <= Q; i++)
            {
                int x = X[i];
                string c = C[i];

                int targetIndex = x - 1;    
                string beforeString = chars[targetIndex].ToString();

                if(c == beforeString)
                {
                    Console.WriteLine(abcCount);
                    continue;
                }

                int beforeCount = 0;

                if (beforeString == "A")
                {
                    if (targetIndex + 2 <= N - 1)
                    {
                        if (chars[targetIndex + 1] == 'B' && chars[targetIndex + 2] == 'C')
                        {
                            beforeCount++;
                        }
                    }
                }
                else if (beforeString == "B")
                {
                    if (0 <= targetIndex - 1 &&  targetIndex + 1 <= N - 1)
                    {
                        if (chars[targetIndex - 1] == 'A' && chars[targetIndex + 1] == 'C')
                        {
                            beforeCount++;
                        }
                    }

                }
                else if (beforeString == "C")
                {
                    if (0 <= targetIndex - 2)
                    {
                        if (chars[targetIndex - 2] == 'A' && chars[targetIndex -1] == 'B')
                        {
                            beforeCount++;
                        }
                    }
                }
                else
                {

                }

                int afterCount = 0;
                if (c == "A")
                {
                    if (targetIndex + 2 <= N - 1)
                    {
                        if (chars[targetIndex + 1] == 'B' && chars[targetIndex + 2] == 'C')
                        {
                            afterCount++;
                        }
                    }
                }
                else if (c == "B")
                {
                    if (0 <= targetIndex - 1 && targetIndex + 1 <= N - 1)
                    {
                        if (chars[targetIndex - 1] == 'A' && chars[targetIndex + 1] == 'C')
                        {
                            afterCount++;
                        }
                    }

                }
                else if (c == "C")
                {
                    if (0 <= targetIndex - 2)
                    {
                        if (chars[targetIndex - 2] == 'A' && chars[targetIndex - 1] == 'B')
                        {
                            afterCount++;
                        }
                    }
                }
                else
                {

                }

                int diff = afterCount - beforeCount;
                abcCount += diff;
                Console.WriteLine(abcCount);

                chars[targetIndex] = c[0];
            }
        }
    }
}
