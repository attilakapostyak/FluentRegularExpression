using System;
using System.Linq;

namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents an else expression in a fluent regular expression, which matches the pattern that follows an "if" expression if it doesn't match the "if" pattern.
    /// </summary>
    public class ElseExpression : FluentRegexExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElseExpression"/> class, setting the closing expression to an <see cref="EndIfExpression"/>.
        /// </summary>
        public ElseExpression()
        {
            _closingExpression = new EndIfExpression();
        }

        /// <summary>
        /// Validates that the "else" expression appears after an "if" expression.
        /// </summary>
        /// <param name="context">The <see cref="FluentRegexExpression"/> to validate against.</param>
        /// <exception cref="InvalidOperationException">Thrown if the "else" expression is called without a preceding "if" expression.</exception>
        public override void ValidateContext(FluentRegexExpression context)
        {
            var index = context._subExpressions.IndexOf(this);
            if (index > 0)
            {
                var previousExpression = context._subExpressions.ElementAt(index - 1);
                if (previousExpression is ThenExpression)
                {
                    return;
                }
            }

            throw new InvalidOperationException("Invalid call of method 'Else'. Should be called after 'If'.");
        }

        /// <summary>
        /// Renders the regular expression string for the "else" expression.
        /// </summary>
        /// <returns>The regular expression string for the "else" expression.</returns>
        public override string Render()
        {
            var groupName = string.Empty;

            return $"|{base.Render()}";
        }
    }

}
