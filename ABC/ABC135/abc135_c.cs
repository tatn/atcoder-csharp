namespace AtCoderCsharp.ABC.ABC135
{
    internal class abc135_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();
            long[] A = ReadLongArray();
            long[] B = ReadLongArray();

            long answer = 0;
            for (int i = 0; i < N; i++)
            {
                if (B[i] <= A[i])
                {
                    answer += B[i];
                }
                else
                {
                    answer += A[i];

                    long remain = B[i] - A[i];
                    if(remain < A[i + 1])
                    {
                        answer += remain;
                        A[i + 1] -= remain;
                    }
                    else
                    {
                        answer += A[i+1];
                        A[i + 1] = 0;
                    }
                }                
            }

            Console.WriteLine(answer);


        }
    }
}
