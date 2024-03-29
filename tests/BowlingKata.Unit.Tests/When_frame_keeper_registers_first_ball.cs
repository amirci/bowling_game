using System;
using System.Linq;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_frame_keeper_registers_first_ball : FrameKeeperSpecification
    {
        public override void When()
        {
            this.Sut.Keep(this.RandomFrame.Item1);
        }

        [Test]
        public void Should_add_a_frame_with_the_score()
        {
            this.Sut.Frames
                .Select(f => f.ToTuple())
                .Should()
                .Have.SameSequenceAs(new[]
                                         {
                                             Tuple.Create(this.RandomFrame.Item1, 0)
                                         });
        }
    }
}