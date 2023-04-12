using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class CommentExpressionTests : BaseTests
    {
        public CommentExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void CommentExpression_Returns_Correct_Expression()
        {
            var expression = new CommentExpression("words");
            
            var result = expression.Render();
            
            Assert.Equal(@"(?#words)", result);
        }

    }
}
