
using System.Collections.Generic;
using FakeItEasy;

namespace BowlingKata.Unit.Tests
{
    /// <summary>
    /// Base specification for ScoreCalculator
    /// </summary>
    public abstract class ScoreCalculatorSpecification
        : SpecificationBaseWithContract<IScoreCalculator, ScoreCalculator>
    {
        protected IEnumerable<IBowlingFrame> Frames { get; set; }

        public override void Given()
        {
            base.Given();

            this.Frames = A.CollectionOfFake<IBowlingFrame>(10);
        }

        protected override IScoreCalculator CreateSut()
        {
            return new ScoreCalculator();
        }

    }
}