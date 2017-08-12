#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Factory used to create values for instance members.
    /// </summary>
    public class ExpressionInstanceFactory : InstanceFactoryBase
    {
        #region Fields

        /// <summary>
        ///     The factory.
        /// </summary>
        private readonly Func<IMemberInformation, Object> _factory;

        #endregion

        #region Ctor

        /// <summary>
        ///     Creates a new instance of the <see cref="ExpressionInstanceFactory" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">factory can not be null.</exception>
        /// <param name="factory">The factory.</param>
        /// <param name="name">The name of the factory.</param>
        /// <param name="description">The description of the factory.</param>
        public ExpressionInstanceFactory( [NotNull] Func<IMemberInformation, Object> factory, String name = null, String description = null )
            : base( name, description )
        {
            factory.ThrowIfNull( nameof(factory) );

            _factory = factory;
        }

        #endregion

        #region Overrides of InstanceFactoryBase

        /// <summary>
        ///     Gets the value for the given <see cref="IMemberInformation" />.
        /// </summary>
        /// <param name="memberInformation">Information about the member to create a value for.</param>
        /// <returns>Returns the created value.</returns>
        public override Object CreateValue( IMemberInformation memberInformation )
            => _factory( memberInformation );

        #endregion
    }
}