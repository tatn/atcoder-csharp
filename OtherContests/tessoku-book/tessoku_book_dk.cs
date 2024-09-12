
using System.Numerics;

namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_dk
    {
        // B38 - Heights of Grass 
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            string S = ReadString();

            List<int> aGrassList = new List<int>();
            aGrassList.Add(1);
            for (int i = 0; i < N-1; i++)
            {
                if (S[i] == 'A')
                {
                    aGrassList.Add(aGrassList[i]+1);
                }
                else
                {
                    aGrassList.Add(1);
                }
            }

            List<int> bGrassList = new List<int>();
            bGrassList.Add(1);
            for (int i = 0; i < N - 1; i++)
            {
                if (S[N-i-2] == 'B')
                {
                    bGrassList.Add(bGrassList[i] + 1);
                }
                else
                {
                    bGrassList.Add(1);
                }
            }
            bGrassList.Reverse();

            int answer = 0;
            for (int i = 0; i < N; i++)
            {
                answer += Math.Max(aGrassList[i], bGrassList[i]);
            }

            Console.WriteLine(answer);

        }
    }
}