namespace AtCoderCsharp.ABC.ABC357
{
    internal class abc357_b
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            string s = ReadString();

            int n = s.Length;

            char[] chars = s.ToCharArray();

            int countLower = chars.Where(c => 'a'<=c && c<='z').Count();
            int countUpper = n - countLower;

            if(countLower < countUpper)
            {
                Console.WriteLine(s.ToUpper());
            }
            else
            {
                Console.WriteLine(s.ToLower());
            }

        }
    }
}
