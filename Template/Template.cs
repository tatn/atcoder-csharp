using System.Numerics;

namespace AtCoderCsharp.Template
{
    internal class Template
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            long ReadLong() => long.Parse(Console.ReadLine()!);
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            BigInteger ReadBigInteger() => BigInteger.Parse(Console.ReadLine()!);
            BigInteger[] ReadBigIntegerArray() => Console.ReadLine()!.Split().Select(BigInteger.Parse).ToArray();

            string s = ReadString();
            string[] strings = ReadStringArray();

            int N = ReadInt();
            int K = ReadInt();
            int L = ReadInt();
            int M = ReadInt();

            int[] X = ReadIntArray();

            long A = ReadLong();

            long[] B = ReadLongArray();

            BigInteger C = ReadBigInteger();

            BigInteger[] D = ReadBigIntegerArray();

            Console.WriteLine(1);
        }
    }
}
