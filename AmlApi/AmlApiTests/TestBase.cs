using System.Diagnostics.CodeAnalysis;
using Moq.AutoMock;

namespace AmlApiTests;

[ExcludeFromCodeCoverage]
public abstract class TestBase<T> where T : class
{
    protected readonly AutoMocker AutoMocker = new();

    public TestBase()
    {
        
    }

    protected T CreateTestSubject()
    {
        return this.AutoMocker.CreateInstance<T>();
    }
}