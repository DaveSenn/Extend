#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Exception thrown when the creation of an instance fails.
    /// </summary>
    public class CreateInstanceException : Exception
    {
        #region Properties

        /// <summary>
        ///     Gets information about the factories.
        /// </summary>
        /// <value>Information about the factories.</value>
        public String FactoryInformation { get; }

        /// <summary>
        ///     Gets information about the selection.
        /// </summary>
        /// <value>Information about the selection rules.</value>
        public String SelectionRuleRuleInformation { get; }

        /// <summary>
        ///     Gets information about the member.
        /// </summary>
        /// <value>Information about the member.</value>
        public IMemberInformation MemberInformation { get; }

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateInstanceException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CreateInstanceException( String message )
            : base( message )
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateInstanceException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference  if no inner exception is specified.
        /// </param>
        public CreateInstanceException( String message, Exception innerException )
            : base( message, innerException )
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateInstanceException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference  if no inner exception is specified.
        /// </param>
        /// <param name="factoryInformation">Information about the factories.</param>
        /// <param name="selectionRuleInformation">Information about selection rules.</param>
        /// <param name="memberInformation">The current member.</param>
        public CreateInstanceException( String message, Exception innerException, String factoryInformation, String selectionRuleInformation, IMemberInformation memberInformation )
            : base( message, innerException )
        {
            FactoryInformation = factoryInformation;
            SelectionRuleRuleInformation = selectionRuleInformation;
            MemberInformation = memberInformation;
        }

        #endregion
    }
}