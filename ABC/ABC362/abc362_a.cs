using System.Numerics;
namespace AtCoderCsharp.ABC.ABC362
{
    internal class abc362_a
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] RGB = ReadIntArray();
            string C = ReadString();

            int answer = 0;
            switch (C)
            {
                case "Red":
                    answer = Math.Min(RGB[1], RGB[2]);
                    break;
                case "Green":
                    answer = Math.Min(RGB[0], RGB[2]);
                    break;
                case "Blue":
                    answer = Math.Min(RGB[0], RGB[1]);
                    break;
            }

            Console.WriteLine(answer);
        }
    }
}
