using System;

namespace FluentRegularExpression.Expressions
{
    /// <summary>
    /// Represents the type of a group expression in a fluent regular expression.
    /// </summary>
    public enum GroupType
    {
        /// <summary>An indexed group, represented by a number enclosed in parentheses.</summary>
        IndexedGroup = 0,
        /// <summary>A named group, represented by a name enclosed in angle brackets.</summary>
        NamedGroup = 1,
        /// <summary>A balancing group, used to balance nested constructs.</summary>
        BalancingGroup = 2,
        /// <summary>A non-capturing group, used for grouping without capturing.</summary>
        NonCapturingGroup = 3,
        /// <summary>A zero-width positive lookahead assertion, used to match without consuming.</summary>
        ZeroWidthPositiveLookahead = 4,
        /// <summary>A zero-width negative lookahead assertion, used to exclude matches.</summary>
        ZeroWidthNegativeLookahead = 5,
        /// <summary>A zero-width positive lookbehind assertion, used to match from behind.</summary>
        ZeroWidthPositiveLookbehind = 6,
        /// <summary>A zero-width negative lookbehind assertion, used to exclude matches from behind.</summary>
        ZeroWidthNegativeLookbehind = 7,
        /// <summary>A non-backtracking group, used to improve performance when backtracking is not needed.</summary>
        NonBacktrackingGroup = 8
    }

    /// <summary>
    /// Represents the operation of a balancing group in a fluent regular expression.
    /// </summary>
    public enum BalancingGroupOperation
    {
        /// <summary>Pushes the current capture onto the capture stack.</summary>
        Push = 0,
        /// <summary>Pops the most recent capture off the capture stack.</summary>
        Pop = 1
    }

    /// <summary>
    /// Represents a group expression in a fluent regular expression, which groups regular expressions together and captures the matched text.
    /// </summary>
    public class GroupExpression : FluentRegexExpression
    {
        internal string _groupName1;
        internal string _groupName2;
        internal GroupType _groupType = GroupType.NamedGroup;
        internal BalancingGroupOperation _balancingGroupOperation = BalancingGroupOperation.Push;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupExpression"/> class with the specified name, type, and operation.
        /// </summary>
        /// <param name="groupName">The name of the group expression.</param>
        /// <param name="groupType">The type of the group expression.</param>
        /// <param name="operation">The operation of the balancing group expression.</param>
        /// <exception cref="ArgumentException">Thrown if the group name is required for a named or balancing group expression, but is not provided, or if a group name is provided for a group expression that does not support it.</exception>
        public GroupExpression(string groupName, GroupType groupType, BalancingGroupOperation operation = BalancingGroupOperation.Pop) : this(groupName, string.Empty, groupType, operation)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupExpression"/> class with the specified name, type, and operation.
        /// </summary>
        /// <param name="groupName1">The name of the group expression.</param>
        /// <param name="groupName2">The name of the group expression.</param>
        /// <param name="groupType">The type of the group expression.</param>
        /// <param name="operation">The operation of the balancing group expression.</param>
        /// <exception cref="ArgumentException">Thrown if the group name is required for a named or balancing group expression, but is not provided, or if a group name is provided for a group expression that does not support it.</exception>
        public GroupExpression(string groupName1, string groupName2, GroupType groupType, BalancingGroupOperation operation = BalancingGroupOperation.Pop)
        {
            if (groupType == GroupType.NamedGroup  && string.IsNullOrEmpty(groupName1))
            {
                throw new ArgumentException("Named Group requires to have a group name.");
            }

            if (groupType == GroupType.BalancingGroup && (string.IsNullOrEmpty(groupName1) || string.IsNullOrEmpty(groupName2)))
            {
                throw new ArgumentException("Balancing Group requires to have both group names non empty.");
            }

            if ((groupType != GroupType.NamedGroup &&
                groupType != GroupType.BalancingGroup) && !string.IsNullOrEmpty(groupName1))
            {
                throw new ArgumentException("Only Named Group and Balancing Group can have a name.");
            }

            _groupName1 = groupName1;
            _groupName2 = groupName2;
            _groupType = groupType;
            _balancingGroupOperation = operation;
        }

        /// <summary>
        /// Renders the regular expression string for the group expression.
        /// </summary>
        /// <returns>The regular expression string for the group expression.</returns>
        public override string Render()
        {
            var prefix = string.Empty;

            switch (_groupType)
            {
                case GroupType.IndexedGroup:
                    break;

                case GroupType.NamedGroup:
                    prefix = $"?<{_groupName1}>";
                    break;

                case GroupType.BalancingGroup:
                    var popStr = _balancingGroupOperation == BalancingGroupOperation.Pop ? "-" : string.Empty;
                    prefix = $"?<{popStr}{_groupName1}-{_groupName2}>";
                    break;

                case GroupType.NonCapturingGroup:
                    prefix = $"?:";
                    break;

                case GroupType.ZeroWidthPositiveLookahead:
                    prefix = $"?=";
                    break;

                case GroupType.ZeroWidthNegativeLookahead:
                    prefix = $"?!";
                    break;

                case GroupType.ZeroWidthPositiveLookbehind:
                    prefix = $"?<=";
                    break;

                case GroupType.ZeroWidthNegativeLookbehind:
                    prefix = $"<!";
                    break;

                case GroupType.NonBacktrackingGroup:
                    prefix = $"?>";
                    break;
                default:
                    prefix = string.Empty;
                    break;
            }

            return $"({prefix}{base.Render()})";
        }
    }

}
