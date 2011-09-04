using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Acceptance.Tests
{
    public class When_game_has_spares : GameSpecification
    {
        [Test]
        public void Should_add_the_first_balls_for_spares()
        {
            // act
            var game = this.GameBuilder
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddSpare(3)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddSpare(5)
                .AddBall(5)
                .Build();

            // assert
            game.Score().Should().Be(8 * 9 + 10 * 2 + 4 + 5);
        }
    }
}