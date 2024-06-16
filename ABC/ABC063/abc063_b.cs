namespace AtCoderCsharp.ABC.ABC063
{
    internal class abc063_b
    {
        public static void Main(string[] args)
        {
            char[] chars = Console.ReadLine()!.ToCharArray();

            Console.WriteLine(chars.Distinct().Count() == chars.Count() ? "yes" : "no");
        }

    }
}
