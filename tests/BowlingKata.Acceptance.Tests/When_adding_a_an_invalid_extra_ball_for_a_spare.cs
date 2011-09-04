using System;
using MavenThought.Commons.Extensions;
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
            9.Times(() => this.GameBuilder.AddFrame(5, 4));

            this.GameBuilder.AddSpare(5);
            
            var game = this.GameBuilder.Build();

            game.Roll(8);

            // act & assert
            new Action(() => game.Roll(8)).Should().Throw();
        }
    }
}