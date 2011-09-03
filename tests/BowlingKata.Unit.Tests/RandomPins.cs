using System;

namespace BowlingKata.Unit.Tests
{
    public class RandomPins
    {
        private readonly Random _rnd = new Random();

        public Tuple<int, int> LameFrame()
        {
            var first = NewBall();

            return Tuple.Create(first, _rnd.Next(0, 10 - first - 1));
        }

        public Tuple<int, int> Spare()
        {
            var first = NewBall();

            return Tuple.Create(first, 10 - first);
        }

        private int NewBall()
        {
            return this._rnd.Next(0, 9);
        }
    }
}