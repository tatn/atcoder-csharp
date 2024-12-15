using System.Collections.Generic;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC384
{
    internal class abc384_c
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] abcde = ReadIntArray();
            int a = abcde[0];
            int b = abcde[1];
            int c = abcde[2];
            int d = abcde[3];
            int e = abcde[4];

            List<(int, string)> nameAndScores = new List<(int, string)>();

            for (int i = 1; i <= 31 ; i++)
            {
                int bits = i;
                bool isA = bits % 2 == 1;
                bits /= 2;
                bool isB = bits % 2 == 1;
                bits /= 2;
                bool isC = bits % 2 == 1;
                bits /= 2;
                bool isD = bits % 2 == 1;
                bits /= 2;
                bool isE = bits % 2 == 1;

                int score = 0;
                score += isA ? a : 0;
                score += isB ? b : 0;
                score += isC ? c : 0;
                score += isD ? d : 0;
                score += isE ? e : 0;

                string name = "";
                name += isA ? "A" : "";
                name += isB ? "B" : "";
                name += isC ? "C" : "";
                name += isD ? "D" : "";
                name += isE ? "E" : "";

                nameAndScores.Add((score,name));
            }


            nameAndScores.Sort((a,b)=> a.Item1.CompareTo(b.Item1) == 0 ?  a.Item2.CompareTo(b.Item2) :  -1 * a.Item1.CompareTo(b.Item1)  );

            foreach ((int i,string name) in nameAndScores)
            {
                Console.WriteLine(name);
            }
        }
    }
}
