namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_g
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();

            int Q = ReadInt();

            int[] B = new int[Q + 1];
            for (int i = 1; i <= Q; i++)
            {
                B[i] = ReadInt();
            }

            A.Sort();

            for (int i = 1; i <= Q; i++)
            {
                int index = A.BinarySearch(B[i]);

                if(index < 0)
                {
                    index = ~index;

                    if(index == 0)
                    {
                        Console.WriteLine(Math.Abs(A[0] - B[i]));
                    }
                    else if( N <= index )
                    {
                        Console.WriteLine(Math.Abs(A[N-1] - B[i]));
                    }
                    else
                    {
                        Console.WriteLine(Math.Min(Math.Abs(A[index -1 ] - B[i]), Math.Abs(A[index] - B[i])));

                    }

                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
