using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class OptionsExpressionTests : BaseTests
    {
        public OptionsExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void OptionsExpressionTests_Non_As_Expression_Returns_Correct_Pattern()
        {
            var expression = new OptionsExpression(false, FluentRegexOptions.CaseInsensitive | FluentRegexOptions.DisableExplicitCapture);
            
            var result = expression.Render();
            
            Assert.Equal(@"(?i-n)", result);
        }

        [Fact]
        public void OptionsExpressionTests_As_Expression_Returns_Correct_Pattern()
        {
            var expression = new OptionsExpression(true, FluentRegexOptions.CaseInsensitive | FluentRegexOptions.DisableExplicitCapture);
            
            var result = expression.Render();
            
            Assert.Equal(@"(?i-n:)", result);
        }

    }
}
