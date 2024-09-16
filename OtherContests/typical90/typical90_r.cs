namespace AtCoderCsharp.OtherContests.typical90
{
    internal class typical90_r
    {
        // 018 - Statue of Chokudai（★3） 
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int T = ReadInt();

            int[] LXY = ReadIntArray();
            int L = LXY[0];
            int X = LXY[1];
            int Y = LXY[2];

            int Q = ReadInt();

            int[] E = new int[Q + 1];
            for (int i = 1; i <= Q; i++)
            {
                E[i] = ReadInt();
            }

            for (int i = 1; i <= Q; i++)
            {
                (double y, double z) = GetPosition(E[i]);

                Console.WriteLine($"{GetAngle(y,z)}");
            }

            (double, double) GetPosition(int time)
            {
                double y = - (double)L * Math.Sin(2.0d * Math.PI * (double)time / (double)T) / 2.0d;
                double z = (double)L * (1.0d - Math.Cos(2.0d * Math.PI * (double)time / (double)T)) / 2.0d;

                return　(y, z);
            }

            double GetAngle(double y,double z)
            {
                double height = Math.Abs(z);

                double vectorX = 0.0d - (double)X;
                double vectorY = y - (double)Y;
                double vectorZ = z - 0.0d;

                double distance = Math.Sqrt(vectorX*vectorX + vectorY*vectorY + vectorZ*vectorZ);

                double cosAngle = height == 0.0d ? Math.PI / 2.0d : Math.Acos(height / distance);
                double answer = Math.PI / 2.0d - cosAngle;

                return answer * 360.0d / Math.PI / 2.0d;
            }



        }
    }
}
