using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class MatchExpressionTests : BaseTests
    {
        public MatchExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void MatchExpression_Returns_Correct_Expression()
        {
            var expression = new MatchExpression("words", true);
            
            var result = expression.Render();
            
            Assert.Equal(@"words", result);
        }

    }
}
