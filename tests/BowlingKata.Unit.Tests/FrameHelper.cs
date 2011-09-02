using System;

namespace BowlingKata.Unit.Tests
{
    public static class FrameHelper
    {
        public static Tuple<int, int> ToTuple(this IBowlingFrame frame)
        {
            return Tuple.Create(frame.First, frame.Second);
        }
    }
}