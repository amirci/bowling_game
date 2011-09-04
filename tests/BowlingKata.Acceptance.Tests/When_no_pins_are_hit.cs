using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Acceptance.Tests
{
    public class When_no_pins_are_hit : GameSpecification
    {
        [Test]
        public void Should_have_score_zero()
        {
            // act
            var game = this.GameBuilder
                .WithZeroScore()
                .Build();

            // assert
            game.Score().Should().Be(0);
        }
    }
}
