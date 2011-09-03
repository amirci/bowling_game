using System.Collections.Generic;

namespace BowlingKata
{
    public interface IScoreCalculator
    {
        int Calculate(IEnumerable<IBowlingFrame> frames);
    }

    public class ScoreCalculator : IScoreCalculator
    {
        public int Calculate(IEnumerable<IBowlingFrame> frames)
        {
            return 0;
        }
    }
}