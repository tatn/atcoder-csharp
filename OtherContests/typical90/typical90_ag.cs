namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ag
    {
        // 033 - Not Too Bright（★2） 
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        }
    }
}
