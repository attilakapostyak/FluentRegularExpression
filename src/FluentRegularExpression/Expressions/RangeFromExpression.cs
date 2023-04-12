using System;

namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents the start of a character range expression in a Fluent Regular Expression.
    /// </summary>
    public class RangeFromExpression : FluentRegexExpression
    {
        /// <summary>
        /// Initializes a new instance of the RangeFromExpression class.
        /// </summary>
        public RangeFromExpression()
        {
        }

        /// <summary>
        /// Validates that the current context is valid for a RangeFromExpression.
        /// </summary>
        /// <param name="context">The context to validate.</param>
        /// <exception cref="InvalidOperationException">Thrown when the context is not valid for a RangeFromExpression.</exception>
        public override void ValidateContext(FluentRegexExpression context)
        {
            bool foundValidParent = false;

            FluentRegexExpression indexExpression = this;

            while (indexExpression != null)
            {
                if (indexExpression is OneOfExpression)
                {
                    foundValidParent = true;
                    break;
                }

                indexExpression = indexExpression._parentExpression;
            }

            if (!foundValidParent)
            {
                throw new InvalidOperationException("RangeFrom can be called only from 'OneOf' or 'NotOneOf' methods.");
            }
        }

        /// <summary>
        /// Renders the RangeFromExpression as a regular expression string.
        /// </summary>
        /// <returns>The regular expression string for the RangeFromExpression.</returns>
        public override string Render()
        {
            return base.Render();
        }
    }
}
