﻿namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_ae
    {
        // 031 - VS AtCoder（★6） ToDo
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            List<int> W = ReadIntArray().ToList();
            W.Insert(0, 0);
            List<int> B = ReadIntArray().ToList();
            B.Insert(0, 0);
        }
    }
}