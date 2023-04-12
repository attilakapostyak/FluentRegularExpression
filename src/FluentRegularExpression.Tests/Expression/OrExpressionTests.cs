using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class OrExpressionTests : BaseTests
    {
        public OrExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void OrExpression_Returns_Correct_Expression()
        {
            var expression = new OrExpression();
            
            var result = expression.Render();
            
            Assert.Equal(@"|", result);
        }

    }
}
