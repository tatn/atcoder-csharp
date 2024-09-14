
namespace AtCoderCsharp.OtherContests.tessoku_book
{
    internal class tessoku_book_bo
    {
        //A67 - MST (Minimum Spanning Tree) 

        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            List<(int, int, int)> ABC = new List<(int, int, int)>();
            for (int i = 1; i <= M; i++)
            {
                int[] input = ReadIntArray();
                ABC.Add((input[0], input[1], input[2]));
            }

            ABC.Sort((x, y) => x.Item3 - y.Item3);

            UnionFind[] unionFinds = new UnionFind[N + 1];
            for (int i = 0; i < N+1; i++)
            {
                unionFinds[i] = new UnionFind(i);
            }

            int answer = 0;
            for (int i = 1; i <= M; i++)
            {
                (int A, int B, int C) = ABC[i-1];

                if (unionFinds[A].IsConnected(unionFinds[B], unionFinds))
                {
                   continue;
                }

                unionFinds[A].Merge(unionFinds[B],unionFinds);
                answer += C;
            }

            Console.WriteLine(answer);
        }

        public class UnionFind
        {
            private int Value { get; }

            private int Parent { get; set; }

            private int Size { get; set; }

            public UnionFind(int value)
            {
                this.Value = value;
                this.Parent = -1;
                this.Size = 1;
            }

            public void Merge(UnionFind other, UnionFind[] unionFinds)
            {
                int root = this.GetRoot(unionFinds);
                int otherRoot = other.GetRoot(unionFinds);

                if(root == otherRoot)
                {
                    return;
                }

                if (unionFinds[otherRoot].Size <= unionFinds[root].Size)
                {
                    unionFinds[otherRoot].Parent = root;
                    unionFinds[root].Size += unionFinds[otherRoot].Size;
                }
                else
                {
                    unionFinds[root].Parent = otherRoot;
                    unionFinds[otherRoot].Size += unionFinds[root].Size;

                }

            }

            public bool IsConnected(UnionFind other, UnionFind[] unionFinds)
            {
                int root = this.GetRoot(unionFinds);
                int otherRoot = other.GetRoot(unionFinds);

                return root == otherRoot;               
            }

            public int GetRoot(UnionFind[] unionFinds)
            {
                if(this.Parent == -1)
                {
                    return this.Value;
                }

                return unionFinds[this.Parent].GetRoot(unionFinds);

            }
        }
    }
}
