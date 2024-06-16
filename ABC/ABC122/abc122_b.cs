namespace AtCoderCsharp.ABC.ABC122
{
    internal class abc122_b
    {
        public static void Main(string[] args)
        {
            char[] chars= Console.ReadLine()!.ToCharArray();

            bool[] bools = chars.Select(c => c == 'A' || c == 'C' || c == 'G' || c == 'T').ToArray();

            int answer = 0;


            int current = 0;
            for (int i = 0; i < bools.Length; i++)
            {

                if (bools[i])
                {
                    current++;
                }
                else
                {
                    if(answer < current)
                    {
                        answer = current;
                    }
                    current = 0;
                }
            }

            if (answer < current)
            {
                answer= current; 
            }


            Console.WriteLine(answer);



        }

    }
}
