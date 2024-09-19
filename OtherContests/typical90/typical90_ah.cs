namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ah
    {
        // 034 - There are few types of elements（★4） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            List<int> a = ReadIntArray().ToList();
            a.Insert(0, 0);

            int[] numberCount = new int[1_000_000_001];

            int answer = 0;
            int countK = 0;
            int currentIndex = 1;
            for (int i = 1; i <= N; i++)
            {
                while(currentIndex <= N)
                {
                    if(N < currentIndex)
                    {
                        break;
                    }

                    if (numberCount[a[currentIndex]] == 0)
                    {
                        if(countK == K)
                        {
                            // すでにK種類の数字がある場合
                            break;
                        }

                        countK++;
                    }

                    numberCount[a[currentIndex]]++;
                    currentIndex++;
                }

                answer = Math.Max(answer, currentIndex - i);
                numberCount[a[i]]--;
                if (numberCount[a[i]] == 0)
                {
                    countK--;
                }
            }

            Console.WriteLine(answer);


        }
    }
}
