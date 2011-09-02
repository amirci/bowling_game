using System.Collections.Generic;

namespace BowlingKata
{
    public class FrameKeeper : IFrameKeeper
    {
        private readonly ICollection<IBowlingFrame> _frames = new List<IBowlingFrame>();

        public void Keep(int pins)
        {
            this._frames.Add(new BowlingFrame(pins));
        }

        public IEnumerable<IBowlingFrame> Frames
        {
            get { return this._frames; }
        }
    }
}