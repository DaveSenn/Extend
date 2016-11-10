using System;

namespace Extend
{
    /// <summary>
    ///     Class representing a value provider for string formating.
    /// </summary>
    internal interface IValueProvider
    {
        /// <summary>
        ///     Gets the value represented by the given expression.
        /// </summary>
        /// <param name="expression">The name of a property optionally combined with a string format compatible expression.</param>
        /// <returns>Returns the value represented by the given expression.</returns>
        String GetValue( String expression );
    }
}