using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Acceptance.Tests
{
    public class When_no_pins_are_hit
    {
        [Test]
        public void Should_have_score_zero()
        {
            // arrange
            var gameBuilder = new GameBuilder();

            // act
            var game = gameBuilder
                .WithZeroScore()
                .Build();

            // assert
            game.Score().Should().Be(0);
        }
    }
}
