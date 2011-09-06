using FakeItEasy;
using NUnit.Framework;

namespace BowlingKata.Unit.Tests
{
    public class When_game_rolls_pins : BowlingGameSpecification
    {
        public override void When()
        {
            this.Sut.Roll(5);
        }
        
        [Test]
        public void Should_register_the_pins_down()
        {
            // assert
            A.CallTo(() => this.FrameKeeper.Keep(5)).MustHaveHappened();
        }
    }
}