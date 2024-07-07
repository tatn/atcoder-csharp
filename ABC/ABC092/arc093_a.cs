using System.Numerics;

namespace AtCoderCsharp.ABC.ABC092
{
    internal class arc093_a
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            List<int> Spots = new List<int>();
            Spots.Add(0);
            Spots.AddRange(A);
            Spots.Add(0);

            int basePrice = 0;
            for (int i = 0; i < Spots.Count - 1; i++)
            {
                basePrice += Math.Abs(Spots[i + 1] - Spots[i]);
            }

            int[] diff = new int[N];

            for (int i = 1; i <= N; i++)
            {
                if (Spots[i - 1] <= Spots[i] && Spots[i] <= Spots[i + 1])
                {
                    diff[i-1] = 0;
                }
                else
                {
                    diff[i-1] = Math.Abs(Spots[i + 1] - Spots[i - 1]) - Math.Abs(Spots[i] - Spots[i - 1]) - Math.Abs(Spots[i + 1] - Spots[i]);
                }
            }

            foreach (int i in diff)
            {
                Console.WriteLine(basePrice + i);
            }
        }
    }
}
