using System.Collections.Generic;

namespace BowlingKata
{
    public interface IScoreCalculator
    {
        int Calculate(IEnumerable<IBowlingFrame> frames);
    }
}