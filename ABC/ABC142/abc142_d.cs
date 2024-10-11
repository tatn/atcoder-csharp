namespace AtCoderCsharp.ABC.ABC142
{
    internal class abc142_d
    {
        // D - Disjoint Set of Common Divisors 

        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] AB = ReadLongArray();
            long A = AB[0];
            long B = AB[1];

            List<long> divisorsA = new List<long>();

            for (long i = 1L; i * i <= A; i++)
            {
                if(A % i != 0L)
                {
                    continue;
                }

                divisorsA.Add(i);

                if(i * i != A)
                {
                    divisorsA.Add(A/i);
                }
            }

            divisorsA.Sort();

            List<long> divisorsB = new List<long> ();

            for (long i = 1L; i * i <= B; i++)
            {
                if (B % i != 0L)
                {
                    continue;
                }

                divisorsB.Add(i);

                if (i * i != B)
                {
                    divisorsB.Add(B / i);
                }
            }

            divisorsB.Sort();

            //Console.WriteLine(string.Join(" ", divisorsA));
            //Console.WriteLine(string.Join(" ", divisorsB));

            List<long> commonDivisors = new List<long>();
            if (A < B)
            {
                foreach (long i in divisorsA)
                {
                    if(0 <= divisorsB.BinarySearch(i))
                    {
                        commonDivisors.Add(i);
                    }
                }
            }
            else
            {
                foreach (long i in divisorsB)
                {
                    if (0 <= divisorsA.BinarySearch(i))
                    {
                        commonDivisors.Add(i);
                    }
                }
            }

            //Console.WriteLine(string.Join(" ", commonDivisors));

            int answer = 0;

            foreach (long i in commonDivisors)
            {
                bool isPrime = true;

                for (long j = 2L; j<= Math.Sqrt(i+1); j++)
                {
                    if (i % j == 0L)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);
        }

    }
}
