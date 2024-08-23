namespace AtCoderCsharp.ABC.ABC139
{
    internal class abc139_d
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int N = ReadInt();
            Console.WriteLine((long)N*((long)N -1L)/2L);
        }
    }
}
