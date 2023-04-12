using System;

namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Backreference type
    /// </summary>
    public enum BackreferenceType
    {
        /// <summary>
        /// Backreference for indexed groups
        /// </summary>
        IndexedGroup = 0,
        /// <summary>
        /// Backreference for named groups
        /// </summary>
        NamedGroup = 1
    }

    /// <summary>
    /// Backreference expression
    /// </summary>
    public class BackreferenceExpression : FluentRegexExpression
    {
        private string _reference = string.Empty;
        private BackreferenceType _backreferenceType;

        /// <summary>
        /// Backreference ctor
        /// </summary>
        /// <param name="reference">Index or the name of a group</param>
        /// <param name="backreferenceType">IndexedGroup or NamedGroup</param>
        /// <exception cref="ArgumentException">Thrown when reference is empty</exception>
        public BackreferenceExpression(string reference, BackreferenceType backreferenceType)
        {
            if (string.IsNullOrEmpty(reference))
            {
                throw new ArgumentException("Reference cannot be empty.");
            }

            _reference = reference;
            _backreferenceType = backreferenceType;
        }

        /// <summary>
        /// Render the backreference expression
        /// </summary>
        /// <returns></returns>
        public override string Render()
        {
            switch (_backreferenceType)
            {
                case BackreferenceType.IndexedGroup:
                    return $"\\{_reference}";
                case BackreferenceType.NamedGroup:
                    return $"\\k<{_reference}>";
                default:
                    return $"";
            }
        }
    }
}
