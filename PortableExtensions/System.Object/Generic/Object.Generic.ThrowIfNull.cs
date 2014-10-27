#region Usings

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
        ///     Throws a <see cref="ArgumentNullException" /> exception if <paramref name="obj" /> is null.
        /// </summary>
        /// <remarks>
        ///     If <paramref name="errorMessage" /> is null, this method will use the following default message:
        ///     "{object name} can not be null."
        /// </remarks>
        /// <typeparam name="TObject">The type <paramref name="obj" />.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="expression">An expression pointing to <paramref name="obj" />.</param>
        /// <param name="errorMessage">
        ///     The text used as exception message if <paramref name="obj" /> is
        ///     <value>null</value>
        ///     .
        /// </param>
        public static void ThrowIfNull<TObject> ( this TObject obj,
                                                  Expression<Func<TObject>> expression,
                                                  String errorMessage = null )
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if ( obj != null )
                return;

            var parameterName = obj.GetName( expression );
            throw new ArgumentNullException( parameterName,
                                             errorMessage ?? "{0} can not be null.".F( parameterName ) );
        }
    }
}