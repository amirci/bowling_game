using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class ScoreCalculator : IScoreCalculator
    {
        public int Calculate(IEnumerable<IBowlingFrame> frames)
        {
            var firstTen = frames.Take(10);

            var plainSum = firstTen.Select(f => f.Score).Sum();

            var copy = firstTen.ToList();

            var strikeSum = firstTen.Where(f => f.IsStrike).Select(f => NextTwoBalls(f, copy)).Sum();

            var extraSum = CalculateExtraFrame(frames.Skip(10).FirstOrDefault());

            return plainSum + strikeSum + extraSum;
        }

        private int CalculateExtraFrame(IBowlingFrame extra)
        {
            return extra == null ? 0 : extra.First * 2 + extra.Second;
        }

        private static int NextTwoBalls(IBowlingFrame bowlingFrame, IList<IBowlingFrame> frames)
        {
            var index = frames.IndexOf(bowlingFrame);

            if (index == frames.Count - 1)
            {
                return 0;
            }

            return frames[index + 1].First + TheSecondBall(frames, index);
        }

        private static int TheSecondBall(IList<IBowlingFrame> frames, int index)
        {
            var f1 = frames[index + 1];

            if (!f1.IsStrike || index == frames.Count - 2)
            {
                return f1.Second;
            }

            var f2 = frames[index + 2];

            return f2.First;
        }
    }
}