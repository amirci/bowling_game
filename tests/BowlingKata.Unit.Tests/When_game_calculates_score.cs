using System;
using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_game_calculates_score : BowlingGameSpecification
    {
        private int _actual;

        [Fake]
        private IEnumerable<IBowlingFrame> _frames;

        private int _expected;

        public override void Given()
        {
            base.Given();

            this._expected = new Random().Next(0, 300);

            A.CallTo(() => this.FrameKeeper.Frames).Returns(_frames);

            A.CallTo(() => this.ScoreCalculator.Calculate(this._frames)).Returns(_expected);
        }

        public override void When()
        {
            this._actual = this.Sut.Score();
        }

        [Test]
        public void Should_call_the_calculator()
        {
            this._actual.Should().Be(this._expected);
        }
    }
}