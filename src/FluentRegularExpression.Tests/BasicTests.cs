using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests
{
    public class BasicTests
    {
        private readonly ITestOutputHelper TestOutputHelper;

        public BasicTests(ITestOutputHelper testOutputHelper) 
        {
            TestOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test_GenericExpression()
        {
            var builder = new FluentRegexBuilder();
            builder.Expressions
                .IndexedGroup((x) => x.Match("IndexedGroup").AtLeast(999))
                .GroupAs("testgroup", (x) => x.Match(@"\asd").AtLeast(2).Match("zxc").ZeroOrOne())
                .If((x) => x.Match("If").Match("Condition"))
                .Then((x) => x.Match("Then").Exactly(13))
                .Else((x) => x.Match("Else").FromTo(12,22))
                .GroupAs("testgroup2", (x) => x.If((x) => x.Match("If").Match("Condition"))
                                                    .Then((x) => x.Match("Then"))
                                                    .Else((x) => x.Match("Else")).Match("AfterIf"))
                .Comment("cool")
                .OneOf((x) => x.Match("OneOf").Range((x) => x.Characters("From"), (x) => x.Characters("To")))
                .NotOneOf((x) => x.Match("NotOneOf"))
                .InlineOptions(FluentRegexOptions.CaseInsensitive, FluentRegexOptions.MultilineMode, FluentRegexOptions.ExplicitCapture, FluentRegexOptions.SinglelineMode, FluentRegexOptions.IgnoreWhiteSpace)
                .ExpressionWithOptions((x) => x.Match("ExpressionWithOptions"), FluentRegexOptions.CaseInsensitive, FluentRegexOptions.MultilineMode, FluentRegexOptions.ExplicitCapture, FluentRegexOptions.SinglelineMode, FluentRegexOptions.IgnoreWhiteSpace);

            TestOutputHelper.WriteLine(builder.RegularExpression);
        }


        //[Fact]
        //public void Test_Main()
        //{
        //    var builder = new RegExpBuilder();
        //    builder
        //        ////.Comment("Match zero or more digits")
        //        //.GroupAs("digit")
        //        //    .Match(RegExpBuilder.DigitCharacter)
        //        //    .ZeroOrMore()
        //        //.And()
        //        ////.Comment("Match one or more words")
        //        //.GroupAs("words")
        //        //    .Match(RegExpBuilder.WordCharacter)
        //        //    .OneOrMore()
        //        //.And()
        //        .BalancingGroupAs("anotherwords", BalancingGroupOperation.Push)
        //            .Match(RegExpBuilder.WordCharacter)
        //            .ZeroOrOne()
        //            .InlineOptions(RegExpBuilder.CaseInsensitive, RegExpBuilder.MultilineMode, RegExpBuilder.ExplicitCapture, RegExpBuilder.SinglelineMode, RegExpBuilder.IgnoreWhiteSpace)
        //            .Match("InlineOptions")
        //            .InlineOptionsForExpression(RegExpBuilder.CaseInsensitive, RegExpBuilder.MultilineMode, RegExpBuilder.ExplicitCapture, RegExpBuilder.SinglelineMode, RegExpBuilder.IgnoreWhiteSpace)
        //                .Match("InlineOptionsForExpression")
        //                .ZeroOrMore()
        //            .And()
        //        .And()
        //        .Match("END")
        //        .If()
        //            .Match("condition")
        //        .Then()
        //            .Match("then")
        //        .Else()
        //            .Match("else");



        //    var result = builder.Render();

        //    TestOutput.WriteLine(result);

        //    Assert.Equal(@"(?#Match zero or more digits)\d*(?#Match one or more words)\w+", result);
        //}
    }
}
