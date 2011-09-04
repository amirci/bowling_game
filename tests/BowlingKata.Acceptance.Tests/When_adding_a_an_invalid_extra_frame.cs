using System;
using MavenThought.Commons.Extensions;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Acceptance.Tests
{
    public class When_adding_a_an_invalid_extra_frame : GameSpecification
    {
        [Test]
        public void Should_throw_an_exception()
        {
            // arrange
            10.Times(() => this.GameBuilder.AddFrame(5, 4));

            var game = this.GameBuilder.Build();

            // act & assert
            new Action(() => game.Roll(8)).Should().Throw();
        }
    }
}