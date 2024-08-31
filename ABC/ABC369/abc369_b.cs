using System.Numerics;

namespace AtCoderCsharp.ABC.ABC369
{
    internal class abc369_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int N = ReadInt();

            int[] A = new int[N];
            string[] S = new string[N];

            int LFirst = 0;
            int RFirst = 0;

            for (int i = 0; i < N; i++)
            {
                string[] input = ReadStringArray();
                A[i] = int.Parse(input[0]);
                S[i] = input[1];

                if(LFirst == 0 && S[i] == "L")
                {
                    LFirst = A[i];
                }

                if (RFirst == 0 && S[i] == "R")
                {
                    RFirst = A[i];
                }
            }


            int answer = 0;
            int prevL = LFirst;
            int prevR = RFirst;
            for (int i = 0; i < N; i++)
            {
                if (S[i] == "L")
                {
                    answer += Math.Abs(A[i] - prevL);
                    prevL = A[i];
                }
                else
                {
                    answer += Math.Abs(A[i] - prevR);
                    prevR = A[i];
                }
            }

            Console.WriteLine(answer);

        }
    }
}
