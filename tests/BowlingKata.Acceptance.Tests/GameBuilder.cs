using System;
using System.Collections.Generic;
using MavenThought.Commons.Extensions;

namespace BowlingKata.Acceptance.Tests
{
    public class GameBuilder
    {
        private readonly BowlingGame _game;
        private readonly Random _random;
        private readonly IList<int> _frames;

        public GameBuilder()
        {
            _random = new Random();

            _game = new BowlingGame(new FrameKeeper(), new ScoreCalculator());

            _frames = new List<int>();
        }

        public BowlingGame Build()
        {
            return this._game;
        }

        public GameBuilder WithZeroScore()
        {
            20.Times(() => RollBall(0));

            return this;
        }

        public GameBuilder WithPerfectGame()
        {
            12.Times(() => RollBall(10));

            return this;
        }

        public GameBuilder AddSpare(int first)
        {
            RollBall(first);
            RollBall(10 - first);

            return this;
        }

        public GameBuilder WithBall(int times = 1)
        {
            times.Times(i =>
                            {
                                var first = this._random.Next(0, 9);
                                RollBall(first);
                                RollBall(10 - first - 1);
                            });

            return this;
        }

        private void RollBall(int pins)
        {
            this._game.Roll(pins);
            this._frames.Add(pins);

            var count = this._frames.Count;

            if (pins == 10 && count < 20 && count % 2 == 1)
            {
                this._frames.Add(0);
            }
        }

        public GameBuilder AddFrame(int first, int second)
        {
            RollBall(first);
            RollBall(second);

            return this;
        }

        public GameBuilder AddBall(int pins)
        {
            RollBall(pins);

            return this;
        }
    }
}