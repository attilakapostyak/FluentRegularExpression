using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class ThenExpressionTests : BaseTests
    {
        public ThenExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void ThenExpression_Returns_Expression()
        {
            var expression = new ThenExpression();

            expression.Match("test");
            
            var result = expression.Render();
            
            Assert.Equal(@"test", result);
        }

        [Fact]
        public void ThenExpression_Throws_Exception_When_Then_Is_Not_Called_After_If()
        {
            var builder = new FluentRegexBuilder();

            builder.Expressions.Then((x) => x.Match("test"));
            
            Assert.Throws<InvalidOperationException>( () => builder.Pattern);
        }

    }
}
