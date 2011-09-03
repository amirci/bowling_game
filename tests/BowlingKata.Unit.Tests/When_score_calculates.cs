using FakeItEasy;
using MavenThought.Commons.Extensions;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_score_calculates : ScoreCalculatorSpecification
    {
        private int _expected;

        public override void Given()
        {
            base.Given();

            this.Frames.ForEach(f =>
                                    {
                                        A.CallTo(() => f.IsStrike).Returns(true);
                                        A.CallTo(() => f.Score).Returns(10);
                                    });
        }

        public override void When()
        {
            this._expected = this.Sut.Calculate(this.Frames);
        }

        [Test]
        public void Should_get_maximum_score()
        {
            this._expected.Should().Be(300);
        }
    }
}