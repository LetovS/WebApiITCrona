using AutoFixture;
using AutoFixture.AutoMoq;

namespace UnitTests.Validators;

public abstract class ValidatorTestBase
{
    protected readonly IFixture AutoFixture = new Fixture().Customize(new AutoMoqCustomization());
}