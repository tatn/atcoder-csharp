using System.Collections.Generic;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC385
{
    internal class abc385_f
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] X = new int[N + 1];
            int[] H = new int[N + 1];

            for(int i = 1; i <= N; i++)
            {
                int[] XH = ReadIntArray();
                X[i] = XH[0];
                H[i] = XH[1];
            }

            double answer = -1d;
            bool isZeroHeight = true;
            for(int i = 1;i <= N-1; i++)
            {
                int x1 = X[i];
                int h1 = H[i];
                int x2 = X[i+1];
                int h2 = H[i+1];

                isZeroHeight = isZeroHeight && ( (long)h1 * (long)x2 < (long)h2 * (long)x1  );
                double h = (double)((long)h1* (long)x2 - (long)h2 * (long)x1) / (double)((long)x2 - (long)x1);
                answer = Math.Max(answer, h);
            }

            if(isZeroHeight || answer < 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                // 小数点10桁まで表示
                Console.WriteLine(answer.ToString("F10"));
            }
        }
    }
}
