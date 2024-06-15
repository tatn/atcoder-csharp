namespace AtCoderCsharp.OtherContests.code_festival_2016_qualb
{
    internal class codefestival_2016_qualB_b
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()!.Split(' ');
            int N = int.Parse(input1[0]);
            int A = int.Parse(input1[1]);
            int B = int.Parse(input1[2]);

            char[] s = Console.ReadLine()!.ToCharArray();

            int aPassed = 0;
            int bPassed = 0;
            int bRank = 0;

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'a':
                        if (aPassed + bPassed < A + B)
                        {
                            aPassed++;
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No");
                        }
                        break;
                    case 'b':
                        bRank++;
                        if (aPassed + bPassed < A + B && bRank <= B)
                        {
                            bPassed++;
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No");
                        }
                        break;
                    case 'c':
                        Console.WriteLine("No");
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
