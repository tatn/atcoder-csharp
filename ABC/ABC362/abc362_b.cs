using System.Numerics;
namespace AtCoderCsharp.ABC.ABC362
{
    internal class abc362_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] x = new int[3];
            int[] y = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int[] xy = ReadIntArray();
                x[i] = xy[0];
                y[i] = xy[1];
            }

            int ab2 = (x[0] - x[1]) * (x[0] - x[1]) + (y[0] - y[1]) * (y[0] - y[1]);
            int bc2 = (x[1] - x[2]) * (x[1] - x[2]) + (y[1] - y[2]) * (y[1] - y[2]);
            int ca2 = (x[2] - x[0]) * (x[2] - x[0]) + (y[2] - y[0]) * (y[2] - y[0]);

            int max  = Math.Max(ab2, bc2);
            max = Math.Max(max, ca2);

            bool is90 = false;
            if (max == ab2)
            {
                is90 = ab2 == (bc2 + ca2);
            }
            else if (max == bc2)
            {
                is90 = bc2 == (ca2 + ab2);
            }
            else if (max == ca2)
            {
                is90 = ca2 == (ab2 + bc2);
            }

            Console.WriteLine(is90 ? "Yes" : "No");
        }
    }
}
