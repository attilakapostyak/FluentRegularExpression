using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class RangeFromExpressionTests : BaseTests
    {
        public RangeFromExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void RangeFromExpression_Returns_Expression()
        {
            var expression = new RangeFromExpression();
            
            var result = expression.Render();
            
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void RangeFromExpression_ValidateExpressions_Throws_Exception_If_Not_Used_In_Correct_Context()
        {
            var builder = new FluentRegexBuilder();
            builder.Expressions
                .OneOf((x) => x.Range((x) => x.Characters("From"), (x) => x.Characters("To")));

            var result = builder.Pattern;
            
            Assert.Equal("[From-To]", result);

            builder.Clear();

            builder.Expressions.Range((x) => x.Characters("From"), (x) => x.Characters("To"));
            
            Assert.Throws<InvalidOperationException>(() =>builder.Pattern);
        }

    }
}
