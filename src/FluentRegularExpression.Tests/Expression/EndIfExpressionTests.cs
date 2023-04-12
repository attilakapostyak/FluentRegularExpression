using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class EndIfExpressionTests : BaseTests
    {
        public EndIfExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void EndIfExpression_Returns_Expression()
        {
            var expression = new EndIfExpression();
            
            var result = expression.Render();
            
            Assert.Equal(@")", result);
        }

    }
}
