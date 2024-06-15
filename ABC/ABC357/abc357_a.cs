namespace AtCoderCsharp.ABC.ABC357
{
    internal class abc357_a
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] H = ReadIntArray();

            int remain = M;
            int answer = 0;
            for (int i = 0; i < N; i++)
            {
                int hand = H[i];

                remain -= hand;

                if(0 <= remain)
                {
                    answer++;
                }
                else
                {
                    break;
                }
                
            }

            Console.WriteLine(answer);

        }
    }
}
