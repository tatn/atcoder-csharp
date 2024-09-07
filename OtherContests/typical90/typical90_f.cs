using System.Text;

namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_f
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            string S = ReadString();

            // findIndex[i,j] iもj目以降で最初にjが出現する位置
            int[,] findIndex = new int[N + 1, 'z' - 'a' + 1];

            int[] lastIndex = new int['z' - 'a' + 1];
            for (int i = 0; i < 'z' - 'a' + 1; i++)
            {
                lastIndex[i] = -1;
            }

            for (int i = N; 1 <= i; i--)
            {
                int charIndex = S[i - 1] - 'a';
                lastIndex[charIndex] = i;

                for (int j = 0; j < 'z' - 'a' + 1; j++)
                {
                    findIndex[i, j] = lastIndex[j];
                }
            }

            int currentIndex = 1;

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <=K; i++)
            {
                // i文字目を確定する

                for (int j = 0; j < 'z' - 'a' + 1; j++)
                {
                    //a,b,c,...zと順番に候補を試す

                    int find = findIndex[currentIndex, j];
                    if(find == -1)
                    {
                        continue;
                    }

                    int restLength = N - find;

                    if(K-i <= restLength)
                    {
                        sb.Append((char)('a' + j));
                        currentIndex = find + 1;
                        break;
                    }
                }                
            }

            Console.WriteLine(sb.ToString());

        }
    }
}
