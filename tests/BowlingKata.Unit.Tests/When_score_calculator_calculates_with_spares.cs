using FakeItEasy;
using MavenThought.Commons.Extensions;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_score_calculator_calculates_with_spares : ScoreCalculatorSpecification
    {
        public override void Given()
        {
            base.Given();

            // Setup all frames with one spare
            this.Frames.ForEach((i, f) =>
                                    {
                                        A.CallTo(() => f.First).Returns(i == 5 ? 5 : 4);
                                        A.CallTo(() => f.Second).Returns(5);
                                        A.CallTo(() => f.Score).Returns(f.First + f.Second);
                                        A.CallTo(() => f.IsSpare).Returns(f.Score == 10);
                                    });

            this.Expected = 9 * 9 + 10 + 4;
        }

        public override void When()
        {
            this.Actual = this.Sut.Calculate(this.Frames);
        }

        [Test]
        public void Should_add_the_next_ball_for_the_spare()
        {
            this.Actual.Should().Be(this.Expected);
        }
    }
}