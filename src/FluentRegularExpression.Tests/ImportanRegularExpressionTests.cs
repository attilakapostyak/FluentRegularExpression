using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests
{
    public class ImportanRegularExpressionTests : BaseTests
    {
        public ImportanRegularExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void Email_Id_Validation_Regular_Expression()
        {
            var builder = new FluentRegexBuilder();
            builder.Expressions.StartOfStringOrLine()
                .Word().OneOrMore()
                .IndexedGroup(g => g
                    .OneOf(o => o.Match("-+.'", false)).Word().OneOrMore())
                .ZeroOrMore().Match("@").Word()
                .OneOrMore().IndexedGroup(g => g
                    .OneOf(o => o.Match("-.", false)).Word().OneOrMore())
                .ZeroOrMore().Match(".").Word().OneOrMore()
                .IndexedGroup(g => g.OneOf(o => o.Match("-.", false)).Word().OneOrMore())
                .ZeroOrMore()
                .EndOfStringOrBeforeNewLineAtEndOfStringOrLine();

            string expectedPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            Assert.Equal(expectedPattern, builder.Pattern);

            Assert.True(builder.IsMatch("john@company.com"));
            Assert.True(builder.IsMatch("john+1@company.com"));
            Assert.True(builder.IsMatch("john.johny@company.com"));

            Assert.False(builder.IsMatch("Abc.example.com"));
            Assert.False(builder.IsMatch("A@b@c@example.com"));
            Assert.False(builder.IsMatch("just\"not\"right@example.com"));
            Assert.False(builder.IsMatch("this is\"not\\allowed@example.com"));
            Assert.False(builder.IsMatch("this\\ still\\\"notallowed@example.com"));

        }

        [Fact]
        public void Email_Specific_Domain_Validation_Regular_Expression()
        {
            var builder = new FluentRegexBuilder();

            builder.Expressions.StartOfStringOrLine()
                .Word().OneOrMore()
                .IndexedGroup(g => g
                    .OneOf(o => o.Match("-+.'", false)).Word().OneOrMore())
                .ZeroOrMore().Match("@")
                .NonCapturingGroup(g => g.Match("gmail.com|yahoo.com|hotmail.com", false)).Exactly(1)
                .EndOfStringOrBeforeNewLineAtEndOfStringOrLine();

            string expectedPattern = @"^\w+([-+.']\w+)*@(?:gmail.com|yahoo.com|hotmail.com){1}$";

            Assert.Equal(expectedPattern, builder.Pattern);

            Assert.True(builder.IsMatch("john@gmail.com"));
            Assert.True(builder.IsMatch("john+1@yahoo.com"));
            Assert.True(builder.IsMatch("john.johny@hotmail.com"));
            Assert.False(builder.IsMatch("john.jonathan@mail.com"));
            Assert.False(builder.IsMatch("john.jonathan@"));
        }

        [Fact]
        public void Url_Validation_Regular_Expression()
        {
            var builder = new FluentRegexBuilder();

            builder.Expressions
                .StartOfStringOrLine()
                .NonCapturingGroup(g => g.Match("http").NonCapturingGroup(g => g.Match("s")).ZeroOrOne().Match("://", false))
                .ZeroOrOne()
                .NonCapturingGroup(g => g
                    .OneOf(o => o.Word().Match("-.")).OneOrMore()
                    .OneOf(o => o.Match(".", false).Word()).Exactly(1)
                    .NonCapturingGroup(g => g
                        .OneOf(o => o.Word().Match("/?%&=-")).ZeroOrMore())).ZeroOrOne()
                .EndOfString();

            string expectedPattern = @"^(?:http(?:s)?://)?(?:[\w-\.]+[.\w]{1}(?:[\w/\?%&=-]*))?$";
            
            Assert.Equal(expectedPattern, builder.Pattern);

            Assert.True(builder.IsMatch("http://company.com"));
            Assert.True(builder.IsMatch("http://app.company.com"));
            Assert.True(builder.IsMatch("https://company.com"));
            Assert.True(builder.IsMatch("https://company.com/blog/today?order=newest"));
            Assert.False(builder.IsMatch("htttp://badurl.com"));
            Assert.False(builder.IsMatch("ftp://invalidhttp.com"));
        }

        [Fact]
        public void String_Contains_Number_Regular_Expression()
        {
            var builder = new FluentRegexBuilder();

            builder.Expressions
                .IndexedGroup(g => g.Any())
                .ZeroOrMore()
                .IndexedGroup(g => g.Digit())
                .IndexedGroup(g => g.Any())
                .ZeroOrMore();

            string expectedPattern = @"(.)*(\d)(.)*";

            Assert.Equal(expectedPattern, builder.Pattern);

            Assert.True(builder.IsMatch("12"));
            Assert.True(builder.IsMatch(".12"));
            Assert.True(builder.IsMatch("12.a"));
            Assert.False(builder.IsMatch("test"));
        }

        [Fact]
        public void String_Is_Only_10_Digit_Number_Regular_Expression()
        {
            var builder = new FluentRegexBuilder();

            builder.Expressions
                .StartOfStringOrLine()
                .Digit()
                .Exactly(10)
                .EndOfString();

            string expectedPattern = @"^\d{10}$";

            var result = builder.Matches("htttp://badurl.com");

            Assert.Equal(expectedPattern, builder.Pattern);
 
            Assert.True(builder.IsMatch("1234567890"));
            Assert.True(builder.IsMatch("1111111111"));
            Assert.False(builder.IsMatch("123"));
            Assert.False(builder.IsMatch("111111111A"));
        }
    }
}
