#region Using

using System;
using System.Linq.Expressions;

#endregion Using

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Throws a <see cref="ArgumentNullException" /> exception if the given property is null.
        /// </summary>
        /// <remarks>
        ///     If the
        ///     <paramref name="errorMessage" />is null, this method will use the following default message: "{ParameterName} can
        ///     not be null." (Use this overload for checking if a property of an object is null.)
        /// </remarks>
        /// <typeparam name="TObject">The type of the object which owns to property.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="obj">The object which contains the parameter or any object.</param>
        /// <param name="property">The parameter to check.</param>
        /// <param name="propertyName">An expression which has the property as body.</param>
        /// <param name="errorMessage">The text used as exception message if the parameter is null.</param>
        public static void ThrowIfNull<TObject, TProperty>(this TObject obj,
                                                            TProperty property,
                                                            Expression<Func<TObject, TProperty>> propertyName,
                                                            String errorMessage = null)
        {
            if (property == null)
            {
                var parameterName = GetName(obj, propertyName);

                throw new ArgumentNullException(parameterName,
                                                 errorMessage ?? String.Format("{0} can not be null.", parameterName));
            }
        }

        /// <summary>
        ///     Throws a <see cref="ArgumentNullException" /> exception if the given parameter is null.
        /// </summary>
        /// <remarks>
        ///     If the
        ///     <paramref name="errorMessage" />is null, this method will use the following default message: "{ParameterName} can
        ///     not be null." (Use this methods for checking if a parameter is null.)
        /// </remarks>
        /// <typeparam name="TObject">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="propertyName">An expression which has the parameter as body.</param>
        /// <param name="errorMessage">The text used as exception message if the parameter is null.</param>
        public static void ThrowIfNull<TObject>(this TObject parameter,
                                                 Expression<Func<TObject>> propertyName,
                                                 String errorMessage = null)
        {
            if (parameter == null)
            {
                var parameterName =
                    (propertyName.Body as MemberExpression
                      ?? ((UnaryExpression)propertyName.Body).Operand as MemberExpression).Member.Name;

                throw new ArgumentNullException(parameterName,
                                                 errorMessage ?? String.Format("{0} can not be null.", parameterName));
            }
        }
    }
}