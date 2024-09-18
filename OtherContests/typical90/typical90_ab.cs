namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ab
    {
        // 028 - Cluttered Paper（★4） 
        public static void Main(string[] args)
        {

            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[,] lxy = new int[N + 1, 2];
            int[,] rxy = new int[N + 1, 2];

            for (int i = 1; i <= N; i++)
            {
                int[] input = ReadIntArray();
                lxy[i, 0] = input[0];
                lxy[i, 1] = input[1];
                rxy[i, 0] = input[2];
                rxy[i, 1] = input[3];
            }

            int[,] diff = new int[1001, 1001];

            for (int i = 1; i <= N; i++)
            {
                int lx = lxy[i, 0];
                int ly = lxy[i, 1];
                int rx = rxy[i, 0];
                int ry = rxy[i, 1];

                diff[lx, ly]++;
                diff[lx, ry]--;
                diff[rx, ly]--;
                diff[rx, ry]++;
            }

            int[,] sum = new int[1001, 1001];

            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    sum[j,i] = (j - 1 < 0 ? 0 : sum[j-1,i])  + diff[j,i];
                }
            }

            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    sum[i, j] = (j - 1 < 0 ? 0 : sum[i, j-1]) + sum[i, j];
                }
            }

            int[] answer = new int[N + 1];
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    answer[sum[i, j]]++;
                }
            }

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(answer[i]);                
            }
        }
    }
}
