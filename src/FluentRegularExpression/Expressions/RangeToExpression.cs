namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents the end of a character range expression in a Fluent Regular Expression.
    /// </summary>
    public class RangeToExpression : FluentRegexExpression
    {
        /// <summary>
        /// Initializes a new instance of the RangeToExpression class.
        /// </summary>
        public RangeToExpression()
        {
        }

        /// <summary>
        /// Renders the RangeToExpression as a regular expression string.
        /// </summary>
        /// <returns>The regular expression string for the RangeToExpression.</returns>
        public override string Render()
        {
            return $"-{base.Render()}";
        }
    }
}
