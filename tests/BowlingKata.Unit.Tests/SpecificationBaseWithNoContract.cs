using NUnit.Framework;

namespace BowlingKata.Unit.Tests
{
    public abstract class SpecificationBaseWithNoContract<TContract, TConcrete>
        : ISpecificationWithContract<TContract, TConcrete> where TConcrete : TContract
    {
        protected abstract TContract CreateSut();

        public TContract Sut { get; private set; }

        public TConcrete ConcreteSut
        {
            get { return (TConcrete) this.Sut; }
        }

        public virtual void Given()
        {
        }

        public abstract void When();

        [SetUp]
        public void SetUp()
        {
            this.Given();

            this.Sut = this.CreateSut();

            this.When();
        }
    }
}