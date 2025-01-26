using System.Numerics;

namespace AtCoderCsharp.ABC.ABC390
{
    internal class abc390_d
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();
            long[] A = new long[N + 1];
            long[] input = ReadLongArray();
            for (int i = 0; i < N; i++)
            {
                A[i + 1] = input[i];
            }

            HashSet<long> xorValues = new HashSet<long>((int)1e6, new CustomHash());
            //List<long>[] groupStore = new List<long>[N + 1];
            //for (int i = 0; i <= N; i++)
            //{
            //    groupStore[i] = new List<long>();
            //}
            long[] groupStore = new long[N + 1];
            long xorValue = 0L;

            void DFS(int depth, int groupCount)
            {
                //Console.WriteLine($"DFS depth={depth} groupCount={groupCount}");

                for (int i = 1; i <= groupCount + 1; i++)
                {
                    //Console.WriteLine($"---- depth={depth} groupCount={groupCount}  i={i}");
                    //Console.WriteLine($"---- groupStore={string.Join(",", groupStore)}");

                    xorValue ^= groupStore[i];
                    //groupStore[i].Add(A[depth]);
                    groupStore[i] += A[depth];
                    //Console.WriteLine($"---- groupStore={string.Join(",", groupStore)}");

                    xorValue ^= groupStore[i];

                    int nextDepth = depth + 1;
                    int nextGroupCount = i == groupCount + 1 ? groupCount + 1 : groupCount;

                    if (depth < N)
                    {
                        DFS(nextDepth, nextGroupCount);
                    }
                    else
                    {

                        //List<long> targetImtes = groupStore
                        //    .Select((value, index) => new { value, index })
                        //    .Where(x => 1 <= x.index && x.index <= nextGroupCount)
                        //    .Select(x => x.value)
                        //    .ToList();

                        //long xorValuel = GetExclusiveOrValue(targetImtes);
                        //if (!xorValues.Contains(xorValuel))
                        //{
                        //    xorValues.Add(xorValuel);
                        //}
                        //Console.WriteLine($"xorValue={xorValue}, xorValuel={xorValuel}");

                        if (!xorValues.Contains(xorValue))
                        {
                            xorValues.Add(xorValue);
                        }
                    }

                    xorValue ^= groupStore[i];
                    //groupStore[i].RemoveAt(groupStore[i].Count - 1);
                    groupStore[i] -= A[depth];
                    xorValue ^= groupStore[i];
                }
            }

            DFS(1, 0);

            Console.WriteLine(xorValues.Count);
        }

        public static long GetExclusiveOrValue(List<long> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                return 0;
            }


            long result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result ^= numbers[i];
            }

            return result;
        }

        public class CustomHash : IEqualityComparer<long>
        {
            public int GetHashCode(long value)
            {
                var lo = (int)(value & 0xFFFFFFFF);
                var hi = (int)((value >> 32) & 0xFFFFFFFF);
                return lo * 13 + hi;
            }

            public bool Equals(long x, long y)
            {
                return x == y;
            }
        }
    }
}
