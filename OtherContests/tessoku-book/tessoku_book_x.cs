
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_x
    {
        //A24 - LIS 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            int answer = 1;
            List<int> B = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                int findIndex = B.BinarySearch(A[i]);

                if(findIndex < 0)
                {
                    findIndex = ~findIndex;
                    if(B.Count <= findIndex)
                    {
                        B.Insert(findIndex, A[i]);

                        answer = Math.Max(answer, B.Count);
                    }
                    else
                    {
                        if (A[i] < B[findIndex])
                        {
                            B[findIndex] = A[i];
                        }
                    }
                }
            }

            Console.WriteLine(answer);

        }
    }
}
