using System.Text.RegularExpressions;

namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents a regular expression that matches a specific string.
    /// </summary>
    public class MatchExpression : FluentRegexExpression
    {
        private string _content = string.Empty;

        /// <summary>
        /// Initializes a new instance of the MatchExpression class with the specified string to match.
        /// </summary>
        /// <param name="content">The string to match.</param>
        /// <param name="escapeContent">Flag to indicate if the content should be escaped.</param>
        public MatchExpression(string content, bool escapeContent)
        {
            if (escapeContent)
            {
                _content = Regex.Escape(content);
            }
            else
            {
                _content = content;
            }
        }

        /// <summary>
        /// Renders the regular expression string for the match expression.
        /// </summary>
        /// <returns>The regular expression string for the match expression.</returns>
        public override string Render()
        {
            return _content;
        }
    }
}
