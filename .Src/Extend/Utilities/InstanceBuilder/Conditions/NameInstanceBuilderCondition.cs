#region Usings

using System;

#if NET40
using System.Globalization;

#endif

#endregion

namespace Extend
{
    /// <summary>
    ///     Name based condition.
    /// </summary>
    public class NameInstanceBuilderCondition : INameInstanceBuilderCondition
    {
        #region Ctor

        /// <summary>
        ///     Initializes a new instnace of the <see cref="NameInstanceBuilderCondition" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">Value can not ben null.</exception>
        /// <param name="value">The Value to search for.</param>
        /// <param name="compareOption">The compare option.</param>
        /// <param name="ignoreCase">A Value indicating whether casing should be ignored or not.</param>
        public NameInstanceBuilderCondition( String value, StringCompareOption compareOption = StringCompareOption.Equals, Boolean ignoreCase = false )
        {
            value.ThrowIfNull( nameof( value ) );

            Value = value;
            CompareOption = compareOption;
            IgnoreCase = ignoreCase;
        }

        #endregion

        #region Implementation of INameInstanceBuilderCondition

        /// <summary>
        ///     Determines wheter the given arguments matches the condition or not.
        /// </summary>
        /// <param name="arguments">The arguments to check.</param>
        /// <returns>Returns a Value of true if the arguments matches the condition; oterwise, false.</returns>
        public Boolean Matches( IInstanceValueArguments arguments )
        {
            arguments.ThrowIfNull( nameof( arguments ) );

            switch ( CompareOption )
            {
                case StringCompareOption.Equals:
                    return arguments.PropertyName.Equals( Value, IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal );
                case StringCompareOption.StartsWith:
#if PORTABLE45
                    return arguments.PropertyName.StartsWith( Value, IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal );
#elif NET40
                    return arguments.PropertyName.StartsWith( Value, IgnoreCase, CultureInfo.InvariantCulture );
#endif
                case StringCompareOption.EndsWith:
#if PORTABLE45
                    return arguments.PropertyName.EndsWith( Value, IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal );
#elif NET40
                    return arguments.PropertyName.EndsWith( Value, IgnoreCase, CultureInfo.InvariantCulture );
#endif
                case StringCompareOption.Contains:
                    return arguments.PropertyName.Contains( Value, IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal );
                default:
                    throw new ArgumentOutOfRangeException( nameof( CompareOption ), CompareOption, $"Compare type '{CompareOption}' is not supported." );
            }
        }

        /// <summary>
        ///     Gets the Value to search for.
        /// </summary>
        /// <Value>The Value to search for.</Value>
        public String Value { get; }

        /// <summary>
        ///     Gets the compare option.
        /// </summary>
        /// <Value>The compare option.</Value>
        public StringCompareOption CompareOption { get; }

        /// <summary>
        ///     Gets a Value indicating whether casing should be ignored or not.
        /// </summary>
        /// <Value>A Value indicating whether casing should be ignored or not.</Value>
        public Boolean IgnoreCase { get; }

        #endregion
    }
}