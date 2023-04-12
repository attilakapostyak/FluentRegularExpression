namespace FluentRegularExpression
{
    internal class FluentRegexOptionExpressions
    {
        // Inline Options
        public static string CaseInsensitive = @"i";
        public static string DisableCaseInsensitive = @"-i";
        public static string MultilineMode = @"m";
        public static string DisableMultilineMode = @"-m";
        public static string SinglelineMode = @"s";
        public static string DisableSinglelineMode = @"-s";
        public static string ExplicitCapture = @"n";
        public static string DisableExplicitCapture = @"-n";
        public static string IgnoreWhiteSpace = @"x";
        public static string DisableIgnoreWhiteSpace = @"-x";
    }

    /// <summary>
    /// Provides enumerated values to enable or disable regular expression options
    /// </summary>
    public enum FluentRegexOptions
    {
        /// <summary>
        /// Enable case-insensitive matching.
        /// </summary>
        CaseInsensitive = 1,
        /// <summary>
        /// Disable case-insensitive matching.
        /// </summary>
        DisableCaseInsensitive = 2,
        /// <summary>
        /// Enable multi-line matching.
        /// </summary>
        MultilineMode = 4,
        /// <summary>
        /// Disable multi-line matching.
        /// </summary>
        DisableMultilineMode = 8,
        /// <summary>
        /// Enable single-line matching.
        /// </summary>
        SinglelineMode = 16,
        /// <summary>
        /// Disable single-line matching.
        /// </summary>
        DisableSinglelineMode = 32,
        /// <summary>
        /// Enable that only valid captures are explicitly named or numbered groups of the form (?&lt;name>...).
        /// </summary>
        ExplicitCapture = 64,
        /// <summary>
        /// Disable that only valid captures are explicitly named or numbered groups of the form (?&lt;name>...).
        /// </summary>
        DisableExplicitCapture = 128,
        /// <summary>
        /// Enable elimination of unescaped white space from the pattern 
        /// </summary>
        IgnoreWhiteSpace = 256,
        /// <summary>
        /// Disable elimination of unescaped white space from the pattern 
        /// </summary>
        DisableIgnoreWhiteSpace = 512,
    }
}