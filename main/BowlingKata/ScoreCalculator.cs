using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class ScoreCalculator : IScoreCalculator
    {
        public int Calculate(IEnumerable<IBowlingFrame> frames)
        {
            return frames.Select(f => f.Score).Sum();
        }
    }
}