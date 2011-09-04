using FakeItEasy;
using MavenThought.Commons.Extensions;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Unit.Tests
{
    public class When_score_calculator_has_spare_at_the_end : ScoreCalculatorSpecification
    {
        public override void Given()
        {
            base.Given();

            this.Frames.ForEach((i, f) =>
                                    {
                                        A.CallTo(() => f.First).Returns(i == 9 ? 5 : 4);
                                        A.CallTo(() => f.Second).Returns(5);
                                        A.CallTo(() => f.Score).Returns(f.First + f.Second);
                                        A.CallTo(() => f.IsSpare).Returns(f.Score == 10);
                                    });

            AddExtraFrame(5);

            this.Expected = 9 * 9 + 15;
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