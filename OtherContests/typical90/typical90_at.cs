namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_at
    {
        // 046 - I Love 46（★3） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();
            int[] B = ReadIntArray();
            int[] C = ReadIntArray();

            int mod = 46;

            int[] countA = new int[mod];
            int[] countB = new int[mod];
            int[] countC = new int[mod];

            for (int i = 0; i < N; i++)
            {
                countA[A[i] % mod]++;
                countB[B[i] % mod]++;
                countC[C[i] % mod]++;
            }

            long ans = 0L;
            for (int i = 0; i <= 45; i++)
            {
                for (int j = 0; j <= 45; j++)
                {
                    int need = mod - i - j;
                    if (need < 0)
                    {
                        need += mod;
                    }
                    if (need < 0)
                    {
                        need += mod;
                    }
                    need %= mod;
                    ans += (long)countA[i] * countB[j] * countC[need];

                }
            }

            Console.WriteLine(ans);
        }
    }
}
