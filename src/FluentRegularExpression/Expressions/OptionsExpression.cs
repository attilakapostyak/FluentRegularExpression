using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents a regular expression options expression.
    /// </summary>
    public class OptionsExpression : FluentRegexExpression
    {
        internal readonly bool _asExpression;
        internal FluentRegexOptions _options;
        internal Dictionary<FluentRegexOptions, string> optionsExpressionsDict;

        /// <summary>
        /// Initializes a new instance of the OptionsExpression class.
        /// </summary>
        /// <param name="asExpression">Indicates whether the options expression should be used as an expression.</param>
        /// <param name="options">The options to include in the expression.</param>
        public OptionsExpression(bool asExpression, FluentRegexOptions options)
        {
            _asExpression = asExpression;
            _options = options;

            optionsExpressionsDict = new Dictionary<FluentRegexOptions, string> {
                { FluentRegexOptions.CaseInsensitive, FluentRegexOptionExpressions.CaseInsensitive },
                { FluentRegexOptions.DisableCaseInsensitive, FluentRegexOptionExpressions.DisableCaseInsensitive },
                { FluentRegexOptions.MultilineMode, FluentRegexOptionExpressions.MultilineMode },
                { FluentRegexOptions.DisableMultilineMode, FluentRegexOptionExpressions.DisableMultilineMode },
                { FluentRegexOptions.SinglelineMode, FluentRegexOptionExpressions.SinglelineMode },
                { FluentRegexOptions.DisableSinglelineMode, FluentRegexOptionExpressions.DisableSinglelineMode },
                { FluentRegexOptions.ExplicitCapture, FluentRegexOptionExpressions.ExplicitCapture },
                { FluentRegexOptions.DisableExplicitCapture, FluentRegexOptionExpressions.DisableExplicitCapture },
                { FluentRegexOptions.IgnoreWhiteSpace, FluentRegexOptionExpressions.IgnoreWhiteSpace },
                { FluentRegexOptions.DisableIgnoreWhiteSpace, FluentRegexOptionExpressions.DisableIgnoreWhiteSpace }
            };
        }

        /// <summary>
        /// Builds the options expressions as a string.
        /// </summary>
        /// <returns>The options expressions as a string.</returns>
        public string BuildExpressionsAsString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (FluentRegexOptions option in Enum.GetValues(typeof(FluentRegexOptions)))
            {
                if (((_options & option) == option) && optionsExpressionsDict.TryGetValue(option, out string value))
                {
                    sb.Append(value);
                }
            }
            return sb.ToString();
        }

        private string RenderOnlyOptions()
        {
            return $"(?{BuildExpressionsAsString()})";
        }

        private string RenderAsExpression()
        {
            return $"(?{BuildExpressionsAsString()}:{base.Render()})";
        }

        /// <summary>
        /// Renders the regular expression string for the options expression.
        /// </summary>
        /// <returns>The regular expression string for the options expression.</returns>
        public override string Render()
        {
            if (_asExpression)
            {
                return RenderAsExpression();
            }
            else
            {
                return RenderOnlyOptions();
            }
        }

    }
}
