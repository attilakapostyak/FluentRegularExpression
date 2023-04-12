namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents a regular expression that matches one of the characters specified in the expression.
    /// </summary>
    public class OneOfExpression : FluentRegexExpression
    {
        internal bool _notIn;

        /// <summary>
        /// Initializes a new instance of the OneOfExpression class.
        /// </summary>
        /// <param name="notIn">Specifies whether to negate the character set.</param>
        public OneOfExpression(bool notIn)
        {
            _notIn = notIn;
        }

        /// <summary>
        /// Renders the regular expression string for the OneOf expression.
        /// </summary>
        /// <returns>The regular expression string for the OneOf expression.</returns>
        public override string Render()
        {
            string notInStr = _notIn ? "^" : string.Empty;

            return $"[{notInStr}{base.Render()}]";
        }
    }
}
