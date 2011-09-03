using System;

namespace BowlingKata
{
    public class InvalidBowlingBallException : Exception
    {
        public InvalidBowlingBallException() 
            : base("Can't throw another ball, the game is over!")
        {
        }
    }
}