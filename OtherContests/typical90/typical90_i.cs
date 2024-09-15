namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_i
    {
        //009 - Three Point Angle（★6） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] X = new int[N + 1];
            int[] Y = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] xy = ReadIntArray();
                X[i] = xy[0];
                Y[i] = xy[1];                
            }

            double answer = 0d;
            for (int i = 1; i <= N; i++)
            {
                int x = X[i];
                int y = Y[i];

                List<double> angles = new List<double>();

                for (int j = 1; j <= N ; j++)
                {
                    if(i == j)
                    {
                        continue;
                    }

                    angles.Add(Math.Atan2(Y[j] - y, X[j] - x));
                }

                angles.Sort();

                for (int j = 0; j < N-1; j++)
                {
                    double target = angles[j];
                    double candidateAngle1 = GetMaxAngle(target, target + Math.PI, angles);
                    double candidateAngle2 = GetMaxAngle(target, target - Math.PI, angles);

                    answer = Math.Max(answer, candidateAngle1);
                    answer = Math.Max(answer, candidateAngle2);
                }
            }

            Console.WriteLine(answer / Math.PI * 180.0d);

            double GetMaxAngle(double target, double nearAngle,  List<double> angles)
            {
                double maxAngle = 0d;

                int foundIndex = angles.BinarySearch(nearAngle);

                if (foundIndex < 0)
                {
                    foundIndex = ~foundIndex;

                    int leftIndex = foundIndex - 1;
                    if (leftIndex < 0)
                    {
                        leftIndex = 0;
                    }
                    int rightIndex = foundIndex;
                    if (N - 1 <= rightIndex)
                    {
                        rightIndex = N - 2;
                    }
                    double candidateAngle1 = Math.Abs(target - angles[leftIndex]);
                    candidateAngle1 = candidateAngle1 > 2 * Math.PI ? candidateAngle1 - 2 * Math.PI : candidateAngle1;
                    candidateAngle1 = candidateAngle1 > Math.PI ?  2* Math.PI - candidateAngle1 : candidateAngle1;

                    double candidateAngle2 = Math.Abs(target - angles[rightIndex]);
                    candidateAngle2 = candidateAngle2 > 2 * Math.PI ? candidateAngle2 - 2 * Math.PI : candidateAngle2;
                    candidateAngle2 = candidateAngle2 > Math.PI ? 2 * Math.PI - candidateAngle2 : candidateAngle2;

                    maxAngle = Math.Max(candidateAngle1, candidateAngle2);

                }
                else
                {
                    maxAngle = Math.Abs(target - angles[foundIndex]);
                    maxAngle = maxAngle > Math.PI ? maxAngle - Math.PI : maxAngle;
                }

                return maxAngle;
            }

        }
    }
}
