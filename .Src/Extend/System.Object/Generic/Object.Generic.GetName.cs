#region Usings

using System;
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
        ///     Gets the name of the member to which the given expression points.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <exception cref="NotSupportedException">
        ///     The given expression is of a not supported type (supported are:
        ///     <see cref="ExpressionType.MemberAccess" />, <see cref="ExpressionType.Convert" />).
        /// </exception>
        /// <typeparam name="TObject">The type of the source object.</typeparam>
        /// <typeparam name="TMember">The type of the member to which the expression points.</typeparam>
        /// <param name="obj">The source object.</param>
        /// <param name="expression">An expression pointing to the member to get the name of.</param>
        /// <returns>Returns the name of the member to which the given expression points.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetName<TObject, TMember>( [CanBeNull] this TObject obj, [NotNull] Expression<Func<TObject, TMember>> expression )
        {
            expression.ThrowIfNull( nameof(expression) );

            return GetName( expression.Body );
        }

        /// <summary>
        ///     Gets the name of the member to which the given expression points.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <exception cref="NotSupportedException">
        ///     The given expression is of a not supported type (supported are:
        ///     <see cref="ExpressionType.MemberAccess" />, <see cref="ExpressionType.Convert" />).
        /// </exception>
        /// <typeparam name="TObject">The type of the member to which the expression points.</typeparam>
        /// <typeparam name="TMember">The type of the member to which the expression points.</typeparam>
        /// <param name="obj">The object to call the method on.</param>
        /// <param name="expression">An expression pointing to the member to get the name of.</param>
        /// <returns>Returns the name of the member to which the given expression points.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetName<TObject, TMember>( [CanBeNull] [NoEnumeration] this TObject obj, [NotNull] Expression<Func<TMember>> expression )
        {
            expression.ThrowIfNull( nameof(expression) );

            return GetName( expression.Body );
        }

        /// <summary>
        ///     Gets the name of the member to which the given expression points.
        /// </summary>
        /// <param name="expression">The expression pointing to the member.</param>
        /// <exception cref="NotSupportedException">
        ///     expression is not supported (expression is <see cref="ConstantExpression" /> or
        ///     <see cref="LambdaExpression" /> with an invalid body).
        /// </exception>
        /// <returns>Returns the name of the member to which the given expression points.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        private static String GetName( [NotNull] Expression expression )
        {
            if ( !expression.TryGetMemberExpression( out var memberExpression ) )
                throw new ArgumentException( "The given expression was not valid." );

            return memberExpression.Member.Name;
        }
    }
}