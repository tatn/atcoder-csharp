using System.Numerics;

namespace AtCoderCsharp.ABC.ABC376
{
    internal class abc376_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();
            List<int> B = ReadIntArray().ToList();

            A.Sort();
            B.Sort();

            A.Insert(0,0);
            B.Insert(0,0);

            int skipCount = 0;
            int needSize = 0;

            for (int i = N; 1<= i; i--)
            {
                if(i + skipCount - 1 < 0)
                {
                    break;
                }

                if (A[i] <= B[i+skipCount-1])
                {
                    continue;
                }

                skipCount++;

                if(2 <= skipCount)
                {
                    break;
                }

                needSize = A[i];
            }

            if (2 <= skipCount)
            {
                Console.WriteLine(-1);
            }
            else if (skipCount==1)
            {
                Console.WriteLine(needSize);
            }
            else
            {
                Console.WriteLine(A[1]);
            }


        }
    }
}
