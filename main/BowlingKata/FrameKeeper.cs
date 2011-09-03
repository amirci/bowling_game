using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class FrameKeeper : IFrameKeeper
    {
        private readonly ICollection<IBowlingFrame> _frames = new List<IBowlingFrame>();

        private Action<int> _nextAction;

        public FrameKeeper()
        {
            _nextAction = FirstBall;
        }

        public IEnumerable<IBowlingFrame> Frames
        {
            get { return this._frames; }
        }

        public void Keep(int pins)
        {
            _nextAction(pins);
        }

        private void FirstBall(int pins)
        {
            EnsureValidGame();

            var frame = new BowlingFrame(pins);

            this._frames.Add(frame);

            if (ShouldWaitForASecondBall(frame))
            {
                this._nextAction = SecondBall;
            }
        }

        private void SecondBall(int pins)
        {
            var last = this._frames.Last();

            this._frames.Remove(last);

            this._frames.Add(new BowlingFrame(last.First, pins));

            this._nextAction = FirstBall;
        }

        private bool ShouldWaitForASecondBall(IBowlingFrame frame)
        {
            return !frame.IsStrike || this._frames.Count == 11;
        }

        private void EnsureValidGame()
        {
            if (this._frames.Count == 10 && !this._frames.Last().IsStrike)
            {
                throw new InvalidBowlingBallException();
            }
        }
    }
}