using System.Numerics;
using System.Text.RegularExpressions;
namespace AtCoderCsharp.ABC.ABC366
{
    internal class abc366_b
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            int M = 0;
            string[] S = new string[N];
            for (int i = 0; i < N; i++)
            {
                S[i] = ReadString();

                if(M < S[i].Length)
                {
                    M = S[i].Length;
                }
            }

            string[] T = new string[M];
            for (int i = 0;i < M; i++)
            {
                T[i] = "";
                for (int j = N-1; 0 <= j; j--)
                {
                    if (i + 1 <= S[j].Length)
                    {
                        T[i] += S[j][i];
                    }
                    else
                    {
                        T[i] += "*";

                    }
                }
            }

            Regex r = new Regex(@"[\*]+$");
            for (int i = 0; i < M; i++)
            {
                Console.WriteLine(r.Replace(T[i],""));
            }


        }
    }
}
