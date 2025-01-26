using System.Numerics;

namespace AtCoderCsharp.ABC.ABC390
{
    internal class abc390_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] AInput = ReadIntArray();
            List<int> AList = AInput.ToList();
            AList.Insert(0, 0);

            if (N == 2)
            {
                Console.WriteLine("Yes");
                return;
            }

            for (int i = 2; i <= N - 1; i++)
            {
                if (((long)AList[i])* ((long)AList[i]) != ((long)AList[i-1]) * ((long)AList[i+1]))
                {
                    Console.WriteLine("No");
                    return;
                }
               
            }
            Console.WriteLine("Yes");

        }
    }
}
