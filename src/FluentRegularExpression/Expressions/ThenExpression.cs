using System;
using System.Linq;

namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents a "then" expression in a Fluent Regular Expression
    /// </summary>
    public class ThenExpression : FluentRegexExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThenExpression"/> class.
        /// </summary>
        public ThenExpression()
        {
            _closingExpression = new EndIfExpression();
        }

        /// <summary>
        /// Validates the context in which the <see cref="ThenExpression"/> is being used.
        /// The method checks if the previous expression in the context is an <see cref="IfExpression"/>.
        /// </summary>
        /// <param name="context">The context in which the <see cref="ThenExpression"/> is being used</param>
        public override void ValidateContext(FluentRegexExpression context)
        {
            var index = context._subExpressions.IndexOf(this);
            if (index > 0)
            {
                var previousExpression = context._subExpressions.ElementAt(index - 1);
                if (previousExpression is IfExpression)
                {
                    return;
                }
            }

            throw new InvalidOperationException("Invalid call of method 'Then'. Should be called after 'If'.");
        }

        /// <summary>
        /// Renders the current <see cref="ThenExpression"/> as a string.
        /// </summary>
        /// <returns>A string that represents the current <see cref="ThenExpression"/></returns>
        public override string Render()
        {
            var groupName = string.Empty;

            return base.Render();
        }

    }
}
