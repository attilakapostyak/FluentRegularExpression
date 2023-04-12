using FluentRegularExpression.Expressions;

namespace FluentRegularExpression.Interfaces
{
    /// <summary>
    /// Provides a fluent interface for building regular expressions.
    /// </summary>
    public interface IFluentRegexExpression
    {
        /// <summary>
        /// Adds a wildcard (.) to the expression, which matches any character except a newline.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Any();

        /// <summary>
        /// Adds a wildcard (.) to the expression, which matches any character including a newline.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression AnyExceptNewLine();

        /// <summary>
        /// Specifies that the preceding element must occur at least the specified number of times.
        /// </summary>
        /// <param name="times">The minimum number of times the preceding element should occur.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression AtLeast(int times);

        /// <summary>
        /// Adds a backspace character (\b) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Backspace();

        /// <summary>
        /// Defines a balancing group with the specified name and operation.
        /// </summary>
        /// <param name="groupName1">The name of the first named group.</param>
        /// <param name="groupName2">The name of the second named group.</param>
        /// <param name="operation">The operation to be performed on the balancing group.</param>
        /// <param name="expressionDelegate">The delegate to define the subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression BalancingGroupAs(string groupName1, string groupName2, BalancingGroupOperation operation, ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Adds a bell character (\a) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Bell();

        /// <summary>
        /// Adds a carriage return character (\r) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression CarriageReturn();

        /// <summary>
        /// Adds the specified characters to the expression.
        /// </summary>
        /// <param name="characters">The characters to be added to the expression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Characters(string characters);

        /// <summary>
        /// Adds a comment to the expression.
        /// </summary>
        /// <param name="comment">The comment text.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Comment(string comment);
 
        /// <summary>
        /// Adds a text to be matched to the expression
        /// </summary>
        /// <param name="text">The text to match.</param>
        /// <param name="escapeText">Flat to indicate if the text should be escaped. Default: true.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Match(string text, bool escapeText = true);

        /// <summary>
        /// Adds a digit character (\d) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Digit();

        /// <summary>
        /// Adds an alternative subexpression to the expression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Else(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Specifies that the expression must match the end of the input string.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression EndOfString();

        /// <summary>
        /// Specifies that the expression must match the end of the input string, or immediately before a newline at the end of the input string.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression EndOfStringOrBeforeNewLineAtEndOfString();

        /// <summary>
        /// Specifies that the expression must match the end of the input string or immediately before a newline at the end of the input string or line.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression EndOfStringOrBeforeNewLineAtEndOfStringOrLine();

        /// <summary>
        /// Adds an escape character (\e) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Escape();

        /// <summary>
        /// Specifies that the preceding element must occur exactly the specified number of times.
        /// </summary>
        /// <param name="times">The exact number of times the preceding element should occur.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Exactly(int times);

        /// <summary>
        /// Specifies that the preceding element must occur exactly once.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ExactlyOne();

        /// <summary>
        /// Adds a subexpression with the specified options.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the subexpression.</param>
        /// <param name="options">The options for the subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ExpressionWithOptions(ExpressionBuilder expressionDelegate, FluentRegexOptions options);

        /// <summary>
        /// Adds a form feed character (\f) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression FormFeed();

        /// <summary>
        /// Specifies that the preceding element must occur between the specified minimum and maximum number of times.
        /// </summary>
        /// <param name="min">The minimum number of times the preceding element should occur.</param>
        /// <param name="max">The maximum number of times the preceding element should occur.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression FromTo(int min, int max);

        /// <summary>
        /// Defines a named capturing group.
        /// </summary>
        /// <param name="groupName">The name of the capturing group.</param>
        /// <param name="expressionDelegate">The delegate to define the subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression GroupAs(string groupName, ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Adds a hexadecimal digit character (\h) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression HexadecimalDigit();

        /// <summary>
        /// Adds a horizontal tab character (\t) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression HorizontalTab();

        /// <summary>
        /// Adds a conditional subexpression to the expression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression If(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Defines an indexed capturing group.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression IndexedGroup(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Adds inline options to the expression.
        /// </summary>
        /// <param name="options">The options to apply.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression InlineOptions(FluentRegexOptions options);

        /// <summary>
        /// Adds a newline character (\n) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression NewLine();

        /// <summary>
        /// Defines a non-backtracking subexpression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression NonBacktrackingGroup(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Defines a non-capturing group.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression NonCapturingGroup(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Adds a negated digit character (\D) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression NotDigit();

        /// <summary>
        /// Adds a negated character class to the expression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the negated character class.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression NotOneOf(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Adds a negated word boundary (\B) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression NotOnWordBoundary();

        /// <summary>
        /// Adds a negated whitespace character (\S) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression NotWhiteSpace();

        /// <summary>
        /// Adds a negated word character (\W) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression NotWord();

        /// <summary>
        /// Adds an octal digit character to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression OctalDigit();

        /// <summary>
        /// Adds a Unicode character escape to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Unicode();

        /// <summary>
        /// Adds a character class to the expression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the character class.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression OneOf(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Specifies that the preceding element must occur one or more times.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression OneOrMore();

        /// <summary>
        /// Adds a word boundary (\b) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression OnWordBoundary();

        /// <summary>
        /// Adds an alternation (|) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Or();

        /// <summary>
        /// Adds a character range to the expression.
        /// </summary>
        /// <param name="fromExpressionDelegate">The delegate to define the start of the range.</param>
        /// <param name="toExpressionDelegate">The delegate to define the end of the range.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Range(ExpressionBuilder fromExpressionDelegate, ExpressionBuilder toExpressionDelegate);

        /// <summary>
        /// Adds a backreference to an indexed capturing group.
        /// </summary>
        /// <param name="indexedGroup">The index of the capturing group to reference.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ReferenceIndexedGroup(int indexedGroup);

        /// <summary>
        /// Adds a backreference to a named capturing group.
        /// </summary>
        /// <param name="groupName">The name of the capturing group to reference.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ReferenceNamedGroup(string groupName);

        /// <summary>
        /// Renders the expression as a string.
        /// </summary>
        /// <returns>The rendered expression string.</returns>
        string Render();

        /// <summary>
        /// Specifies that the expression must match the start of the input string.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression StartOfString();

        /// <summary>
        /// Specifies that the expression must match the start of the input string or line.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression StartOfStringOrLine();

        /// <summary>
        /// Adds a subexpression to the expression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Then(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Validates the context of the expression.
        /// </summary>
        /// <param name="context">The expression context.</param>
        void ValidateContext(FluentRegexExpression context);

        /// <summary>
        /// Validates the expressions in the current instance.
        /// </summary>
        void ValidateExpressions();

        /// <summary>
        /// Adds a vertical tab character (\v) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression VerticalTab();

        /// <summary>
        /// Adds a zero-width assertion to match where the previous match ended.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression WherePreviousMatchEnded();

        /// <summary>
        /// Adds a whitespace character (\s) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression WhiteSpace();

        /// <summary>
        /// Adds a word character (\w) to the expression.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression Word();

        /// <summary>
        /// Specifies that the preceding element must occur zero or more times.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ZeroOrMore();

        /// <summary>
        /// Specifies that the preceding element must occur zero or one time.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ZeroOrOne();

        /// <summary>
        /// Adds a zero-width negative lookahead assertion to the expression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the lookahead subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ZeroWidthNegativeLookahead(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Adds a zero-width negative lookbehind assertion to the expression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the lookbehind subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ZeroWidthNegativeLookbehind(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Adds a zero-width positive lookahead assertion to the expression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the lookahead subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ZeroWidthPositiveLookahead(ExpressionBuilder expressionDelegate);

        /// <summary>
        /// Adds a zero-width positive lookbehind assertion to the expression.
        /// </summary>
        /// <param name="expressionDelegate">The delegate to define the lookbehind subexpression.</param>
        /// <returns>The current expression instance.</returns>
        FluentRegexExpression ZeroWidthPositiveLookbehind(ExpressionBuilder expressionDelegate);
    }
}