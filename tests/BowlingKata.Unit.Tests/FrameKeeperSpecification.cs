
namespace BowlingKata.Unit.Tests
{
    /// <summary>
    /// Base specification for FrameKeeper
    /// </summary>
    public abstract class FrameKeeperSpecification
        : SpecificationBaseWithNoContract<IFrameKeeper, FrameKeeper>
    {
        protected override IFrameKeeper CreateSut()
        {
            return new FrameKeeper();
        }
    }
}