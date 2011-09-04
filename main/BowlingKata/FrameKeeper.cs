using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class FrameKeeper : IFrameKeeper
    {
        private readonly ICollection<IBowlingFrame> _frames = new List<IBowlingFrame>();

        private readonly IBowlingFrame _empty = new BowlingFrame(0);

        private Action<int> _nextAction;

        public FrameKeeper()
        {
            _nextAction = FirstBall;
        }

        public IEnumerable<IBowlingFrame> Frames
        {
            get { return this._frames; }
        }


        private bool LastWasSpare
        {
            get { return this._frames.DefaultIfEmpty(_empty).Last().IsSpare; }
        }

        private bool LastWasStrike
        {
            get { return this._frames.DefaultIfEmpty(_empty).Take(10).Last().IsStrike; }
        }
        
        private bool GameComplete
        {
            get { return this._frames.Count == 10; }
        }
        
        public void Keep(int pins)
        {
            _nextAction(pins);
        }

        private void FirstBall(int pins)
        {
            (!GameComplete || LastWasStrike || LastWasSpare).OrThrow<InvalidBowlingBallException>();

            var frame = new BowlingFrame(pins);

            this._frames.Add(frame);

            if (ShouldWaitForASecondBall(frame))
            {
                this._nextAction = SecondBall;
            }
        }

        private void SecondBall(int pins)
        {
            (this._frames.Count < 11 || LastWasStrike).OrThrow<InvalidBowlingBallException>();

            var last = this._frames.Last();

            this._frames.Remove(last);

            this._frames.Add(new BowlingFrame(last.First, pins));

            this._nextAction = FirstBall;
        }

        private bool ShouldWaitForASecondBall(IBowlingFrame frame)
        {
            return !frame.IsStrike || this._frames.Count == 11;
        }
    }
}