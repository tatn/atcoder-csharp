using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AtCoderCsharp.OtherContests.typical90
{
    // 002 - Encyclopedia of Parentheses（★3） 
    internal class typical90_b
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            if(N % 2  == 1)
            {
                return;
            }

            List<string> answer = new List<string>();

            for (int i = 0; i < (1 << N); i++)
            {
                int count = BitOperations.PopCount((uint)i);
                if(count != N / 2)
                {
                    continue;
                }

                int[] zeroCount = new int[N + 1];
                int[] oneCount = new int[N + 1];
                StringBuilder parenthesesString = new StringBuilder(N);
                for (int j = 1; j <= N; j++)
                {
                    int targetValue = i / (1 << (N-j));
                    bool isOne = targetValue % 2 == 1;

                    zeroCount[j] = zeroCount[j - 1] + (isOne ? 0 : 1);
                    oneCount[j] = oneCount[j - 1] + (isOne ? 1 : 0);

                    parenthesesString.Append(isOne ? ")" : "(");
                }

                bool isConsist = true;
                for (int j = 1; j <= N; j++)
                {
                    if ( zeroCount[j] < oneCount[j])
                    {
                        isConsist = false;
                        break;
                    }                    
                }

                if (!isConsist)
                {
                    continue;
                }

                answer.Add(parenthesesString.ToString());

            }

            foreach (string s in answer)
            {
                Console.WriteLine(s);
            }
        }
    }
}
