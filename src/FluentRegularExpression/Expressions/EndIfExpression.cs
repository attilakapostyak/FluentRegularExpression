namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents an end-if expression in a fluent regular expression, which marks the end of an "if" expression.
    /// </summary>
    public class EndIfExpression : FluentRegexExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndIfExpression"/> class.
        /// </summary>
        public EndIfExpression()
        {
        }

        /// <summary>
        /// Renders the regular expression string for the end-if expression.
        /// </summary>
        /// <returns>The regular expression string for the end-if expression.</returns>
        public override string Render()
        {
            return $")";
        }
    }

}
