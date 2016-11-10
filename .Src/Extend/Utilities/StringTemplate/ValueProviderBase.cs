using System;

namespace Extend
{
    /// <summary>
    ///     Base class for value providers.
    /// </summary>
    internal abstract class ValueProviderBase : IValueProvider
    {
        #region Constants

        /// <summary>
        ///     Character used to separate property name and format.
        /// </summary>
        private const Char FormatSeperator = ':';

        #endregion

        #region Implementation of IValueProvider

        /// <summary>
        ///     Gets the value represented by the given expression.
        /// </summary>
        /// <param name="expression">The name of a property optionally combined with a string format compatible expression.</param>
        /// <returns>Returns the value represented by the given expression.</returns>
        public abstract String GetValue( String expression );

        #endregion

        /// <summary>
        ///     Extracts the format information from the given expression.
        /// </summary>
        /// <param name="expression">The name of a property optionally combined with a string format compatible expression.</param>
        /// <returns>Returns the format information.</returns>
        protected static FormatInformation ParsExpression( String expression )
        {
            var colonIndex = expression.IndexOf( FormatSeperator );

            if ( colonIndex <= 0 )
                return new FormatInformation { ValueName = expression };

            return new FormatInformation
            {
                Format = "{0:" + expression.Substring( colonIndex + 1 ) + "}",
                ValueName = expression.Substring( 0, colonIndex )
            };
        }
    }
}