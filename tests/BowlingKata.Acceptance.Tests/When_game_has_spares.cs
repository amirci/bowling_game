using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Acceptance.Tests
{
    public class When_game_has_spares
    {
        [Test]
        public void Should_add_the_first_balls_for_spares()
        {
            // arrange
            var gameBuilder = new GameBuilder();

            // act
            var game = gameBuilder
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddFrame(4, 5)
                .AddSpare(5)
                .AddBall(5)
                .Build();

            // assert
            game.Score().Should().Be(9 * 9 + 10 * 2);
        }
    }
}