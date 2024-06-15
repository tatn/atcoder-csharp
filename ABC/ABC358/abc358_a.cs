namespace AtCoderCsharp.ABC.ABC358
{
    internal class abc358_a
    {
        public static void Main(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split().ToArray();

            string[] ST = ReadStringArray();
            string S = ST[0];
            string T = ST[1];


            Console.WriteLine(S == "AtCoder" && T == "Land" ? "Yes" : "No");
        }
    }
}
