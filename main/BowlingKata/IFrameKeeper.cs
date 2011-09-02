using System.Collections.Generic;

namespace BowlingKata
{
    public interface IFrameKeeper
    {
        void Keep(int pins);

        IEnumerable<IBowlingFrame> Frames { get; }
    }
}