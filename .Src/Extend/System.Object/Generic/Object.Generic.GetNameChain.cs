#region Usings

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Gets the name, including a full name chain, of the member to which the given expression points.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <exception cref="NotSupportedException">
        ///     The given expression is of a not supported type (supported are:
        ///     <see cref="ExpressionType.MemberAccess" />, <see cref="ExpressionType.Convert" />).
        /// </exception>
        /// <typeparam name="TObject">The type of the member to which the expression points.</typeparam>
        /// <param name="obj">The object to call the method on.</param>
        /// <typeparam name="TMember">The type of the member to which the expression points.</typeparam>
        /// <param name="expression">An expression pointing to the member to get the name of.</param>
        /// <returns>Returns the name, including a full name chain, of the member to which the given expression points.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetNameChain<TObject, TMember>( [CanBeNull] this TObject obj, [NotNull] Expression<Func<TObject, TMember>> expression )
        {
            expression.ThrowIfNull( nameof( expression ) );

            return GetNameChain( expression.Body );
        }

        /// <summary>
        ///     Gets the name, including a full name chain, of the member to which the given expression points.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <exception cref="NotSupportedException">
        ///     The given expression is of a not supported type (supported are:
        ///     <see cref="ExpressionType.MemberAccess" />, <see cref="ExpressionType.Convert" />).
        /// </exception>
        /// <typeparam name="TObject">The type of the member to which the expression points.</typeparam>
        /// <param name="obj">The object to call the method on.</param>
        /// <typeparam name="TMember">The type of the member to which the expression points.</typeparam>
        /// <param name="expression">An expression pointing to the member to get the name of.</param>
        /// <returns>Returns the name, including a full name chain, of the member to which the given expression points.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetNameChain<TObject, TMember>( [CanBeNull] this TObject obj, [NotNull] Expression<Func<TMember>> expression )
        {
            expression.ThrowIfNull( nameof( expression ) );

            return GetNameChain( expression.Body );
        }

        /// <summary>
        ///     Gets the name, including a full name chain, of the member to which the given expression points.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <exception cref="NotSupportedException">
        ///     The given expression is of a not supported type (supported are:
        ///     <see cref="ExpressionType.MemberAccess" />, <see cref="ExpressionType.Convert" />).
        /// </exception>
        /// <param name="expression">The expression pointing to the member.</param>
        /// <returns>Returns the name, including a full name chain, of the member to which the given expression points.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        private static String GetNameChain( [NotNull] this Expression expression )
        {
            expression.ThrowIfNull( nameof( expression ) );

            MemberExpression memberExpression;
            if ( !expression.TryGetMemberExpression( out memberExpression ) )
                throw new ArgumentException( "The given expression is not valid." );

            var memberNames = new Stack<String>();
            do
            {
                //Check if the 'inner' expression as a constant expression, if so, break the loop
                if ( memberExpression.Expression.NodeType == ExpressionType.Constant )
                {
                    if ( memberNames.NotAny() )
                        memberNames.Push( memberExpression.Member.Name );
                    break;
                }

                memberNames.Push( memberExpression.Member.Name );

                //Check if expression is pointing to lambda parameter e.g. x (x => x)
                if ( memberExpression.Expression.NodeType == ExpressionType.Parameter )
                    break;
            } while ( memberExpression.Expression.TryGetMemberExpression( out memberExpression ) );

            return memberNames.StringJoin( "." );
        }
    }
}