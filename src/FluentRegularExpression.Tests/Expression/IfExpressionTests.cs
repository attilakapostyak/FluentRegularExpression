using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class IfExpressionTests : BaseTests
    {
        public IfExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void IfExpression_Returns_Expression()
        {
            var expression = new IfExpression();
            
            var result = expression.Render();
            
            Assert.Equal(@"(?()", result);
        }

    }
}
