using System.Collections.Generic;

namespace AtCoderCsharp.ABC.ABC373
{
    // E - How to Win the Election ToDo
    internal class abc373_e
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NMK = ReadLongArray();
            int N = (int)NMK[0];
            int M = (int)NMK[1];
            long K = NMK[2];

            List<long> A = ReadLongArray().ToList();
            A.Insert(0, -1);
            List<long> ASorted = A.ToList();
            ASorted.Sort();

            List<long> ASortedSum = new List<long>();
            ASortedSum.Add(0);
            ASortedSum.Add(ASorted[1]);
            for (int i = 2; i <= N; i++)
            {
                ASortedSum.Add(ASortedSum[i - 1] + ASorted[i]);
            }

            long remainCount = K - ASortedSum[N];

            if (N == M)
            {
                Console.WriteLine(String.Join(" ", Enumerable.Range(1, N).Select(x => 0)));
                return;
            }

            // M < N

            List<long> answers = new List<long>();
            int topMIndex = N - M + 1;

            for (int i = 1; i <= N; i++)
            {
                long voteCount = A[i];

                long leftVote = -1;
                long rightVote = remainCount + 1;
                int vodeIndex = ~ASorted.BinarySearch(voteCount, new LowerBoundComparer<long>());

                bool isCandidateOfIInTopM = topMIndex <= vodeIndex;

                while (1 < rightVote - leftVote)
                {
                    long midVoteCount = (leftVote + rightVote) / 2L;
                    long targetCandidateVoteCount = voteCount + midVoteCount;


                    if (isCandidateOfIInTopM)
                    {
                        // この候補者が上位M人に入る

                        //上位M人 topMIndex-1,...,vodeIndex-1,vodeIndex+1..,Nの候補者が全員targetCandidateVoteCount+1票以上を取るのに必要な票数
                        int vodeIndexRightLimit = ASorted.BinarySearch(targetCandidateVoteCount + 1, new LowerBoundComparer<long>());
                        if (vodeIndexRightLimit < 0)
                        {
                            vodeIndexRightLimit = ~vodeIndexRightLimit;
                        }
                        vodeIndexRightLimit--;

                        long sumCurrentVote = ASortedSum[vodeIndexRightLimit] - ASortedSum[topMIndex - 2] - voteCount;
                        long needVoteCount = ((long)vodeIndexRightLimit - (long)topMIndex+1) * (targetCandidateVoteCount + 1L) - sumCurrentVote;

                        if (needVoteCount <= remainCount - midVoteCount)
                        {
                            // 対象以外の上位候補者M人が全員targetCandidateVoteCount+1票以上を取ることが可能
                            // 当確でない
                            leftVote = midVoteCount;

                        }
                        else
                        {
                            // 対象以外の上位候補者M人が全員targetCandidateVoteCount+1票以上を取ることが不可能
                            // 当確
                            rightVote = midVoteCount;
                        }
                    }
                    else
                    {
                        // この候補者が上位M人に入らない

                        //上位M人 topMIndex, topMIndex+1,..,Nの候補者が全員targetCandidateVoteCount+1票以上を取るのに必要な票数
                        int vodeIndexRightLimit = ASorted.BinarySearch(targetCandidateVoteCount + 1, new LowerBoundComparer<long>());
                        if (vodeIndexRightLimit < 0)
                        {
                            vodeIndexRightLimit = ~vodeIndexRightLimit;
                        }
                        vodeIndexRightLimit--;

                        long sumCurrentVote = ASortedSum[vodeIndexRightLimit] - ASortedSum[topMIndex - 1];
                        long needVoteCount = ((long)vodeIndexRightLimit - (long)topMIndex + 1L) * (targetCandidateVoteCount + 1L) - sumCurrentVote;

                        if (needVoteCount <= remainCount - midVoteCount)
                        {
                            // 対象以外の上位候補者M人が全員targetCandidateVoteCount+1票以上を取ることが可能
                            // 当確でない
                            leftVote = midVoteCount;

                        }
                        else
                        {
                            // 対象以外の上位候補者M人が全員targetCandidateVoteCount+1票以上を取ることが不可能
                            // 当確
                            rightVote = midVoteCount;
                        }
                    }

                }

                if (leftVote == remainCount)
                {
                    answers.Add(-1);
                }
                else
                {
                    answers.Add(rightVote);
                }
            }

            Console.WriteLine(String.Join(" ", answers));

        }

        private class LowerBoundComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T? x, T? y)
            {
                return 0 <= x?.CompareTo(y) ? 1 : -1;
            }
        }

    }
}
