using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Acceptance.Tests
{
    public class When_is_a_perfect_game
    {
        [Test]
        public void Should_have_score_300()
        {
            // arrange
            var gameBuilder = new GameBuilder();

            // act
            var game = gameBuilder
                .WithPerfectGame()
                .Build();

            // assert
            game.Score().Should().Be(300);
        }
    }    
}