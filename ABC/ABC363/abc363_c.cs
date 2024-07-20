using System.Numerics;

namespace AtCoderCsharp.ABC.ABC363
{
    internal class abc363_c
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            string S = ReadString();

            List<int> numbers = new List<int>() { };
            foreach (char c in S)
            {
                numbers.Add(c - 'a' + 1);
            }
            numbers.Sort();
            int[] numbersArray = numbers.ToArray();

            int answer = 0;
            do
            {
                if (!IsPalindrome(numbersArray, K))
                {
                    answer++;
                }

            } while (NextPermutation(numbersArray));


            Console.WriteLine(answer);
        }


        static bool NextPermutation(int[] array)
        {
            int n = array.Length;
            int i = n - 2;

            // Find the largest index i such that array[i] < array[i + 1]
            while (i >= 0 && array[i] >= array[i + 1])
            {
                i--;
            }

            if (i < 0)
            {
                // The array is in descending order
                Array.Reverse(array);
                return false; // This was the last permutation
            }

            int j = n - 1;
            // Find the largest index j such that array[i] < array[j]
            while (array[i] >= array[j])
            {
                j--;
            }

            // Swap array[i] and array[j]
            Swap(array, i, j);

            // Reverse the sequence from array[i + 1] to array[n - 1]
            Array.Reverse(array, i + 1, n - (i + 1));

            return true; // Next permutation was found
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static bool IsPalindrome(int[] array, int K)
        {
            bool isPalindrome = false;

            for (int i = 0; i <= array.Length - K; i++)
            {
                bool check = true;

                for (int j = 1; j <= K ; j++)
                {
                    check = check && array[i + j - 1] == array[i + K - j];
                }

                if (check)
                {
                    isPalindrome = true;
                    break;
                }
            }

            return isPalindrome;

        }


    }
}
