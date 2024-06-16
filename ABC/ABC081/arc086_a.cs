namespace AtCoderCsharp.ABC.ABC081
{
    internal class arc086_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = ReadIntArray();

            int[] countArray = new int[N + 1];

            for (int i = 0; i < N; i++)
            {
                countArray[A[i]] = countArray[A[i]] + 1;
            }

            int[] sortedArray = countArray.OrderBy(x => x).Where(x => x != 0).ToArray();
            int countIntegerNumber = sortedArray.Count();

            if (countIntegerNumber <= K)
            {
                Console.WriteLine(0);
                return;
            }

            int needReWriteNumner = countIntegerNumber - K;

            int answer = 0;
            for (int i = 0; i < needReWriteNumner; i++)
            {
                answer += sortedArray[i];

            }

            Console.WriteLine(answer);
        }
    }
}
