namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents a regular expression conditional expression.
    /// </summary>
    public class IfExpression : FluentRegexExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IfExpression"/> class, setting the closing expression to an <see cref="IfExpression"/>.
        /// </summary>
        public IfExpression()
        {
            _closingExpression = new EndIfExpression();
        }

        /// <summary>
        /// Renders the regular expression string for the if expression.
        /// </summary>
        /// <returns>The regular expression string for the if expression.</returns>
        public override string Render()
        {
            var groupName = string.Empty;

            return $"(?({base.Render()})";
        }
    }
}
