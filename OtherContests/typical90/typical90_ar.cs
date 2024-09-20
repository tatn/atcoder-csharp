namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ar
    {
        // 044 - Shift and Swapping（★3） 
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[] A = ReadIntArray();

            int[,] Txy = new int[Q + 1, 3];
            for (int i = 1; i <= Q; i++)
            {
                int[] txqInput = ReadIntArray();
                Txy[i, 0] = txqInput[0];
                Txy[i, 1] = txqInput[1];
                Txy[i, 2] = txqInput[2];
            }

            int shiftNumber = 0;
            for (int i = 1; i <= Q; i++)
            {
                switch (Txy[i, 0])
                {
                    case 1:
                        int x = Txy[i, 1] - 1;
                        x -= shiftNumber;
                        x = x < 0 ? x + N : x;

                        int y = Txy[i, 2] - 1;
                        y -= shiftNumber;
                        y = y < 0 ? y + N : y;

                        int temp = A[x];
                        A[x] = A[y];
                        A[y] = temp;

                        break;
                    case 2:
                        shiftNumber++;
                        shiftNumber = shiftNumber % N;
                        break;
                    case 3:
                        int z = Txy[i, 1] - 1;
                        z -= shiftNumber;
                        z = z < 0 ? z + N : z;
                        Console.WriteLine(A[z]);
                        break;
                }
            }
        }
    }
}
