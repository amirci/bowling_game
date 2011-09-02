
using System;

namespace BowlingKata.Unit.Tests
{
    /// <summary>
    /// Base specification for FrameKeeper
    /// </summary>
    public abstract class FrameKeeperSpecification
        : SpecificationBaseWithNoContract<IFrameKeeper, FrameKeeper>
    {
        protected Tuple<int, int> RandomFrame;

        protected int SecondBall
        {
            get { return this.RandomFrame.Item2; }
        }

        protected int FirstBall
        {
            get { return this.RandomFrame.Item1; }
        }

        public override void Given()
        {
            base.Given();

            this.RandomFrame = new RandomPins().RandomLameFrame();
        }

        protected override IFrameKeeper CreateSut()
        {
            return new FrameKeeper();
        }
    }
}