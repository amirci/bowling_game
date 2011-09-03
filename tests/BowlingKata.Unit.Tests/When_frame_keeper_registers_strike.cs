using System;
using System.Linq;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_frame_keeper_registers_strike : FrameKeeperSpecification
    {
        public override void When()
        {
            this.Sut.Keep(AllPins);

            this.Sut.Keep(FirstBall);
        }

        [Test]
        public void Should_add_a_frame_with_all_the_pins_and_no_second_ball()
        {
            this.Sut.Frames
                .Select(f => f.ToTuple())
                .Should()
                .Have.SameSequenceAs(new[]
                                         {
                                             Tuple.Create(10, 0),
                                             Tuple.Create(FirstBall, 0)
                                         });
        }

        [Test]
        public void Should_add_a_strike_frame()
        {
            this.Sut.Frames.First().IsStrike.Should().Be.True();
        }
    }
}