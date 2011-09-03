namespace BowlingKata.Unit.Tests
{
    public abstract class SpecificationBaseWithNoContract<TConcrete>
        : SpecificationBaseWithContract<TConcrete, TConcrete>
    {
    }
}