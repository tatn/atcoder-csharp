namespace AtCoderCsharp.ABC.ABC359
{
    internal class abc359_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();
            List<int> AList = A.ToList();

            int answer = 0;
            for (int i = 1; i <= N; i++)
            {
                int left =AList.IndexOf(i);
                int right = AList.IndexOf(i,left+1);

                if(left + 2 == right)
                {
                    answer++;
                }

            }

            Console.WriteLine(answer);

        }
    }
}
