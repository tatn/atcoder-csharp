using System.Numerics;
namespace AtCoderCsharp.ABC.ABC363
{
    internal class abc363_a
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int R= ReadInt();

            if(1<=R && R <= 99)
            {
                Console.WriteLine(100 - R);
            }
            else if (100 <= R && R <= 199)
            {
                Console.WriteLine(200 - R);
            }
            else if (200 <= R && R <= 299)
            {
                Console.WriteLine(300 - R);
            }
        }
    }
}
