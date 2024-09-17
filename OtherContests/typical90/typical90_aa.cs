namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_aa
    {
        // 027 - Sign Up Requests （★2） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string ReadString() => Console.ReadLine()!;

            int N = ReadInt();

            Dictionary<string, bool> keyValuePairs = new Dictionary<string, bool>();
            List<int> answers = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                string S = ReadString();

                if(!keyValuePairs.ContainsKey(S))
                {                    
                    keyValuePairs.Add(S,true);
                    answers.Add(i);
                }
            }

            foreach (int i in answers)
            {
                Console.WriteLine(i);
            }
        }
    }
}
