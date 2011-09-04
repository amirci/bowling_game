using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class ScoreCalculator : IScoreCalculator
    {
        private static readonly IBowlingFrame _empty = new BowlingFrame(0);

        public int Calculate(IEnumerable<IBowlingFrame> frames)
        {
            var firstTen = frames.Take(10);

            var copy = frames.ToList();

            return firstTen.Aggregate(0, (score, f) =>
                                             {
                                                 score += f.Score;

                                                 score += f.IsSpare.Then(NextBall(f, copy));

                                                 score += f.IsStrike.Then(NextTwoBalls(f, copy));

                                                 return score;
                                             }) ;
        }

        private static int NextBall(IBowlingFrame frame, IList<IBowlingFrame> frames)
        {
            return NextFrame(frame, frames).First;
        }

        private static int NextTwoBalls(IBowlingFrame frame, IList<IBowlingFrame> frames)
        {
            var extra = frames.Count == 11;

            var nextFrame = NextFrame(frame, frames);

            var secondFrame = extra ? nextFrame : NextFrame(nextFrame, frames);

            return nextFrame.First + (nextFrame.IsStrike ? secondFrame.First : nextFrame.Second);
        }

        private static IBowlingFrame NextFrame(IBowlingFrame frame, IList<IBowlingFrame> frames)
        {
            var index = frames.IndexOf(frame);

            return index == -1 || index == frames.Count - 1 ? _empty : frames[index + 1];
        }
    }
}