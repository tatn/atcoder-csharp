
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_ee
    {
        //B58 - Jumping 
        public static void Main(string[] args)
        {
            //ToDo
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NLR = ReadIntArray();
            int N = NLR[0];
            int L = NLR[1];
            int R = NLR[2];

            List<int> X = ReadIntArray().ToList();
            X.Insert(0, 0);




        }
    }
}