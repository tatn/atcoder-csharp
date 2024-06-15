namespace AtCoderCsharp.ABC.ABC065
{
    internal class abc065_b
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            int[] a = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                string input2 = Console.ReadLine()!;
                a[i] = int.Parse(input2);
            }

            int answer = 0;
            int current = 1;
            List<int> pushed = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                int next = a[current];

                if (next == 2)
                {
                    answer = i;
                    break;
                }

                if (pushed.Contains(current))
                {
                    answer = -1;
                    break;
                }

                pushed.Add(current);

                current = next;
            }

            Console.WriteLine(answer);

        }

    }
}
