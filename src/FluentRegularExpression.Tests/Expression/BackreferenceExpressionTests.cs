using FluentRegularExpression.Expressions;
using FluentRegularExpression.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace FluentRegularExpression.Tests.Expression
{
    public class BackreferenceExpressionTests : BaseTests
    {
        public BackreferenceExpressionTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        [Fact]
        public void BackreferenceExpression_Does_Not_Accept_Invalid_Reference()
        {
            Assert.Throws<ArgumentException>( () => new BackreferenceExpression(string.Empty, BackreferenceType.IndexedGroup));
            Assert.Throws<ArgumentException>( () => new BackreferenceExpression(string.Empty, BackreferenceType.NamedGroup));
        }

        [Fact]
        public void BackreferenceExpression_Render_Returns_Empty_On_Invalid_Type()
        {
            var expression = new BackreferenceExpression("1", (BackreferenceType)999);
            
            var result = expression.Render();
            
            Assert.Empty(result);
        }

        [Fact]
        public void BackreferenceExpression_For_Indexed_Group()
        {
            var expression = new BackreferenceExpression("1", BackreferenceType.IndexedGroup);
            
            var result = expression.Render();
            
            Assert.Equal(@"\1", result);
        }

        [Fact]
        public void BackreferenceExpression_For_Named_Group()
        {
            var expression = new BackreferenceExpression("words", BackreferenceType.NamedGroup);
            
            var result = expression.Render();
            
            Assert.Equal(@"\k<words>", result);
        }

    }
}
