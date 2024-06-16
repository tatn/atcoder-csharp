namespace AtCoderCsharp.ABC.ABC044
{
    internal class abc044_b
    {
        public static void Main(string[] args)
        {
            char[] w = Console.ReadLine()!.ToCharArray();

            byte[] c = new byte['z'-'a'+1];

            for (int i = 0; i < w.Length; i++)
            {
                c[w[i] - 'a']++;
            }

            Console.WriteLine(c.All(x => x % 2 == 0) ? "Yes" : "No");

        }
    }
}
