using FakeItEasy;
using NUnit.Framework;

namespace BowlingKata.Unit.Tests
{
    public class When_game_rolls_pins : BowlingGameSpecification
    {
        [Test]
        public void Should_register_the_pins_down()
        {
            // arrange
            var scoreKeeper = A.Fake<IFrameKeeper>();

            // act
            var game = new BowlingGame(scoreKeeper);

            game.Roll(5);

            // assert
            A.CallTo(() => scoreKeeper.Keep(5)).MustHaveHappened();
        }
    }
}