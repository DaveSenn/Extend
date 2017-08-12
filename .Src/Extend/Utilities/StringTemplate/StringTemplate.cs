#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Extend.Internal;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing logic for string templates.
    /// </summary>
    public static class StringTemplate
    {
        #region Constants

        /// <summary>
        ///     Char representing a close bracket.
        /// </summary>
        private const Char BracketClose = '}';

        /// <summary>
        ///     Char representing a open bracket.
        /// </summary>
        private const Char BracketOpen = '{';

        #endregion

        #region Nested Types

        /// <summary>
        ///     Enumeration of all string format states.
        /// </summary>
        private enum StringFormatState
        {
            /// <summary>
            ///     Outside of an expression, normal string literal.
            /// </summary>
            OutsideExpression = 0,

            /// <summary>
            ///     Inside of an expression.
            /// </summary>
            InsideExpression = 1,

            /// <summary>
            ///     Last character was a open bracket.
            /// </summary>
            OnOpenBracket = 2,

            /// <summary>
            ///     Last character was a close bracket.
            /// </summary>
            OnCloseBracket = 3,

            /// <summary>
            ///     End of formate.
            /// </summary>
            End = 4
        }

        #endregion

        #region Private Members

        /// <summary>
        ///     Builds an error message for a format containing a unescaped close bracket.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="reader">The reader used to consume the format.</param>
        /// <returns>Returns the error message.</returns>
        private static String BuildErrorMessageCloseNotEscaped( String format, TextReader reader )
        {
            try
            {
                // Read the string to the end
                var unprocessed = reader.ReadToEnd();
                var errorMessage = $"Invalid format, expression is not closed; before: '{unprocessed}'";
                if ( unprocessed.Length <= 0 )
                    return errorMessage;

                // Find the start of the unprocessed part
                var unprocessedStartIndex = format.IndexOf( unprocessed, StringComparison.Ordinal );
                if ( unprocessedStartIndex <= 0 )
                    return errorMessage;

                // Search for the start of the faulty expression (not guaranteed to find the correct position) 
                var faultyExpressionStart = format.Substring( 0, unprocessedStartIndex )
                                                  .LastIndexOf( "{", StringComparison.Ordinal );
                if ( faultyExpressionStart <= 0 )
                    return errorMessage;

                // Try to read the faulty expression from the format
                var length = unprocessedStartIndex - faultyExpressionStart;
                if ( length <= 0 || format.Length - faultyExpressionStart - length <= 0 )
                    return errorMessage;

                var before = format.Substring( faultyExpressionStart, length );
                return $"Invalid format, expression is not closed; near '{before}', before '{unprocessed}'.";
            }
            catch
            {
                return $"Invalid format, expression is not closed: '${format}'.";
            }
        }

        /// <summary>
        ///     Replaces the format item in a specified <see cref="String" /> with the values from the given value provider.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format string can not be null.</exception>
        /// <exception cref="FormatException">Format is invalid, or value provider failed to provide a value.</exception>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="valueProvider">A value provider.</param>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the <see cref="String"></see>  representation
        ///     of the corresponding objects from the value provider.
        /// </returns>
        private static String FormatWithValueProvider( this String format, IValueProvider valueProvider )
        {
            format.ThrowIfNull( nameof(format) );

            var result = new StringBuilder( format.Length * 2 );
            using ( var reader = new StringReader( format ) )
            {
                var expression = new StringBuilder();
                Int32 currentChar;
                var currentState = StringFormatState.OutsideExpression;

                do
                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch ( currentState )
                    {
                        case StringFormatState.OutsideExpression:
                            // We are not in a expression => normal string literal
                            currentChar = reader.Read();
                            switch ( currentChar )
                            {
                                case -1:
                                    // End of string reached
                                    currentState = StringFormatState.End;
                                    break;
                                case BracketOpen:
                                    // Start of new expression (or an escaped open bracket)
                                    currentState = StringFormatState.OnOpenBracket;
                                    break;
                                case BracketClose:
                                    // Close bracket => must be escaped with the next character
                                    currentState = StringFormatState.OnCloseBracket;
                                    break;
                                default:
                                    // Normal string content
                                    result.Append( (Char) currentChar );
                                    break;
                            }
                            break;
                        case StringFormatState.OnOpenBracket:
                            // Last character was an open bracket (only one bracket; yet)
                            currentChar = reader.Read();
                            switch ( currentChar )
                            {
                                case -1:
                                    // End of string => unescaped bracket without a valid expression
                                    throw new FormatException( $"Invalid format, format ends with an unescaped open bracket; '{format}'." );
                                case BracketOpen:
                                    // Must be an escaped open bracket
                                    result.Append( BracketOpen );
                                    currentState = StringFormatState.OutsideExpression;
                                    break;
                                default:
                                    // Part of expression
                                    expression.Append( (Char) currentChar );
                                    currentState = StringFormatState.InsideExpression;
                                    break;
                            }
                            break;
                        case StringFormatState.InsideExpression:
                            // We are inside of an expression
                            currentChar = reader.Read();
                            switch ( currentChar )
                            {
                                case -1:
                                    // End of string => unclosed expression
                                    throw new FormatException( $"Invalid format, format ends with an unclosed expression; '{format}'." );
                                case BracketClose:
                                    // End of expression
                                    result.Append( valueProvider.GetValue( expression.ToString() ) );
                                    expression.Length = 0;
                                    currentState = StringFormatState.OutsideExpression;
                                    break;
                                default:
                                    // Part of expression
                                    expression.Append( (Char) currentChar );
                                    break;
                            }
                            break;
                        case StringFormatState.OnCloseBracket:
                            // Last character was a close bracket
                            currentChar = reader.Read();
                            switch ( currentChar )
                            {
                                case BracketClose:
                                    // Must be an escaped close bracket
                                    result.Append( BracketClose );
                                    currentState = StringFormatState.OutsideExpression;
                                    break;
                                default:
                                    throw new FormatException( BuildErrorMessageCloseNotEscaped( format, reader ) );
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException( nameof(currentState), currentState, $"Invalid state: '{format}'." );
                    } while ( currentState != StringFormatState.End );
            }

            return result.ToString();
        }

        #endregion

        #region Public Members

        /// <summary>
        ///     Replaces the format item in a specified <see cref="String" /> with the values from the given object.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format string can not be null.</exception>
        /// <exception cref="FormatException">Format is invalid, or failed to get value from object.</exception>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="source">To object from which the values should be get.</param>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the <see cref="String"></see>  representation
        ///     of the corresponding objects from the object.
        /// </returns>
        public static String FormatWithObject( this String format, Object source )
            => format.FormatWithValueProvider( new ObjectValueProvider( source ) );

        /// <summary>
        ///     Replaces the format item in a specified <see cref="String" /> with the values from the given dictionary.
        /// </summary>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="values">A dictionary containing all the required values.</param>
        /// <exception cref="FormatException">Format is invalid, or failed to get value from dictionary.</exception>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the <see cref="String"></see>  representation
        ///     of the corresponding objects from the dictionary.
        /// </returns>
        public static String FormatWithValues( this String format, IDictionary<String, Object> values )
            => format.FormatWithValueProvider( new LookuptValueProvider( values ) );

        #endregion
    }
}