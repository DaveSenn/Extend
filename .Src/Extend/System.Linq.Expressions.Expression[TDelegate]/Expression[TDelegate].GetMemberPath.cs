#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Expression{TDelegate}" />.
    /// </summary>
    public static partial class ExpressionTDelegateEx
    {
        /// <summary>
        ///     Gets a dotted path of property names representing the property expression. E.g. Parent.Child.Sibling.Name.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <param name="expression">The expression pointing to the member.</param>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetMemberPath<TDeclaringType, TMember>( [NotNull] this Expression<Func<TDeclaringType, TMember>> expression )
        {
            expression.ThrowIfNull( nameof(expression) );

            var result = new List<String>();
            Expression node = expression;

            while ( node != null )
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch ( node.NodeType )
                {
                    case ExpressionType.Lambda:
                        node = ( (LambdaExpression) node ).Body;
                        break;

                    case ExpressionType.Convert:
                        var unaryExpression = (UnaryExpression) node;
                        node = unaryExpression.Operand;
                        break;

                    case ExpressionType.MemberAccess:
                        var memberExpression = (MemberExpression) node;
                        node = memberExpression.Expression;
                        result.Add( memberExpression.Member.Name );
                        break;

                    case ExpressionType.ArrayIndex:
                        var binaryExpression = (BinaryExpression) node;
                        var constantExpression = (ConstantExpression) binaryExpression.Right;
                        node = binaryExpression.Left;
                        result.Add( "[" + constantExpression.Value + "]" );
                        break;

                    case ExpressionType.Parameter:
                        node = null;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException( nameof(expression.Body),
                                                               expression.Body,
                                                               $"Expression '{expression.Body}' cannot be used to select a member." );
                }

            return result
                .AsEnumerable()
                .Reverse()
                .StringJoin( "." )
                .Replace( ".[", "[" );
        }
    }
}