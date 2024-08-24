using System.Numerics;

namespace AtCoderCsharp.ABC.ABC368
{
    internal class abc368_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] H = ReadIntArray();

            long T = 0;
            int enemyCount = N;
            for (int i = 0; i < N; i++)
            {
                T++;
                int hitPoint = H[i];

                switch(T % 3)
                {
                    case 0:
                        //3,1,1,3,1,1,3,1,1,..
                        T = T + ((long)((hitPoint-1) / 5)) * 3L;
                        switch (hitPoint % 5)
                        {
                            case 1:
                            case 2:
                            case 3:
                                break;
                            case 4:
                                T = T + 1L;
                                break;
                            case 0:
                                T = T + 2L;
                                break;
                        }
                        break;
                    case 1:
                        //1,1,3,1,1,3,...
                        T = T + ((long)((hitPoint - 1) / 5)) * 3L;
                        switch (hitPoint % 5)
                        {
                            case 1:
                                break;
                            case 2:
                                T = T + 1L;
                                break;
                            case 3:
                            case 4:
                            case 0:
                                T = T + 2L;
                                break;
                        }
                        break;
                    case 2:
                        //1,3,1,1,3,1,...
                        T = T + ((long)((hitPoint - 1) / 5)) * 3L;
                        switch (hitPoint % 5)
                        {
                            case 1:
                                break;
                            case 2:
                            case 3:
                            case 4:
                                T = T + 1L;
                                break;
                            case 0:
                                T = T + 2L;
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(T);            
        }
    }
}
