
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_fk
    {
        //C13 - Select 2 

        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NP = ReadLongArray();
            long N = NP[0];
            long P = NP[1];

            long mod = 1_000_000_007L; 
            List<long> A = ReadLongArray().Select(x => x % mod).ToList();

            if(P == 0)
            {
                long zeroCount = A.Count(x => x == 0L);
                long a = zeroCount * (zeroCount - 1L) / 2L;
                a += zeroCount * (N - zeroCount);
                Console.WriteLine(a);
                return;
            }

            A.RemoveAll(x => x == 0);

            Dictionary<long, long> pairs = new Dictionary<long, long>();
            long answer = 0L;
            for (int i = 0; i < A.Count; i++)
            {
                long otherValue = GetOtherValue(A[i]);

                if(pairs.ContainsKey(otherValue))
                {
                    answer += pairs[otherValue];
                }

                if(pairs.ContainsKey(A[i]))
                {
                    pairs[A[i]]++;
                }
                else
                {
                    pairs.Add(A[i], 1);
                }
            }

            Console.WriteLine(answer);

            // ÷b <=> *b^(M-2) on mod
            long GetOtherValue(long x)
            {
                long power = GetPow(x, mod - 2);
                long value = (P * power) % mod;

                return value;
            }

            long GetPow(long x, long b)
            {
                long value = 1L;
                
                while(0 < b)
                {
                    if (b % 2L == 1L)
                    {
                        value = (value*x) % mod;
                    }

                    b /= 2L;
                    x = (x * x) % mod;
                }

                return value;
            }
        }
    }
}
