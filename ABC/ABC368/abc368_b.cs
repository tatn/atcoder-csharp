namespace AtCoderCsharp.ABC.ABC368
{
    internal class abc368_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            List<int> sortedList = A.ToList();

            int answer = 0;
            while (true)
            {
                sortedList.Sort();
                sortedList.Reverse();

                sortedList[0]--;
                sortedList[1]--;

                answer++;

                if (sortedList.Count(a=> 0 <a) <= 1)
                {
                    break;
                }

            }

            Console.WriteLine(answer);

        }
    }
}
