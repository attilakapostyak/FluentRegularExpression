using System.Text.RegularExpressions;

namespace FluentRegularExpression.Interfaces
{
    /// <summary>
    /// Defines the interface for a fluent regular expression builder, which allows you to easily create and manipulate regular expressions.
    /// </summary>
    public interface IFluentRegexBuilder
    {
        /// <summary>
        /// Removes all expressions from the builder's collection, effectively resetting it.
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines whether the regular expression matches the entire input string.
        /// </summary>
        /// <param name="input">The input string to match.</param>
        /// <returns><c>true</c> if the regular expression matches the entire input string; otherwise, <c>false</c>.</returns>
        bool IsMatch(string input);

        /// <summary>
        /// Searches the input string for all occurrences of the regular expression and returns them as a collection of <see cref="Match"/> objects.
        /// </summary>
        /// <param name="input">The input string to search for matches.</param>
        /// <returns>A collection of <see cref="Match"/> objects that contain the results of the search.</returns>
        MatchCollection Matches(string input);
    }
}