#region Using

using System;
using System.Linq.Expressions;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Gets the name of the member to which the given expression points.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///     expression is not supported (expression is <see cref="ConstantExpression" /> or
        ///     <see cref="LambdaExpression" /> with an invalid body).
        /// </exception>
        /// <typeparam name="TObject">The type of the source object.</typeparam>
        /// <typeparam name="TMember">The type of the member to which the expression points.</typeparam>
        /// <param name="obj">The source object.</param>
        /// <param name="expression">An expression pointin to the member to get the name of.</param>
        /// <returns>Returns the name of the member to which the given expression points.</returns>
        public static String GetName<TObject, TMember>(this TObject obj, Expression<Func<TObject, TMember>> expression)
        {
            expression.ThrowIfNull(() => expression);

            return GetName(expression.Body);
        }

        /// <summary>
        ///     Gets the name of the member to which the given expression points.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///     expression is not supported (expression is <see cref="ConstantExpression" /> or
        ///     <see cref="LambdaExpression" /> with an invalid body).
        /// </exception>
        /// <typeparam name="TObject">The type of the member to which the expression points.</typeparam>
        /// <param name="obj">The object to call the method on.</param>
        /// <param name="expression">An expression pointin to the member to get the name of.</param>
        /// <returns>Returns the name of the member to which the given expression points.</returns>
        public static String GetName<TObject>(this TObject obj, Expression<Func<TObject>> expression)
        {
            expression.ThrowIfNull(() => expression);

            return GetName(expression.Body);
        }

        /// <summary>
        ///     Gets the name of the member to which the given expression points.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///     expression is not supported (expression is <see cref="ConstantExpression" /> or
        ///     <see cref="LambdaExpression" /> with an invalid body).
        /// </exception>
        /// <returns>Returns the name of the member to which the given expression points.</returns>
        private static String GetName(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (expression as MemberExpression).Member.Name;

                case ExpressionType.Convert:
                    return ((expression as UnaryExpression).Operand as MemberExpression).Member.Name;

                case ExpressionType.Constant:
                    throw new NotSupportedException(
                        "GetName does not support expressions of type ConstantExpression. Consider using none-constant member.");

                //I cant find any case when expression can be LambdaExpression
                //case ExpressionType.Lambda:
                //    var body = (expression as LambdaExpression).Body;
                //    if (body != null)
                //        return GetName(body);
                //    throw new NotSupportedException("Given lamdbda expression has no valid body.");

                default:
                    throw new NotSupportedException(
                        "Expressions of type {0} are not supported".F(expression.NodeType));
            }
        }
    }
}