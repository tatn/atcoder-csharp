namespace AtCoderCsharp.ABC.ABC066
{
    internal class arc077_a
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int n = ReadInt();

            int[] a = new int[n + 1];
            int[] aInput = ReadIntArray();
            for (int i = 1; i <= n; i++)
            {
                a[i] = aInput[i-1];
            }

            List<int> answerList = new List<int>();
            if (n % 2 == 0)
            {
                for (int i = n; 2 <= i; i = i - 2)
                {
                    answerList.Add(a[i]);
                }

                for (int i = 1; i <= n - 1; i = i + 2)
                {
                    answerList.Add(a[i]);
                }
            }
            else
            {
                for (int i = n; 3 <= i; i = i - 2)
                {
                    answerList.Add(a[i]);
                }

                answerList.Add(a[1]);

                for (int i = 2; i <= n - 1; i = i + 2)
                {
                    answerList.Add(a[i]);
                }
            }

            Console.WriteLine(String.Join(" ", answerList));
        }
    }
}
