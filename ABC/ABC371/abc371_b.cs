namespace AtCoderCsharp.ABC.ABC371
{
    //B - Taro

    internal class abc371_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = new int[M + 1];
            string[] B = new string[M + 1];

            bool[] isMaleExist = new bool[N + 1];
            bool[] isTaro = new bool[M + 1];

            for (int i = 1; i <= M; i++)
            {
                string[] input = ReadStringArray();
                A[i] = int.Parse(input[0]);
                B[i] = input[1];

                if (!isMaleExist[A[i]])
                {
                    if (B[i] == "M")
                    {
                        isMaleExist[A[i]] = true;
                        isTaro[i] = true;
                    }
                }
            }

            for (int i = 1; i <= M; i++)
            {
                Console.WriteLine(isTaro[i] ? "Yes" : "No");
            }



        }
    }
}
