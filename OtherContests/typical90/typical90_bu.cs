namespace AtCoderCsharp.OtherContests.typical90
{
    // 073 - We Need Both a and b（★5） ToDo

    internal class typical90_bu
    {
        public static void Main(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<string> c = ReadStringArray().ToList();
            c.Insert(0, "");

            int[] a = new int[N];
            int[] b = new int[N];

            for (int i = 1; i <= N-1; i++)
            {
                int[] ab = ReadIntArray();
                a[i] = ab[0];
                b[i] = ab[1];
            }



        }
    }
}
