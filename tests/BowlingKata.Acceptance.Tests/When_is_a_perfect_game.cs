using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Acceptance.Tests
{
    public class When_is_a_perfect_game : GameSpecification
    {
        [Test]
        public void Should_have_score_300()
        {
            // act
            var game = this.GameBuilder
                .WithPerfectGame()
                .Build();

            // assert
            game.Score().Should().Be(300);
        }
    }
}