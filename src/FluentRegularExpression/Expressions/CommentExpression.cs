namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents a regular expression comment that provides additional information about a pattern.
    /// </summary>
    public class CommentExpression : FluentRegexExpression
    {
        private string _comment;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentExpression"/> class with the specified comment.
        /// </summary>
        /// <param name="comment">The comment to be included in the regular expression.</param>
        public CommentExpression(string comment)
        {
            _comment = comment;
        }

        /// <summary>
        /// Renders the regular expression string for the comment expression.
        /// </summary>
        /// <returns>The regular expression string for the comment expression.</returns>
        public override string Render()
        {
            return $"(?#{_comment}){base.Render()}";
        }
    }
}
