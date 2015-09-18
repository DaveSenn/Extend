#region Usings

using System;
using System.Linq.Expressions;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Expression" />.
    /// </summary>
    public static class ExpressionEx
    {
        /// <summary>
        ///     Tries to get a <see cref="MemberExpression" /> from the given expression.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <exception cref="NotSupportedException">
        ///     The given expression is of a not supported type (supported are:
        ///     <see cref="ExpressionType.MemberAccess" />, <see cref="ExpressionType.Convert" />).
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     Expression is not supported (expression is <see cref="ConstantExpression" /> or
        ///     <see cref="LambdaExpression" /> with an invalid body).
        /// </exception>
        /// <param name="expression">The expression.</param>
        /// <param name="memberExpression">The extracted <see cref="MemberExpression" />.</param>
        /// <returns>Returns true if a <see cref="MemberExpression" /> could be extracted; otherwise, false.</returns>
        public static Boolean TryGetMemberExpression( this Expression expression, out MemberExpression memberExpression )
        {
            while ( true )
            {
                expression.ThrowIfNull(nameof(expression));

                switch ( expression.NodeType )
                {
                    case ExpressionType.MemberAccess:
                        memberExpression = expression as MemberExpression;
                        return true;

                    case ExpressionType.Convert:
                        var operand = ( expression as UnaryExpression ).Operand;
                        //Check if operand is member expression
                        if ( operand is MemberExpression )
                        {
                            memberExpression = operand as MemberExpression;
                            return true;
                        }

                        //Operand type is not supported
                        throw new NotSupportedException(
                            "Expressions (operand of convert) of type {0} are not supported".F( operand.NodeType ) );

                    case ExpressionType.Constant:
                        throw new NotSupportedException(
                            "TryGetMemberExpression does not support expressions of type ConstantExpression. Consider using none-constant member." );

                    //I cant find any case when expression can be LambdaExpression
                    case ExpressionType.Lambda:
                        var body = ( expression as LambdaExpression ).Body;
                        if ( body != null )
                        {
                            expression = body;
                            continue;
                        }
                        throw new NotSupportedException( "The given lambda expression has no valid body." );

                    default:
                        throw new NotSupportedException( "Expressions of type {0} are not supported".F( expression.NodeType ) );
                }
            }
        }
    }
}