namespace AtCoderCsharp.ABC.ABC372
{
    // 	
    internal class abc372_d
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> H = ReadIntArray().ToList();
            H.Insert(0, 0);


            List<int> answers = new List<int>();
            answers.Add(0);

            LinkedList<int> hIndexes = new LinkedList<int>();
            for (int i = N - 1; 1 <= i; i--)
            {

                while (hIndexes.Count > 0)
                {
                    if (H[hIndexes.First!.Value] < H[i + 1])
                    {
                        hIndexes.RemoveFirst();
                    }
                    else
                    {
                        break;
                    }
                }

                hIndexes.AddFirst(i + 1);

                answers.Add(hIndexes.Count);

            }

            answers.Reverse();

            Console.WriteLine(string.Join(" ",answers));


        }

    }
}
