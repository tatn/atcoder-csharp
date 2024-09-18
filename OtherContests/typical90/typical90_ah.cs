namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ah
    {
        // 034 - There are few types of elements（★4） 
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        }
    }
}
