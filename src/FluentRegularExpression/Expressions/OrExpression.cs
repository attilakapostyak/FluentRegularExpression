namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents a regular expression OR expression.
    /// </summary>
    public class OrExpression : FluentRegexExpression
    {
        /// <summary>
        /// Initializes a new instance of the OrExpression class.
        /// </summary>
        public OrExpression()
        {
        }

        /// <summary>
        /// Renders the regular expression string for the OR expression.
        /// </summary>
        /// <returns>The regular expression string for the OR expression.</returns>
        public override string Render()
        {
            return $"|";
        }
    }
}
