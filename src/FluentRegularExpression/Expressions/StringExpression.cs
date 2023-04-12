namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents a string literal in a Fluent Regular Expression.
    /// </summary>
    public class StringExpression : FluentRegexExpression
    {
        private string _content = string.Empty;

        /// <summary>
        /// Initializes a new instance of the StringExpression class with the specified string content.
        /// </summary>
        /// <param name="content">The string content of the StringExpression.</param>
        public StringExpression(string content)
        {
            _content = content;
        }

        /// <summary>
        /// Renders the StringExpression as a regular expression string.
        /// </summary>
        /// <returns>The regular expression string for the StringExpression.</returns>
        public override string Render()
        {
            return _content;
        }
    }
}
