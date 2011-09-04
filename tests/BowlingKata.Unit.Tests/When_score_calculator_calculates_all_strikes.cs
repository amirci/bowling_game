using FakeItEasy;
using MavenThought.Commons.Extensions;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_score_calculator_calculates_all_strikes : ScoreCalculatorSpecification
    {
        private int _actual;

        public override void Given()
        {
            base.Given();

            this.Frames.ForEach(f =>
                                    {
                                        A.CallTo(() => f.IsStrike).Returns(true);
                                        A.CallTo(() => f.Score).Returns(10);
                                        A.CallTo(() => f.First).Returns(10);
                                    });

            var additionalFrame = A.Fake<IBowlingFrame>();

            this.Frames = this.Frames.Concat(additionalFrame);

            A.CallTo(() => additionalFrame.Score).Returns(20);
            A.CallTo(() => additionalFrame.First).Returns(10);
            A.CallTo(() => additionalFrame.Second).Returns(10);
        }

        public override void When()
        {
            this._actual = this.Sut.Calculate(this.Frames);
        }

        [Test]
        public void Should_get_maximum_score()
        {
            this._actual.Should().Be(300);
        }
    }
}