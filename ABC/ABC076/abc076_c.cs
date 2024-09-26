namespace AtCoderCsharp.ABC.ABC076
{
    // AtCoder Beginner Contest 076
    //　C - Dubious Document 2 
    internal class abc076_c
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string SDash = ReadString();
            string T = ReadString();

            if(SDash.Length < T.Length)
            {
                Console.WriteLine("UNRESTORABLE");
                return;
            }

            int matchIndex = -1;

            for (int i = SDash.Length - T.Length; 0 <=i; i--)
            {
                bool isMatch = true;

                for (int j = 0; j < T.Length; j++)
                {
                    if (SDash[i + j] != '?' &&  SDash[i + j] != T[j])
                    {
                        isMatch = false;
                        break;
                    }
                }    
                
                if(isMatch)
                {
                    matchIndex = i;
                    break;
                }
            }

            if (matchIndex == -1)
            {
                Console.WriteLine("UNRESTORABLE");
                return;
            }


            char[] answer = new char[SDash.Length];
            for (int i = 0; i < SDash.Length; i++)
            {
                if(matchIndex <= i && i <= matchIndex + T.Length - 1)
                {
                    answer[i] = T[i - matchIndex];
                }
                else if (SDash[i] == '?')
                {
                    answer[i] = 'a';
                }
                else
                {
                    answer[i] = SDash[i];
                }
            }

            Console.WriteLine(string.Join("", answer));


        }

    }
}
