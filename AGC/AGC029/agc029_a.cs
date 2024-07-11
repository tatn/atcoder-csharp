namespace AtCoderCsharp.AGC.AGC029
{
    internal class agc029_a
    {
        public static void Main(string[] args)
        {
            char[] input1 = Console.ReadLine()!.ToCharArray();
            int n = input1.Length;

            bool[] bools = new bool[n];
            bools = input1.Select(x => x == 'B').ToArray();

            if(bools.All(x => x) || bools.All(x => !x))
            {
                Console.WriteLine(0);
                return;
            }

            int[] whiteCountFromRight = new int[n];
            for (int i = n -1 ; i >= 0; i--)
            {
                whiteCountFromRight[n-i-1] = (bools[i] ? 0 : 1 ) + (i == n-1 ? 0 : whiteCountFromRight[n-i-2]);
            }


            long answer = 0;
            for (int i = 0; i < n-1; i++)
            {
                if (bools[i])
                {
                    answer += whiteCountFromRight[n-i-2];
                }
            }

            Console.WriteLine(answer);
        }

    }
}
