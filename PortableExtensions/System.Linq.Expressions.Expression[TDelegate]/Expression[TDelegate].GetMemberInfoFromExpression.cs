#region Using

using System;
using System.Linq.Expressions;
using System.Reflection;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Expression{TDelegate}" />.
    /// </summary>
    public static class ExpressionTDelegateEx
    {
        /// <summary>
        ///     Gets the member info of from the given member expression.
        /// </summary>
        /// <remarks>
        ///     Contains logic to work with unary expressions:
        ///     E.g. to work with expressions containing a Convert node.
        /// </remarks>
        /// <exception cref="ArgumentNullException">memberExpression can not be null.</exception>
        /// <typeparam name="TDeclairingType">The type of the declaring type.</typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="memberExpression">The member expression.</param>
        /// <returns>Returns the member info from the given expression, or null if the expression is not valid.</returns>
        public static MemberInfo GetMemberInfoFromExpression<TDeclairingType, TMember>(
            this Expression<Func<TDeclairingType, TMember>> memberExpression )
        {
            memberExpression.ThrowIfNull( () => memberExpression );

            var memberSelectorExpression = memberExpression.Body.NodeType == ExpressionType.Convert
                                               ? ( memberExpression.Body as UnaryExpression ).Operand as
                                                 MemberExpression
                                               : memberExpression.Body as MemberExpression;

            return memberSelectorExpression == null ? null : memberSelectorExpression.Member;
        }
    }
}