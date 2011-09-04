using System;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Acceptance.Tests
{
    public class When_adding_a_an_invalid_extra_ball_for_a_spare : GameSpecification
    {
        [Test]
        public void Should_throw_an_exception()
        {
            // arrange
            var game = this.GameBuilder
                .AddFrames(first: 5, second: 4, times: 9)
                .AddSpare(5)
                .AddBall(3)
                .Build();

            // act & assert
            new Action(() => game.Roll(8)).Should().Throw();
        }
    }
}