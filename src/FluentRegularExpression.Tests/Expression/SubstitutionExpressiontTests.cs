using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class SubstitutionExpressionTests : BaseTests
    {
        public SubstitutionExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void SubstitutionExpression_Invalid_Group_Number_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => new SubstitutionExpression(string.Empty, SubstitutionType.MatchedByGroupNumber));
        }

        [Fact]
        public void SubstitutionExpression_Invalid_Group_Name_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => new SubstitutionExpression(string.Empty, SubstitutionType.MatchedByGroupName));
        }

        [Fact]
        public void SubstitutionExpression_Returns_Correct_Expression()
        {
            var expression = new SubstitutionExpression("1", SubstitutionType.MatchedByGroupNumber);
            Assert.Equal(@"$1", expression.Render());

            expression = new SubstitutionExpression("1", SubstitutionType.MatchedByGroupName);
            Assert.Equal(@"${1}", expression.Render());

            expression = new SubstitutionExpression("1", SubstitutionType.LiteralDollarCharacter);
            Assert.Equal(@"$$", expression.Render());

            expression = new SubstitutionExpression("1", SubstitutionType.CopyOfWholeMatch);
            Assert.Equal(@"$&", expression.Render());

            expression = new SubstitutionExpression("1", SubstitutionType.TextBeforeTheMatch);
            Assert.Equal(@"$`", expression.Render());

            expression = new SubstitutionExpression("1", SubstitutionType.TextAfterTheMatch);
            Assert.Equal(@"$'", expression.Render());

            expression = new SubstitutionExpression("1", SubstitutionType.LastCapturedGroup);
            Assert.Equal(@"$+", expression.Render());

            expression = new SubstitutionExpression("1", SubstitutionType.EntireInputString);
            Assert.Equal(@"$_", expression.Render());

        }

    }
}
