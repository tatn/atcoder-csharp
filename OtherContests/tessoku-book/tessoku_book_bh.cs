using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_bh
    {
        //A60 - Stock Price 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();
            A.Insert(0,0);

            Stack<(int, int)> history = new Stack<(int, int)>();
            List<int> answers = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                while (0 < history.Count)
                {
                    (int day,int price) = history.Peek();

                    if (price < A[i])
                    {
                        history.Pop();
                    }
                    else
                    {
                        break;
                    }
                }

                if (history.Count == 0)
                {
                    answers.Add(-1);
                }
                else
                {
                    (int day, int price) = history.Peek();
                    answers.Add(day);
                }

                history.Push((i, A[i]));

            }
            Console.WriteLine(String.Join(" ", answers));
        }
    }
}