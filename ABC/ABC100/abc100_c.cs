namespace AtCoderCsharp.ABC.ABC100
{
    internal class abc100_c
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine()!;
            int N = int.Parse(input1);

            string[] input2 = Console.ReadLine()!.Split();
            int[] a = input2.Select(int.Parse).ToArray();

            int M = 29;
            int[] twoPower = new int[M];
            for (int i = 0 ; i < M; i++)
            {
                twoPower[i] = 2 << i;   
            }

            int answer = 0;
            for (int i = 0; i < N; i++)
            {
                int a_i = a[i];
                for (int j = M-1; 0 <= j ; j --)
                {
                    if (a_i % twoPower[j] == 0)
                    {
                        answer += j + 1;
                        break;
                    }
                }                
            }

            Console.WriteLine(answer);

        }
    }
}
