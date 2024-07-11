namespace AtCoderCsharp.AGC.AGC032
{
    internal class agc032_a
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] b = ReadIntArray();

            List<int> B = b.ToList();
            Stack<int> stack = new Stack<int>();

            int operationCount = 0;
            while (true)
            {
                bool found = false;
                for (int i = N - operationCount; 1 <= i; i--)
                {
                    int findIndex = B.IndexOf(i);
                    if(0 <= findIndex && findIndex == i - 1)
                    {
                        stack.Push(i);
                        B.RemoveAt(findIndex);
                        operationCount++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    break;
                }
            }
            
            if(operationCount < N)
            {
                Console.WriteLine(-1);
            }
            else
            {
                while(0 < stack.Count)
                {
                    Console.WriteLine(stack.Pop());
                }
            }
        }

    }
}
