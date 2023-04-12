using FluentRegularExpression.Interfaces;
using FluentRegularExpression.Expressions;
using System.Text.RegularExpressions;
using System;

namespace FluentRegularExpression
{
    /// <summary>
    /// Represents a builder for creating fluent regular expressions.
    /// </summary>
    public class FluentRegexBuilder : IFluentRegexBuilder
    {
        private FluentRegexExpression _expressions = null;

        /// <summary>
        /// Gets the collection of FluentRegexExpression objects used to build the regular expression.
        /// </summary>
        /// <example>
        /// <code>
        ///     var builder = new FluentRegexBuilder();
        ///     builder.Expressions.Any().ZeroOrMore();
        /// </code>
        /// </example>
        public FluentRegexExpression Expressions 
        {
            get
            {
                if (_expressions == null)
                    _expressions = new FluentRegexExpression();

                return _expressions;
            }
        }

        /// <summary>
        /// Gets the regular expression pattern built by the builder.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if there are no expressions defined in the builder.</exception>
        public string Pattern
        {
            get
            {
                if (_expressions == null)
                {
                    throw new System.InvalidOperationException("Cannot generate a regular expression without any expressions. Please define your expressions before calling generate.");
                }

                ValidateAllExpressions();

                return _expressions.Render();
            }
        }

        /// <summary>
        /// Clears the collection of FluentRegexExpression objects used to build the regular expression.
        /// </summary>
        public void Clear()
        {
            _expressions = null;
        }

        private void ValidateAllExpressions()
        {
            Expressions.ValidateExpressions();
        }

        private Regex CreateRegex()
        {
            return new Regex(Pattern);
        }

        /// <summary>
        /// Indicates whether the regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The input string to search for matches.</param>
        /// <returns>True if the regular expression finds a match in the input string; otherwise, false.</returns>
        public bool IsMatch(string input)
        {
            return CreateRegex().IsMatch(input);
        }

        /// <summary>
        /// Searches the specified input string for all occurrences of the regular expression.
        /// </summary>
        /// <param name="input">The input string to search for matches.</param>
        /// <returns>A collection of all the matches found in the input string.</returns>
        public MatchCollection Matches(string input)
        {
            return CreateRegex().Matches(input);
        }
    }
}
