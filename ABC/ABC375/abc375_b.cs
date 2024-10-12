using System;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC375
{

    // B - Traveling Takahashi Problem
    internal class abc375_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] X = new int[N + 1];
            int[] Y = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] xy = ReadIntArray();
                X[i] = xy[0];
                Y[i] = xy[1];
            }

            double answer = 0.0d;

            for (int i = 1; i <= N; i++)
            {
                double d = Math.Sqrt(Math.Pow(X[i] - X[i - 1], 2) + Math.Pow(Y[i] - Y[i - 1], 2));
                answer += d;
            }
            answer += Math.Sqrt(Math.Pow(X[N], 2) + Math.Pow(Y[N], 2));

            Console.WriteLine(answer);
        }
    }
}
