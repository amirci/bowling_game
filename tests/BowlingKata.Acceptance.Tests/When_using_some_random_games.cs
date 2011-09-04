using System.Collections.Generic;
using NUnit.Framework;
using SharpTestsEx;

namespace BowlingKata.Acceptance.Tests
{
    public class When_using_some_random_games : GameSpecification
    {
        [Test]
        [TestCaseSource("GameFactory")]
        public void Should_match_the_game_score(IEnumerable<int> frames, int score)
        {
            // act
            var game = this.GameBuilder
                .WithFrames(frames)
                .Build();

            // assert
            game.Score().Should().Be(score);
        }

        protected static IEnumerable<object[]> GameFactory()
        {
            yield return new object[]
                             {
                                 new[]
                                     {
                                         1, 2,
                                         2, 4,
                                         3, 4,
                                         4, 3,
                                         9, 0,
                                         6, 1,
                                         10, 
                                         8, 1,
                                         9, 0,
                                         7, 3, 
                                         5
                                     },
                                 3 + 6 + 7 + 7 + 9 + 7 + 19 + 9 + 9 + 15
                             };

            yield return new object[]
                             {
                                 new[]
                                     {
                                         1, 9,
                                         2, 8,
                                         3, 4,
                                         10,
                                         9, 0,
                                         1, 1,
                                         1, 8,
                                         8, 2,
                                         9, 0,
                                         10, 
                                         5, 2
                                     },
                                 12 + 13 + 7 + 19 + 9 + 2 + 9 + 19 + 9 + 17
                             };
        }
    }
}