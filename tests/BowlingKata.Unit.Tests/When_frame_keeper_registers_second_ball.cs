using System.Linq;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_frame_keeper_registers_second_ball : FrameKeeperSpecification
    {
        public override void When()
        {
            this.Sut.Keep(FirstBall);
            this.Sut.Keep(SecondBall);
        }

        [Test]
        public void Should_add_a_frame_with_the_score()
        {
            this.Sut.Frames
                .Select(f => f.ToTuple())
                .Should()
                .Have.SameSequenceAs(new[]
                                         {
                                             this.RandomFrame
                                         });
        }
    }
}