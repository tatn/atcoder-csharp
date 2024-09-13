using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_bm
    {
        //A65 - Road to Promotion 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, -1);
            A.Insert(0, -1);

            List<int>[] G = new List<int>[N + 1];
            for (int i = 0; i < N+1; i++)
            {
                G[i] = new List<int>();
            }

            for (int i = 2; i <= N; i++)
            {
                G[A[i]].Add(i);
            }

            int[] answer = new int[N + 1];

            int GetMemeberCount(int index)
            {
                int count = 0;
                foreach (int next in G[index])
                {
                    count += GetMemeberCount(next) + 1;
                }

                answer[index] = count;
                return count;
            }

            GetMemeberCount(1);


            Console.WriteLine(string.Join(" ", answer.Skip(1)));

        }
    }
}