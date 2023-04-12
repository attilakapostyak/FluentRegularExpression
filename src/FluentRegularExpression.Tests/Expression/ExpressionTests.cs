using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class ExpressionTests : BaseTests
    {
        public ExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void Expression_Use_All_Expressions_Returns_Expected_Result()
        { 
            var expected = "..\\t\\v\\a\\b\\r\\f\\n\\e\\s\\S\\d\\D\\w\\W\\x\\O\\u^\\A$\\Z$\\G\\b\\B(?#comment)test+?*{1}{1}{1,}{5,10}\\1\\k<RefNamedGroup>(test)(?<GroupName>test)(?<GroupName1-GroupName2>test)(?:test)(?=test)(<!test)(?!test)(<!test)(?>test)|(?(test)test|test)[a-z][^test]test(?m)(?n:test)";
            var builder = new FluentRegexBuilder();
            builder.Expressions
                .Any()
                .AnyExceptNewLine()
                .HorizontalTab()
                .VerticalTab()
                .Bell()
                .Backspace()
                .CarriageReturn()
                .FormFeed()
                .NewLine()
                .Escape()
                .WhiteSpace()
                .NotWhiteSpace()
                .Digit()
                .NotDigit()
                .Word()
                .NotWord()
                .HexadecimalDigit()
                .OctalDigit()
                .Unicode()
                .StartOfStringOrLine()
                .StartOfString()
                .EndOfString()
                .EndOfStringOrBeforeNewLineAtEndOfString()
                .EndOfStringOrBeforeNewLineAtEndOfStringOrLine()
                .WherePreviousMatchEnded()
                .OnWordBoundary()
                .NotOnWordBoundary()
                .Comment("comment")
                .Match("test")
                .OneOrMore()
                .ZeroOrOne()
                .ZeroOrMore()
                .ExactlyOne()
                .Exactly(1)
                .AtLeast(1)
                .FromTo(5, 10)
                .ReferenceIndexedGroup(1)
                .ReferenceNamedGroup("RefNamedGroup")
                .IndexedGroup((x) => x.Match("test"))
                .GroupAs("GroupName", (x) => x.Match("test"))
                .BalancingGroupAs("GroupName1", "GroupName2", BalancingGroupOperation.Push, (x) => x.Match("test"))
                .NonCapturingGroup((x) => x.Match("test"))
                .ZeroWidthPositiveLookahead((x) => x.Match("test"))
                .ZeroWidthPositiveLookbehind((x) => x.Match("test"))
                .ZeroWidthNegativeLookahead((x) => x.Match("test"))
                .ZeroWidthNegativeLookbehind((x) => x.Match("test"))
                .NonBacktrackingGroup((x) => x.Match("test"))
                .Or()
                .If((x) => x.Match("test"))
                .Then((x) => x.Match("test"))
                .Else((x) => x.Match("test"))
                .OneOf((x) => x.Range((x) => x.Match("a"), (x) => x.Match("z")))
                .NotOneOf((x) => x.Match("test"))
                .Characters("test")
                .InlineOptions(FluentRegexOptions.MultilineMode)
                .ExpressionWithOptions((x) => x.Match("test"), FluentRegexOptions.ExplicitCapture);

            var result = builder.Pattern;
            
            Assert.Equal(expected, result);
        }

    }
}
