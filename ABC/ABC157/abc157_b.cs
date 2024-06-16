namespace AtCoderCsharp.ABC.ABC157
{
    internal class abc157_b
    {
        public static void Main(string[] args)
        {
            byte[,] A = new byte[3, 3];

            string[] input1 = Console.ReadLine()!.Split(' ');
            A[0, 0] = byte.Parse(input1[0]);
            A[0, 1] = byte.Parse(input1[1]);
            A[0, 2] = byte.Parse(input1[2]);

            string[] input2 = Console.ReadLine()!.Split(' ');
            A[1, 0] = byte.Parse(input2[0]);
            A[1, 1] = byte.Parse(input2[1]);
            A[1, 2] = byte.Parse(input2[2]);

            string[] input3 = Console.ReadLine()!.Split(' ');
            A[2, 0] = byte.Parse(input3[0]);
            A[2, 1] = byte.Parse(input3[1]);
            A[2, 2] = byte.Parse(input3[2]);

            string input4 = Console.ReadLine()!;
            byte N = byte.Parse(input4);

            byte[] b = new byte[N];
            for (int i = 0; i < N; i++)
            {
                string input5 = Console.ReadLine()!;
                b[i] = byte.Parse(input5);
            }

            bool[,] match = new bool[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        if (A[i, j] == b[k])
                        {
                            match[i, j] = true;
                        }
                    }
                }
            }

            bool[] flatten = new bool[3 * 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int index = 3 * i + j;
                    flatten[index] = match[i, j];
                }
            }

            var q = flatten.Select((b, i) => { return new { b, i }; });


            bool isBingo = q.Where(x => x.i % 3 == 0).All(x=> x.b)
                || q.Where(x => x.i % 3 == 2).All(x => x.b)
                || q.Where(x => x.i <= 2).All(x => x.b)
                || q.Where(x => 3 <= x.i && x.i <= 5).All(x => x.b)
                || q.Where(x => 6 <= x.i && x.i <= 8).All(x => x.b)
                || q.Where(x => x.i % 4 == 0).All(x => x.b)
                || q.Where(x => (x.i == 2 || x.i == 4 || x.i == 6)).All(x => x.b)
                || q.Where(x => x.i % 3 == 1).All(x => x.b)
                ;

            Console.WriteLine(isBingo ? "Yes" : "No");





        }
    }
}
