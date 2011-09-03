using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class FrameKeeper : IFrameKeeper
    {
        private readonly ICollection<IBowlingFrame> _frames = new List<IBowlingFrame>();

        private Action<int> _action;

        public FrameKeeper()
        {
            _action = FirstBall;
        }

        public void Keep(int pins)
        {
            _action(pins);
        }

        private void FirstBall(int pins)
        {
            var frame = new BowlingFrame(pins);

            this._frames.Add(frame);

            if (!frame.IsStrike)
            {
                this._action = SecondBall;
            }
        }

        private void SecondBall(int pins)
        {
            var last = this._frames.Last();

            this._frames.Remove(last);

            this._frames.Add(new BowlingFrame(last.First, pins));

            this._action = FirstBall;
        }

        public IEnumerable<IBowlingFrame> Frames
        {
            get { return this._frames; }
        }
    }
}