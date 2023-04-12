using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Common
{
    public class BaseTests
    {
        internal readonly ITestOutputHelper TestOutput;

        public BaseTests(ITestOutputHelper testOutputHelper)
        {
            TestOutput = testOutputHelper;
        }

    }
}
