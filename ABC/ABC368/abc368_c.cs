using System.Numerics;

namespace AtCoderCsharp.ABC.ABC368
{
    internal class abc368_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] H = ReadIntArray();

            long T = 0;
            int enemyCount = N;
            for (int i = 0; i < N; i++)
            {
                int hitPoint = H[i];

                int tripleTurnCount = hitPoint / 5;
                T += tripleTurnCount * 3;

                hitPoint -= tripleTurnCount * 5;

                while(0 < hitPoint)
                {
                    T++;
                    switch (T % 3)
                    {
                        case 0:
                            hitPoint -= 3;
                            break;
                        case 1:
                        case 2:
                            hitPoint--;
                            break;
                    }
                }
            }

            Console.WriteLine(T);            
        }
    }
}
