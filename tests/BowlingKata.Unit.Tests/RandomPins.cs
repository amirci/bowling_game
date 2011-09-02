using System;

namespace BowlingKata.Unit.Tests
{
    public class RandomPins
    {
        private readonly Random _rnd = new Random();

        public Tuple<int, int> RandomLameFrame()
        {
            var first = this._rnd.Next(0, 9);

            return Tuple.Create(first, _rnd.Next(0, 10 - first - 1));
        }
    }
}