using System;
using System.Linq;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_frame_keeper_registers_first_ball : FrameKeeperSpecification
    {
        private int _pins;

        public override void Given()
        {
            base.Given();

            _pins = new Random().Next(0, 10);
        }

        public override void When()
        {
            this.Sut.Keep(_pins);
        }

        [Test]
        public void Should_add_a_frame_with_the_score()
        {
            this.Sut.Frames.Last().First.Should().Be(_pins);
        }
    }
}