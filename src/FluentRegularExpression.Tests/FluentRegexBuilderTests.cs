using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests
{
    public class FluentRegexBuilderTests : BaseTests
    {
        public FluentRegexBuilderTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void RegExpBuilder_Expressions_Returns_Singleton()
        {
            var builder = new FluentRegexBuilder();

            var expectedExpressionsInstance = builder.Expressions;
            var actualExpressionsInstance = builder.Expressions;

            Assert.Same(expectedExpressionsInstance, actualExpressionsInstance);
        }

        [Fact]
        public void RegExpBuilder_RegularExpression_Throws_Exception_When_No_Expressions_Are_Defined()
        {
            var builder = new FluentRegexBuilder();

            Assert.Throws<InvalidOperationException>(() => builder.Pattern);
        }

        [Fact]
        public void RegExpBuilder_Returns_Performs_Validation_Before_Generating_RegExp()
        {
            var builder = new FluentRegexBuilder();
            builder.Expressions.Then((x) => x.Comment("SomeExpression"));

            Assert.Throws<InvalidOperationException>(() => builder.Pattern);
        }

        [Fact]
        public void RegExpBuilder_Returns_Match_Any_Character_Zero_Or_More()
        {
            var builder = new FluentRegexBuilder();
            builder.Expressions.Any().ZeroOrMore();

            var result = builder.Pattern;

            Assert.Equal(".*", result);
        }

        [Fact]
        public void RegExpBuilder_IsMatch_Returns_True()
        {
            var builder = new FluentRegexBuilder();
            builder.Expressions.Any().ZeroOrMore();

            Assert.True(builder.IsMatch("test"));
        }

        [Fact]
        public void RegExpBuilder_IsMatch_Returns_False()
        {
            var builder = new FluentRegexBuilder();
            builder.Expressions.Match("SomeText");

            Assert.False(builder.IsMatch("DifferentText"));
        }

        [Fact]
        public void RegExpBuilder_Matches_Returns_True()
        {
            var builder = new FluentRegexBuilder();
            builder.Expressions.Any().ZeroOrMore();

            var result = builder.Matches("test");

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void RegExpBuilder_Matches_Returns_False()
        {
            var builder = new FluentRegexBuilder();
            builder.Expressions.Match("SomeText");

            var result = builder.Matches("test");

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void RegExpBuilder_Clear_The_Expressions()
        {
            var text = "text";
            var secondText = "secondText";

            var builder = new FluentRegexBuilder();
            builder.Expressions.Match(text);

            Assert.Equal(text, builder.Pattern);

            builder.Clear();

            builder.Expressions.Match(secondText);

            Assert.Equal(secondText, builder.Pattern);
        }

    }
}
