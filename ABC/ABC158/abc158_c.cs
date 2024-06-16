namespace AtCoderCsharp.ABC.ABC158
{
    internal class abc158_c
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split();
            int A = int.Parse(input1[0]);
            int B = int.Parse(input1[1]);

            int p108 = (int)Math.Ceiling(A / 0.08);
            int p110 = (int)Math.Ceiling(B / 0.10);

            int left = Math.Min(p108, p110);
            int right = Math.Max(p108, p110);

            int answer = -1;
            for (int i = left; i <= right; i++)
            {
                int tax108 = i * 8 / 100;
                int tax110 = i * 10 / 100;

                if (tax108 == A && tax110 == B)
                {
                    answer = i;
                    break;
                }
            }
            
            Console.WriteLine(answer);

        }

        int GetOutTaxPrice(int a, int b)
        {
            int answer = -1;
            for (int i = 1 ; i <= 100*10 ; i++)
            {
                int tax108 = i * 8 / 100;
                int tax110 = i * 10 / 100;

                if (tax108 == a && tax110 == b)
                {
                    answer = i;
                    break;
                }
            }

            return answer;
        }

        int GetOutTaxPrice3(int a, int b)
        {
            int p108 = a * 100 / 8 ;
            int p110 = b * 100 / 10 ;

            int answer = -1;
            for (int i = p110; i <= p108 + 1; i++)
            {
                int tax108 = i * 8 / 100;
                int tax110 = i * 10 / 100;

                if (tax108 == a && tax110 == b)
                {
                    answer = i;
                    break;
                }
            }

            return answer;
        }


    }
}
