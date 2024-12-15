using System.Collections.Generic;
using System.Numerics;

namespace AtCoderCsharp.ABC.ABC384
{
    internal class abc384_d
    {
        public static void Main(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split();
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            string[] NS = ReadStringArray();
            int N = int.Parse(NS[0]);
            long S = long.Parse(NS[1]);

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            long periodSum = 0L;
            foreach (int i in A)
            {
                periodSum += (long)i;
            }

            if(periodSum == S)
            {
                Console.WriteLine("Yes");
                return;
            }

            S %= periodSum;

            int[] ADouble = new int[2 * N + 1];
            for (int i = 1; i <= N; i++)
            {
                ADouble[i] = A[i];
                ADouble[i + N] = A[i];
            }


            bool isExist = false;
            int left = 0;
            int right = 0;
            long workS = 0L;
            while (right <= 2 * N)
            {
                if (workS < S)
                {
                    right++;
                    if (2 * N < right)
                    {
                        break;
                    }
                    workS += ADouble[right];
                }
                else if (S < workS)
                {
                    left++;
                    if(2* N < left)
                    {
                        break;
                    }

                    if(right < left)
                    {
                        right = left;
                        workS = ADouble[left];
                    }
                    else
                    {
                        workS -= ADouble[left - 1];
                    }

                }
                else
                {
                    isExist = true;
                    break;
                }
            }

            Console.WriteLine(isExist ? "Yes" : "No");
        }
    }
}
