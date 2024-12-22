namespace AtCoderCsharp.ABC.ABC134
{
    // D - Preparing Boxes

    internal class abc134_d
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> a = ReadIntArray().ToList();
            a.Insert(0, 0);

            int[] remains = new int[N + 1];

            for (int i = N; 1 <= i; i--)
            {
                int sum = 0;
                for(int j = 2; i*j <= N; j++)
                {
                    sum += remains[i*j];
                }

                sum %= 2;

                if (a[i] == 1)
                {
                    if(sum == 1)
                    {
                        remains[i] = 0;
                    }
                    else
                    {
                        remains[i] = 1;                        
                    }
                }
                else
                {
                    if (sum == 1)
                    {
                        remains[i] = 1;
                    }
                    else
                    {
                        remains[i] = 0;
                    }
                }
            }

            List<int> answers = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                if (remains[i] == 1)
                {
                    answers.Add(i);
                }               
            }

            Console.WriteLine(answers.Count);
            if(0 < answers.Count)
            {
                Console.WriteLine(String.Join(" ", answers));
            }
        }

    }
}
