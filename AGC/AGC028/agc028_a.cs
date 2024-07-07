namespace AtCoderCsharp.AGC.AGC028
{
    internal class agc028_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            string S = ReadString();
            string T = ReadString();

            long lcm = GetLCM(N, M);

            List<int> sFindIndex = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int index = 1 + (int)((long)i * lcm / (long)N);
                sFindIndex.Add(index);
            }

            List<int> tFindIndex = new List<int>();
            for (int i = 0; i < M; i++)
            {
                int index = 1 + (int)((long)i * lcm / (long)M);
                tFindIndex.Add(index);
            }

            bool exists = true;
            foreach (int index in sFindIndex)
            {
                int originalTIndex = tFindIndex.BinarySearch(index);
                if (0 <= originalTIndex)
                {
                    int originalSIndex = sFindIndex.BinarySearch(index);

                    if (S[originalSIndex] != T[originalTIndex])
                    {
                        exists = false;
                        break;
                    }
                }
            }

            Console.WriteLine(exists ? lcm : -1);

        }

        static long GetGCD(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }

            return GetGCD(b, a % b);
        }


        static long GetLCM(long a, long b)
        {
            long gcd = GetGCD(a, b);
            return a * b / gcd;
        }
    }
}
