namespace AtCoderCsharp.ABC.ABC111
{
    internal class arc103_a
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int n = ReadInt();
            int[] v = ReadIntArray();

            int v_max = 100_000;

            List<int> countNumberEven = new List<int>(v_max + 1);
            List<int> countNumberOdd = new List<int>(v_max + 1);
            for (int i = 0; i <= v_max; i++)
            {
                countNumberEven.Add(0);
                countNumberOdd.Add(0);
            }

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    countNumberEven[v[i - 1]]++;
                }
                else
                {
                    countNumberOdd[v[i - 1]]++;
                }
            }

            int maxCountOdd = countNumberOdd.Max();
            int maxCountIndexOdd = countNumberOdd.IndexOf(maxCountOdd);
            countNumberOdd[maxCountIndexOdd] = 0;

            int maxCountEven = countNumberEven.Max();
            int maxCountIndexEven = countNumberEven.IndexOf(maxCountEven);
            countNumberEven[maxCountIndexEven] = 0;

            int secondCountOdd = countNumberOdd.Max();
            int secondCountIndexOdd = countNumberOdd.IndexOf(secondCountOdd);

            int secondCountEven = countNumberEven.Max();
            int secondCountIndexEven = countNumberEven.IndexOf(secondCountEven);

            int answer = 0;
            if(maxCountIndexEven == maxCountIndexOdd)
            {
                int answer1 = 0;
                answer1 += n / 2 - maxCountOdd;
                answer1 += n / 2 - secondCountEven;
                int answer2 = 0;
                answer2 += n / 2 - secondCountOdd;
                answer2 += n / 2 - maxCountEven;

                answer = answer1 <= answer2 ? answer1 : answer2;
            }
            else
            {
                answer += n / 2 - maxCountOdd;
                answer += n / 2 - maxCountEven;
            }

            Console.WriteLine(answer);

        }

    }
}
