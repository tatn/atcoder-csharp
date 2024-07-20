using System.Numerics;
namespace AtCoderCsharp.ABC.ABC363
{
    internal class abc363_b
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NTP = ReadIntArray();
            int N = NTP[0];
            int T = NTP[1];
            int P = NTP[2];

            int[] L = ReadIntArray();

            int alreadyLongCount = L.Count(x => T <= x);

            int waitPersonCount = P - alreadyLongCount;

            if (waitPersonCount <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            List<int> LSorted = L.Where(x => x < T).ToList();
            LSorted.Sort();
            LSorted.Reverse();

            List<int> needDays = LSorted.Select(x => T - x).ToList();

            int count = 0;
            int answer = 0;
            foreach (int x in needDays)
            {
                count++;
                answer = x;

                if(waitPersonCount <= count)
                {
                    break;
                }

            }
            Console.WriteLine(answer);

        }
    }
}
