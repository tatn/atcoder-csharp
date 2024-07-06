using System.Numerics;
namespace AtCoderCsharp.ABC.ABC361
{
    internal class abc361_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] abcdef = ReadIntArray();
            int a = abcdef[0];
            int b = abcdef[1];
            int c = abcdef[2];
            int d = abcdef[3];
            int e = abcdef[4];
            int f = abcdef[5];

            int[] ghijkl = ReadIntArray();
            int g = ghijkl[0];
            int h = ghijkl[1];
            int i = ghijkl[2];
            int j = ghijkl[3];
            int k = ghijkl[4];
            int l = ghijkl[5];

            bool isOut = false;

            isOut = isOut || j <= a || d <= g;
            isOut = isOut || k <= b || e <= h;
            isOut = isOut || l <= c || f <= i;

            Console.WriteLine(isOut ? "No" : "Yes");
        }
    }
}
