
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_fe
    {
        //C07 - ALGO-MARKET 

        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> C = ReadIntArray().ToList();
            int Q = ReadInt();

            int[] X = new int[Q + 1];
            for (int i = 1; i <= Q; i++)
            {
                X[i] = ReadInt();
            }

            C.Sort();

            List<int> Sum = new List<int>();
            Sum.Add(C.First());
            for (int i = 1; i < N ; i++)
            {
                Sum.Add(Sum[i - 1] + C[i]);
            }


            for (int i = 1; i <= Q; i++)
            {
                int index = Sum.BinarySearch(X[i]);

                if(index < 0)
                {
                    index = ~index;
                }
                else
                {
                    index = index + 1;
                }

                Console.WriteLine(index);

            }

        }
    }
}
