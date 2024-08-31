using System.Numerics;
namespace AtCoderCsharp.ABC.ABC369
{
    internal class abc369_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] AB = ReadIntArray();
            int A = AB[0];
            int B = AB[1];

            if(A == B)
            {
                Console.WriteLine(1);
                return;
            }

            if((A + B) % 2 == 0)
            {
                Console.WriteLine(3);
            }
            else
            {
                Console.WriteLine(2);
            }

        }
    }
}
