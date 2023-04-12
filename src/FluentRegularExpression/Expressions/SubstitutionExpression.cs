using System;

namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Specifies the type of substitution to be performed in a replacement string.
    /// </summary>
    public enum SubstitutionType
    {
        /// <summary>
        /// The substitution is specified by group number.
        /// </summary>
        MatchedByGroupNumber = 0,
        /// <summary>
        /// The substitution is specified by group name.
        /// </summary>
        MatchedByGroupName = 1,
        /// <summary>
        /// A literal dollar character is substituted.
        /// </summary>
        LiteralDollarCharacter = 2,
        /// <summary>
        /// A copy of the entire match is substituted.
        /// </summary>
        CopyOfWholeMatch = 3,
        /// <summary>
        /// The text before the match is substituted.
        /// </summary>
        TextBeforeTheMatch = 4,
        /// <summary>
        /// The text after the match is substituted.
        /// </summary>
        TextAfterTheMatch = 5,
        /// <summary>
        /// The last captured group is substituted.
        /// </summary>
        LastCapturedGroup = 6,
        /// <summary>
        /// The entire input string is substituted.
        /// </summary>
        EntireInputString = 7
    }

    /// <summary>
    /// Represents a substitution expression in a regular expression replacement string.
    /// </summary>
    public class SubstitutionExpression : FluentRegexExpression
    {
        internal string _reference;
        internal SubstitutionType _substitutionType;

        /// <summary>
        /// Initializes a new instance of the SubstitutionExpression class with the specified group reference and substitution type.
        /// </summary>
        /// <param name="reference">The reference to the group to substitute.</param>
        /// <param name="substitutionType">The type of substitution to perform.</param>
        public SubstitutionExpression(string reference, SubstitutionType substitutionType)
        {
            switch (substitutionType)
            {
                case SubstitutionType.MatchedByGroupNumber:
                    if (string.IsNullOrEmpty(reference))
                        throw new ArgumentException("Invalid group number for substitution.");
                    break;
                case SubstitutionType.MatchedByGroupName:
                    if (string.IsNullOrEmpty(reference))
                        throw new ArgumentException("Invalid group name for substitution.");
                    break;
            }

            _reference = reference;
            _substitutionType = substitutionType;
        }

        /// <summary>
        /// Renders the SubstitutionExpression as a regular expression replacement string.
        /// </summary>
        /// <returns>A string representing the SubstitutionExpression in a regular expression replacement string.</returns>
        public override string Render()
        {
            string content = string.Empty;

            switch (_substitutionType)
            {
                case SubstitutionType.MatchedByGroupNumber:
                    content = _reference;
                    break;
                case SubstitutionType.MatchedByGroupName:
                    content = $"{{{_reference}}}";
                    break;
                case SubstitutionType.LiteralDollarCharacter:
                    content = @"$";
                    break;
                case SubstitutionType.CopyOfWholeMatch:
                    content = @"&";
                    break;
                case SubstitutionType.TextBeforeTheMatch:
                    content = @"`";
                    break;
                case SubstitutionType.TextAfterTheMatch:
                    content = @"'";
                    break;
                case SubstitutionType.LastCapturedGroup:
                    content = @"+";
                    break;
                case SubstitutionType.EntireInputString:
                    content = @"_";
                    break;
            }

            return $"${content}";
        }
    }
}
