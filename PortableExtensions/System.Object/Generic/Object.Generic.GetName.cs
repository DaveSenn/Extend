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
        ///     Gets the name of the member of the given <see cref="Expression{T}" />.
        /// </summary>
        /// <exception cref="ArgumentNullException">The field expression can not be null.</exception>
        /// <typeparam name="TObject">The type of the source object.</typeparam>
        /// <typeparam name="TField">The type of the member of the given <see cref="Expression{T}" />.</typeparam>
        /// <param name="obj">The source object.</param>
        /// <param name="fieldName">The member of the given <see cref="Expression{T}" /></param>
        /// <returns>The name of the the given member as <see cref="String" />.</returns>
        public static String GetName<TObject, TField>( this TObject obj, Expression<Func<TObject, TField>> fieldName )
        {
            fieldName.ThrowIfNull( () => fieldName );
            return
                ( fieldName.Body as MemberExpression ?? ( (UnaryExpression) fieldName.Body ).Operand as MemberExpression )
                    .Member.Name;
        }
    }
}