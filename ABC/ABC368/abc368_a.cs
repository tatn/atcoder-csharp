using System.Numerics;
namespace AtCoderCsharp.ABC.ABC368
{
    internal class abc368_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = ReadIntArray();

            List<int> answer = new List<int>();

            for (int i = N-K; i < N; i++)
            {
                answer.Add(A[i]);
            }
            for (int i = 0; i < N - K; i++)
            {
                answer.Add(A[i]);
            }


            Console.WriteLine(string.Join(" ", answer));

        }
    }
}
