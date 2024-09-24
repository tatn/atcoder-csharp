namespace AtCoderCsharp.OtherContests.typical90
{
    // 060 - Chimera（★5） ToDo

    internal class typical90_bh
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);



        }

    }
}
