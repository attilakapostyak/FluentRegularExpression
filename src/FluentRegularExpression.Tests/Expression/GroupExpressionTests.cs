using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class GroupExpressionTests : BaseTests
    {
        public GroupExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Theory]
        [InlineData("", "", GroupType.IndexedGroup, BalancingGroupOperation.Push, "(text)")]
        [InlineData("TestNamedGroup", "", GroupType.NamedGroup, BalancingGroupOperation.Push, "(?<TestNamedGroup>text)")]
        [InlineData("TestBalancingGroup1", "TestBalancingGroup2", GroupType.BalancingGroup, BalancingGroupOperation.Push, "(?<TestBalancingGroup1-TestBalancingGroup2>text)")]
        [InlineData("TestBalancingGroup1", "TestBalancingGroup2", GroupType.BalancingGroup, BalancingGroupOperation.Pop, "(?<-TestBalancingGroup1-TestBalancingGroup2>text)")]
        [InlineData("", "", GroupType.NonCapturingGroup, BalancingGroupOperation.Pop, "(?:text)")]
        [InlineData("", "", GroupType.ZeroWidthPositiveLookahead, BalancingGroupOperation.Push, "(?=text)")]
        [InlineData("", "", GroupType.ZeroWidthNegativeLookahead, BalancingGroupOperation.Push, "(?!text)")]
        [InlineData("", "", GroupType.ZeroWidthPositiveLookbehind, BalancingGroupOperation.Push, "(?<=text)")]
        [InlineData("", "", GroupType.ZeroWidthNegativeLookbehind, BalancingGroupOperation.Push, "(<!text)")]
        [InlineData("", "", GroupType.NonBacktrackingGroup, BalancingGroupOperation.Push, "(?>text)")]
        public void GroupExpression_Returns_Expression_For_All_Group_Types(string groupName1, string groupName2, GroupType groupType, BalancingGroupOperation balancingGroupOperation, string expectedResult)
        {
            var expression = new GroupExpression(groupName1, groupName2, groupType, balancingGroupOperation);
            expression.Match("text");

            var result = expression.Render();
            
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GroupExpression_Requires_Group_Name_For_Named_Group_And_Balancing_Group()
        {
            Assert.Throws<ArgumentException>( () => new GroupExpression(string.Empty, GroupType.NamedGroup, BalancingGroupOperation.Push));
            Assert.Throws<ArgumentException>( () => new GroupExpression(string.Empty, GroupType.BalancingGroup, BalancingGroupOperation.Push));
        }

        [Fact]
        public void GroupExpression_Requires_No_Group_Name_For_All_Group_Types_Except_Named_Group_And_Balancing_Group()
        {
            Assert.Throws<ArgumentException>( () => new GroupExpression("SomeGroupName", GroupType.IndexedGroup, BalancingGroupOperation.Push));
        }

        [Fact]
        public void GroupExpression_Invalid_Group_Type_Throws_Exception()
        {
            var groupExpresstion = new GroupExpression(string.Empty, (GroupType)999, BalancingGroupOperation.Push);
            var pattern = groupExpresstion.Render();

            Assert.Equal("()", pattern);
        }



    }
}
