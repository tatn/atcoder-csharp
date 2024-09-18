namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_aj
    {
        // 036 - Max Manhattan Distance（★5） 
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        }
    }
}
