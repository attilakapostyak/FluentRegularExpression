using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class ElseExpressionTests : BaseTests
    {
        public ElseExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void ElseExpression_Returns_Expression()
        {
            var expression = new ElseExpression();

            expression.Match("test");
            
            var result = expression.Render();
            
            Assert.Equal(@"|test", result);
        }

        [Fact]
        public void ElseExpression_Throws_Exception_When_Then_Is_Not_Called_After_Then()
        {
            var builder = new FluentRegexBuilder();

            builder.Expressions.Else((x) => x.Match("test"));
            
            Assert.Throws<InvalidOperationException>( () => builder.Pattern);
        }

    }
}
