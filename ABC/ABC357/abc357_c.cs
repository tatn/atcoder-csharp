namespace AtCoderCsharp.ABC.ABC357
{
    internal class abc357_c
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            char[,] carpet = GetCarpet(N);

            for (int i = 0; i < (int)Math.Pow(3, N); i++)
            {
                for (int j = 0; j < (int)Math.Pow(3, N); j++)
                {
                    Console.Write(carpet[i,j]);
                }
                Console.WriteLine();
            }

        }

        public static char[,] GetCarpet(int K)
        {
            if(K == 0)
            {
                char[,] carpetZero = new char[1, 1];
                carpetZero[0, 0] = '#';
                return carpetZero;
            }

            int gridNumber = (int)Math.Pow(3, K);
            int subGridNumber = (int)Math.Pow(3, K-1);

            char[,] carpet = new char[gridNumber, gridNumber];

            char[,] subCarpet = GetCarpet(K - 1);

            for (int i = 0; i < subGridNumber; i++)
            {
                for (int j = 0; j < gridNumber; j++)
                {
                    carpet[i, j] = subCarpet[i % subGridNumber , j  % subGridNumber];
                }
            }

            for (int i = subGridNumber ; i < subGridNumber*2; i++)
            {
                for (int j = 0; j < subGridNumber; j++)
                {
                    carpet[i, j] = subCarpet[i % subGridNumber, j % subGridNumber];
                }
            }

            for (int i = subGridNumber; i < subGridNumber * 2; i++)
            {
                for (int j = subGridNumber; j < subGridNumber * 2; j++)
                {
                    carpet[i, j] = '.';
                }
            }

            for (int i = subGridNumber; i < subGridNumber * 2; i++)
            {
                for (int j = subGridNumber*2; j < gridNumber; j++)
                {
                    carpet[i, j] = subCarpet[i % subGridNumber, j % subGridNumber];
                }
            }

            for (int i = subGridNumber*2 ; i < gridNumber; i++)
            {
                for (int j = 0; j < gridNumber; j++)
                {
                    carpet[i, j] = subCarpet[i % subGridNumber, j % subGridNumber];
                }
            }

            return carpet;
        }

    }
}
