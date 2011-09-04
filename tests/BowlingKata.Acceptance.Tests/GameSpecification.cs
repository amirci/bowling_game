using NUnit.Framework;

namespace BowlingKata.Acceptance.Tests
{
    public abstract class GameSpecification
    {
        protected GameBuilder GameBuilder { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.GameBuilder = new GameBuilder();
        }
    }
}