namespace AtCoderCsharp.ABC.ABC120
{
    internal class abc120_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int[] ABK = ReadIntArray();

            int A = ABK[0];
            int B = ABK[1];
            int K = ABK[2];

            int count = 0;
            int answer = 0;
            for (int i = Math.Min(A, B); 1 <= i; i--)
            {
                if(A % i == 0 && B % i == 0)
                {
                    count++;
                }

                if (count == K)
                {
                    answer = i;
                    break;
                }

            }

            Console.WriteLine(answer);
        }

        int[] GetDivisors(int x)
        {
            if (x == 1)
            {
                return new int[] { 1 };
            }

            List<int> divisors = new List<int>();

            for (int i = 1; i * i <= x; i++)
            {
                if (x % i == 0)
                {
                    divisors.Add(i);
                    if (x / i != i)
                    {
                        divisors.Add(x / i);
                    }
                }
            }

            divisors.Sort();

            return divisors.ToArray();
        }
    }
}
