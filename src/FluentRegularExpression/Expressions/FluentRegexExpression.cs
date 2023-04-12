using FluentRegularExpression.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentRegularExpression.Expressions
{

    /// <summary>
    /// Represents a method that builds a <see cref="FluentRegexExpression"/> and returns it.
    /// </summary>
    /// <param name="expression">The current <see cref="FluentRegexExpression"/> that is being built upon</param>
    /// <returns>A <see cref="FluentRegexExpression"/> that represents the new expression</returns>
    public delegate FluentRegexExpression ExpressionBuilder(FluentRegexExpression expression);

    /// <inheritdoc/>
    public class FluentRegexExpression : IFluentRegexExpression
    {
        internal FluentRegexExpression _parentExpression = null;
        internal List<FluentRegexExpression> _subExpressions = new List<FluentRegexExpression>();
        internal FluentRegexExpression _closingExpression = null;


        // Control Character
        private const string AnyExceptNewLineCharacter = @".";
        private const string BellCharacter = @"\a";
        private const string BackspaceCharacter = @"\b";
        private const string HorizontalTabCharacter = @"\t";
        private const string VerticalTabCharacter = @"\v";
        private const string CarriageReturnCharacter = @"\r";
        private const string FormFeedCharacter = @"\f";
        private const string NewLineCharacter = @"\n";
        private const string EscapeCharacter = @"\e";


        // Character Classes
        private const string ControlCharacter = @"\c";
        private const string WhiteSpaceCharacter = @"\s";
        private const string NotWhiteSpaceCharacter = @"\S";
        private const string DigitCharacter = @"\d";
        private const string NotDigitCharacter = @"\D";
        private const string WordCharacter = @"\w";
        private const string NotWordCharacter = @"\W";
        private const string HexadecimalDigitCharacter = @"\x";
        private const string OctalDigitCharacter = @"\O";
        private const string UnicodeCharacter = @"\u";

        // Anchors
        private const string StartOfStringOrlineCharacter = @"^";
        private const string StartOfStringCharacter = @"\A";
        private const string EndOfStringCharacter = @"$";
        private const string EndOfStringOrBeforeNewLineAtEndOfStringCharacter = @"\Z";
        private const string EndOfStringOrBeforeNewLineAtEndOfStringOrLineCharacter = @"$";
        private const string WherePreviousMatchEndedCharacter = @"\G";
        private const string OnWordBoundaryCharacter = @"\b";
        private const string NotOnWordBoundaryCharacter = @"\B";


        /// <inheritdoc/>
        public virtual void ValidateExpressions()
        {
            foreach (var expression in _subExpressions)
            {
                expression.ValidateContext(this);
            }
        }

        /// <inheritdoc/>
        public virtual void ValidateContext(FluentRegexExpression context)
        {
            foreach (var expression in _subExpressions)
            {
                expression.ValidateContext(this);
            }
        }

        internal void AddExpression(FluentRegexExpression expression)
        {
            FluentRegexExpression currentExpression = this;

            if (currentExpression._subExpressions.Count > 0 && expression._closingExpression != null)
            {
                var lastExpression = currentExpression._subExpressions.LastOrDefault();

                if (lastExpression.GetType().Equals(expression._closingExpression.GetType()))
                {
                    currentExpression._subExpressions.Remove(lastExpression);
                }
            }

            expression._parentExpression = currentExpression;
            currentExpression._subExpressions.Add(expression);

            if (expression._closingExpression != null)
            {
                currentExpression._subExpressions.Add(expression._closingExpression);
                expression._closingExpression._parentExpression = currentExpression;
            }
        }

        /// <inheritdoc/>
        public FluentRegexExpression Any()
        {
            AddExpression(new StringExpression(AnyExceptNewLineCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression AnyExceptNewLine()
        {
            return Any();
        }

        /// <inheritdoc/>
        public FluentRegexExpression HorizontalTab()
        {
            AddExpression(new StringExpression(HorizontalTabCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression VerticalTab()
        {
            AddExpression(new StringExpression(VerticalTabCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Bell()
        {
            AddExpression(new StringExpression(BellCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Backspace()
        {
            AddExpression(new StringExpression(BackspaceCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression CarriageReturn()
        {
            AddExpression(new StringExpression(CarriageReturnCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression FormFeed()
        {
            AddExpression(new StringExpression(FormFeedCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression NewLine()
        {
            AddExpression(new StringExpression(NewLineCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Escape()
        {
            AddExpression(new StringExpression(EscapeCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression WhiteSpace()
        {
            AddExpression(new StringExpression(WhiteSpaceCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression NotWhiteSpace()
        {
            AddExpression(new StringExpression(NotWhiteSpaceCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Digit()
        {
            AddExpression(new StringExpression(DigitCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression NotDigit()
        {
            AddExpression(new StringExpression(NotDigitCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Word()
        {
            AddExpression(new StringExpression(WordCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression NotWord()
        {
            AddExpression(new StringExpression(NotWordCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression HexadecimalDigit()
        {
            AddExpression(new StringExpression(HexadecimalDigitCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression OctalDigit()
        {
            AddExpression(new StringExpression(OctalDigitCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Unicode()
        {
            AddExpression(new StringExpression(UnicodeCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression StartOfStringOrLine()
        {
            AddExpression(new StringExpression(StartOfStringOrlineCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression StartOfString()
        {
            AddExpression(new StringExpression(StartOfStringCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression EndOfString()
        {
            AddExpression(new StringExpression(EndOfStringCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression EndOfStringOrBeforeNewLineAtEndOfString()
        {
            AddExpression(new StringExpression(EndOfStringOrBeforeNewLineAtEndOfStringCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression EndOfStringOrBeforeNewLineAtEndOfStringOrLine()
        {
            AddExpression(new StringExpression(EndOfStringOrBeforeNewLineAtEndOfStringOrLineCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression WherePreviousMatchEnded()
        {
            AddExpression(new StringExpression(WherePreviousMatchEndedCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression OnWordBoundary()
        {
            AddExpression(new StringExpression(OnWordBoundaryCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression NotOnWordBoundary()
        {
            AddExpression(new StringExpression(NotOnWordBoundaryCharacter));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Comment(string comment)
        {
            var commentExpression = new CommentExpression(comment);
            AddExpression(commentExpression);

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Match(string text, bool escapeText = true)
        {
            AddExpression(new MatchExpression(text, escapeText));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression OneOrMore()
        {
            AddExpression(new StringExpression("+"));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression ZeroOrOne()
        {
            AddExpression(new StringExpression("?"));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression ZeroOrMore()
        {
            AddExpression(new StringExpression("*"));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression ExactlyOne()
        {
            AddExpression(new StringExpression("{1}"));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Exactly(int times)
        {
            AddExpression(new StringExpression($"{{{times}}}"));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression AtLeast(int times)
        {
            AddExpression(new StringExpression($"{{{times},}}"));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression FromTo(int min, int max)
        {
            AddExpression(new StringExpression($"{{{min},{max}}}"));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression ReferenceIndexedGroup(int indexedGroup)
        {
            AddExpression(new BackreferenceExpression(indexedGroup.ToString(), BackreferenceType.IndexedGroup));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression ReferenceNamedGroup(string groupName)
        {
            AddExpression(new BackreferenceExpression(groupName, BackreferenceType.NamedGroup));

            return this;
        }

        private FluentRegexExpression NewExpressionWithSubExpressions<T>(ExpressionBuilder expressionDelegate, object[] constructorParameters) where T : FluentRegexExpression
        {
            var newExpression = (T)Activator.CreateInstance(typeof(T), constructorParameters);

            AddExpression(newExpression);

            FluentRegexExpression expression = new FluentRegexExpression();
            var subExpression = expressionDelegate(expression);
            newExpression.AddExpression(subExpression);

            return newExpression;
        }

        /// <inheritdoc/>
        public FluentRegexExpression IndexedGroup(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<GroupExpression>(expressionDelegate, new object[] { string.Empty, GroupType.IndexedGroup, BalancingGroupOperation.Push });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression GroupAs(string groupName, ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<GroupExpression>(expressionDelegate, new object[] { groupName, GroupType.NamedGroup, BalancingGroupOperation.Push });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression BalancingGroupAs(string groupName1, string groupName2, BalancingGroupOperation operation, ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<GroupExpression>(expressionDelegate, new object[] { groupName1, groupName2, GroupType.BalancingGroup, operation });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression NonCapturingGroup(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<GroupExpression>(expressionDelegate, new object[] { string.Empty, GroupType.NonCapturingGroup, BalancingGroupOperation.Push });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression ZeroWidthPositiveLookahead(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<GroupExpression>(expressionDelegate, new object[] { string.Empty, GroupType.ZeroWidthPositiveLookahead, BalancingGroupOperation.Push });

            return this;
        }
        
        /// <inheritdoc/>
        public FluentRegexExpression ZeroWidthNegativeLookahead(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<GroupExpression>(expressionDelegate, new object[] { string.Empty, GroupType.ZeroWidthNegativeLookahead, BalancingGroupOperation.Push });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression ZeroWidthPositiveLookbehind(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<GroupExpression>(expressionDelegate, new object[] { string.Empty, GroupType.ZeroWidthNegativeLookbehind, BalancingGroupOperation.Push });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression ZeroWidthNegativeLookbehind(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<GroupExpression>(expressionDelegate, new object[] { string.Empty, GroupType.ZeroWidthNegativeLookbehind, BalancingGroupOperation.Push });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression NonBacktrackingGroup(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<GroupExpression>(expressionDelegate, new object[] { string.Empty, GroupType.NonBacktrackingGroup, BalancingGroupOperation.Push });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression If(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<IfExpression>(expressionDelegate, new object[] {  });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Then(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<ThenExpression>(expressionDelegate, new object[] {  });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Else(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<ElseExpression>(expressionDelegate, new object[] {  });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Or()
        {
            AddExpression(new OrExpression());

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression OneOf(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<OneOfExpression>(expressionDelegate, new object[] { false });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression NotOneOf(ExpressionBuilder expressionDelegate)
        {
            NewExpressionWithSubExpressions<OneOfExpression>(expressionDelegate, new object[] { true });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Characters(string characters)
        {
            AddExpression(new MatchExpression(characters, true));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression Range(ExpressionBuilder fromExpressionDelegate, ExpressionBuilder toExpressionDelegate)
        {
            NewExpressionWithSubExpressions<RangeFromExpression>(fromExpressionDelegate, new object[] {  });

            NewExpressionWithSubExpressions<RangeToExpression>(toExpressionDelegate, new object[] {  });

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression InlineOptions(FluentRegexOptions options)
        {
            AddExpression(new OptionsExpression(false, options));

            return this;
        }

        /// <inheritdoc/>
        public FluentRegexExpression ExpressionWithOptions(ExpressionBuilder expressionDelegate, FluentRegexOptions options)
        {
            NewExpressionWithSubExpressions<OptionsExpression>(expressionDelegate, new object[] { true, options });

            return this;
        }

        /// <inheritdoc/>
        public virtual string Render()
        {
            var builder = new StringBuilder();
            foreach (var item in Enumerable.Reverse(_subExpressions))
            {
                builder.Insert(0, item.Render());
            }

            return builder.ToString();
        }
    }
}
