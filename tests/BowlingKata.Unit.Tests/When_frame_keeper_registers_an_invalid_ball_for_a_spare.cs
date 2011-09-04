using System;
using MavenThought.Commons.Extensions;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_frame_keeper_registers_an_invalid_ball_for_a_spare : FrameKeeperSpecification
    {
        public override void When()
        {
            18.Times(() => this.Sut.Keep(4));

            // last throw is a spare
            this.Sut.Keep(9);
            this.Sut.Keep(1);

            // extra 1 ball
            this.Sut.Keep(8);
        }

        [Test]
        public void Should_validate_that_can_not_add_another_frame()
        {
            // extra 2nd ball is invalid
            new Action(() => this.Sut.Keep(AllPins))
                .Should("A second extra ball for a spare should be invalid")
                .Throw<InvalidBowlingBallException>();
        }
    }
}