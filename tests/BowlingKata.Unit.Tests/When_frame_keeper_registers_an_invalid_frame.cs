using System;
using MavenThought.Commons.Extensions;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_frame_keeper_registers_an_invalid_frame : FrameKeeperSpecification
    {
        public override void When()
        {
            20.Times(() => this.Sut.Keep(4));
        }

        [Test]
        public void Should_validate_that_can_not_add_another_frame()
        {
            new Action(() => this.Sut.Keep(AllPins))
                .Should("An invalid frame should be checked")
                .Throw<InvalidBowlingBallException>();
        }
    }
}