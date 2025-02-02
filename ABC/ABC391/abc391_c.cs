using System.Numerics;

namespace AtCoderCsharp.ABC.ABC391
{
    internal class abc391_c
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[] position = new int[N + 1];
            int[] pigeonCount = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                position[i] = i;
                pigeonCount[i] = 1;
            }
            int multiPigeonCount = 0;

            List<int> answer = new List<int>();
            for (int i = 1; i <= Q; i++)
            {
                int[] query = ReadIntArray();

                switch (query[0])
                {
                    case 1:
                        int P = query[1];
                        int H = query[2];

                        int prevPosition = position[P];
                        position[P] = H;

                        pigeonCount[prevPosition]--;
                        pigeonCount[H]++;

                        if(pigeonCount[H] == 2)
                        {
                           multiPigeonCount++;
                        }

                        if (pigeonCount[prevPosition] == 1)
                        {
                            multiPigeonCount--;
                        }

                        break;
                    case 2:
                        //Console.WriteLine(multiPigeonCount);
                        answer.Add(multiPigeonCount);
                        break;
                }
            }

            foreach (int ans in answer)
            {
                Console.WriteLine(ans);
            }   

        }
    }
}
