using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{

    public class OneOfExpressionTests : BaseTests
    {
        public OneOfExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void OneOfExpression_Returns_Correct_Expression()
        {
            var expression = new OneOfExpression(false);

            expression.Match("abc");
            var result = expression.Render();
            
            Assert.Equal(@"[abc]", result);
        }

        [Fact]
        public void NotOneOfExpression_Returns_Correct_Expression()
        {
            var expression = new OneOfExpression(true);

            expression.Match("abc");
            var result = expression.Render();
            
            Assert.Equal(@"[^abc]", result);
        }


    }
}
