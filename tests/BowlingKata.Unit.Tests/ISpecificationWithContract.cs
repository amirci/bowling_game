namespace BowlingKata.Unit.Tests
{
    public interface ISpecificationWithContract<out TContract, out TConcrete> where TConcrete : TContract
    {
        TContract Sut { get; }

        void Given();

        void When();
    }
}