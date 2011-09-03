using System;
using System.Linq;
using MavenThought.Commons.Extensions;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_frame_keeper_registers_strike_on_last_frame : FrameKeeperSpecification
    {
        public override void When()
        {
            10.Times(() => this.Sut.Keep(AllPins));

            this.Sut.Keep(AllPins);
            this.Sut.Keep(AllPins);
        }

        [Test]
        public void Should_add_an_11th_frame_with_both_balls()
        {
            this.Sut.Frames
                .Select(f => f.ToTuple())
                .Should()
                .Have.SameSequenceAs(10.Times(() => Tuple.Create(AllPins, 0))
                                         .Concat(Tuple.Create(AllPins, AllPins)));
        }
    }
}