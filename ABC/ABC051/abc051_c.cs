using System.Text;

namespace AtCoderCsharp.ABC.ABC051
{
    internal class abc051_c
    {
        // C - Back and Forth 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] sxsytxty = ReadIntArray();
            int sx = sxsytxty[0];
            int sy = sxsytxty[1];
            int tx = sxsytxty[2];
            int ty = sxsytxty[3];

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= ty - sy; i++)
            {
                sb.Append("U");
            }

            for (int i = 1; i <= tx - sx; i++)
            {
                sb.Append("R");
            }

            for (int i = 1; i <= ty - sy; i++)
            {
                sb.Append("D");
            }

            for (int i = 1; i <= tx - sx + 1; i++)
            {
                sb.Append("L");
            }

            for (int i = 1; i <= ty - sy + 1; i++)
            {
                sb.Append("U");
            }

            for (int i = 1; i <= tx - sx + 1; i++)
            {
                sb.Append("R");
            }

            sb.Append("D");
            sb.Append("R");

            for (int i = 1; i <= ty - sy + 1; i++)
            {
                sb.Append("D");
            }

            for (int i = 1; i <= tx - sx + 1; i++)
            {
                sb.Append("L");
            }

            sb.Append("U");

            Console.WriteLine(sb.ToString());
        }

    }
}
