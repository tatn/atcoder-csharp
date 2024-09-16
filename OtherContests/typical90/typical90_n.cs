namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_n
    {
        // 014 - We Used to Sing a Song Together（★3） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();
            List<int> B = ReadIntArray().ToList();

            A.Sort();
            B.Sort();

            List<int> SamePositions = new List<int>();

            for (int i = 0; i < N; i++)
            {
                int a = A[i];

                int findIndex = B.BinarySearch(a);

                if (0 <= findIndex)
                {
                    SamePositions.Add(a);
                }
            }

            List<int> AExcluded = new List<int>();
            List<int> BExcluded = new List<int>();

            for (int i = 0; i < N; i++)
            {
                if (SamePositions.BinarySearch(A[i]) < 0)
                {
                    AExcluded.Add(A[i]);
                }
                if (SamePositions.BinarySearch(B[i]) < 0)
                {
                    BExcluded.Add(B[i]);
                }
            }

            long answer = 0L;

            for (int i = 0; i < AExcluded.Count; i++)
            {
                answer += Math.Abs(AExcluded[i] - BExcluded[i]);
            }

            Console.WriteLine(answer);

        }
    }
}
