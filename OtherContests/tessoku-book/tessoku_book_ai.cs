
using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_ai
    {
        public static void Main(string[] args)
        {
            // A35 - Game 4 
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            List<int> list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                list.Add(A[i]);
            }

            for (int i = N-1; 1 <= i; i--)
            {
                List<int> workList = new List<int>();
                if (i % 2 == 0)
                {
                    //次郎 最小化
                    for (int j = 0; j < list.Count - 1; j++)
                    {
                        workList.Add(Math.Min(list[j], list[j + 1]));
                    }
                }
                else
                {
                    //太郎 最大化
                    for (int j = 0; j < list.Count -1 ; j++)
                    {
                        workList.Add(Math.Max(list[j], list[j+1]));
                    }
                }

                list = workList;
            }

            Console.WriteLine(list[0]);

        }
    }
}