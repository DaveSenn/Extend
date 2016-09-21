#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some methods to generate random values.
    /// </summary>
    public static class RandomValueEx
    {
        #region Constants

        /// <summary>
        ///     Array of characters used to "generate" random characters.
        /// </summary>
        private static readonly Char[] Chars = "qwertzuiopasdfghjklyxcvbnmQWERTZUIOPASDFGHJKLYXCVBNMöäüéàè.;:()/&%ç*?`!".ToCharArray();

        /// <summary>
        ///     The object used to generate random values.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        ///     The object used to synchronize accesses to <see cref="Rnd" /> across different threads.
        /// </summary>
        private static readonly Object SyncLock = new Object();

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the random object used to create the random values.
        /// </summary>
        private static Random Rnd
        {
            get
            {
                lock ( SyncLock )
                    return Random;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets random string.
        /// </summary>
        /// <returns>A random string.</returns>
        [PublicAPI]
        [Pure]
        [NotNull]
        public static String GetRandomString()
            => Guid.NewGuid()
                   .ToString();

        /// <summary>
        ///     Gets random char.
        /// </summary>
        /// <returns>A random char.</returns>
        [PublicAPI]
        [Pure]
        public static Char GetRandomChar()
            => Chars[GetRandomInt32( 0, Chars.Length )];

        /// <summary>
        ///     Gets a list of random strings.
        /// </summary>
        /// <param name="numberOfItems">The number of items to generate.</param>
        /// <returns>A list of random strings.</returns>
        [PublicAPI]
        [Pure]
        [NotNull]
        public static List<String> GetRandomStrings( Int32? numberOfItems = null )
        {
            var list = new List<String>();
            numberOfItems = numberOfItems ?? GetRandomInt32( 1, 1000 );
            for ( var i = 0; i < numberOfItems; i++ )
                list.Add( GetRandomString() );
            return list;
        }

        /// <summary>
        ///     Gets a random integer value which is in the specified range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">min is greater than max</exception>
        /// <param name="min">
        ///     The inclusive min bound.
        ///     <value>Int32.MinValue</value>
        /// </param>
        /// <param name="max">
        ///     The exclusive maximum bound. Must be greater than min.
        ///     <value>Int32.MaxValue</value>
        /// </param>
        /// <returns>A random integer value.</returns>
        [PublicAPI]
        [Pure]
        public static Int32 GetRandomInt32( Int32 min = Int32.MinValue, Int32 max = Int32.MaxValue )
        {
            if ( max < min )
                throw new ArgumentOutOfRangeException( nameof( max ), "max must be greater than min" );

            return Rnd.Next( min, max );
        }

        /// <summary>
        ///     Gets a random integer value which is in the specified range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">min is greater than max</exception>
        /// <param name="min">
        ///     The inclusive min bound.
        ///     <value>Int16.MinValue</value>
        /// </param>
        /// <param name="max">
        ///     The exclusive maximum bound. Must be greater than min.
        ///     <value>Int16.MaxValue</value>
        /// </param>
        /// <returns>A random integer value.</returns>
        [PublicAPI]
        [Pure]
        public static Int16 GetRandomInt16( Int16 min = Int16.MinValue, Int16 max = Int16.MaxValue )
        {
            if ( max < min )
                throw new ArgumentOutOfRangeException( nameof( max ), max, $"{nameof( max )} must be greater than {nameof( min )}" );

            return (Int16) Rnd.Next( min, max );
        }

        /// <summary>
        ///     Gets a random Boolean value.
        /// </summary>
        /// <returns>A random Boolean value.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean GetRandomBoolean()
            => GetRandomInt32() % 2 == 0;

        /// <summary>
        ///     Gets a random date-time value between the given minimum and maximum.
        /// </summary>
        /// <remarks>
        ///     Default value for minimum is: 01.01.1753.
        ///     Default value for maximum is: 31.12.9999.
        /// </remarks>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Returns the generated random date-time value.</returns>
        [PublicAPI]
        [Pure]
        public static DateTime GetRandomDateTime( DateTime? min = null, DateTime? max = null )
        {
            min = min ?? new DateTime( 1753, 01, 01 );
            max = max ?? new DateTime( 9999, 12, 31 );

            var range = max.Value - min.Value;
            var randomUpperBound = (Int32) range.TotalSeconds;
            if ( randomUpperBound <= 0 )
                randomUpperBound = Rnd.Next( 1, Int32.MaxValue );

            var randTimeSpan = TimeSpan.FromSeconds( (Int64) ( range.TotalSeconds - Rnd.Next( 0, randomUpperBound ) ) );

            return min.Value.Add( randTimeSpan );
        }

        /// <summary>
        ///     Gets a random value of the enumeration of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <returns>A random value of the enumeration of the specified type.</returns>
        [PublicAPI]
        [Pure]
        public static T GetRandomEnum<T>() where T : struct
        {
            var values = Enum.GetValues( typeof(T) )
                             .Cast<T>();

            var enumerable = values as T[];
            return enumerable?.ElementAt( Rnd.Next( 0, enumerable.Length ) ) ?? default(T);
        }

        /// <summary>
        ///     Gets a random long value which is in the specified range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">min is greater than max</exception>
        /// <param name="min">
        ///     The inclusive min bound.
        ///     <value>Int64.MinValue</value>
        /// </param>
        /// <param name="max">
        ///     The exclusive maximum bound. Must be greater than min.
        ///     <value>Int64.MaxValue</value>
        /// </param>
        /// <returns>A random long value.</returns>
        public static Int64 GetRandomInt64( Int64 min = Int64.MinValue, Int64 max = Int64.MaxValue )
        {
            if ( max < min )
                throw new ArgumentOutOfRangeException( nameof( max ), "max must be greater than min" );

            var uRange = (UInt64) ( max - min );

            UInt64 ulongRand;
            do
            {
                var buffer = new Byte[8];
                Rnd.NextBytes( buffer );
                ulongRand = (UInt64) BitConverter.ToInt64( buffer, 0 );
            } while ( ulongRand > UInt64.MaxValue - ( UInt64.MaxValue % uRange + 1 ) % uRange );

            return (Int64) ( ulongRand % uRange ) + min;
        }

        /// <summary>
        ///     Gets a random <see cref="Byte" /> value.
        /// </summary>
        /// <returns>A random <see cref="Byte" /> value.</returns>
        [PublicAPI]
        [Pure]
        public static Byte GetRandomByte()
            => (Byte) GetRandomInt32();

        /// <summary>
        ///     Gets a random <see cref="Double" /> value which is in the specified range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">min is greater than max</exception>
        /// <param name="min">
        ///     The inclusive min bound.
        ///     <value>Double.MinValue</value>
        /// </param>
        /// <param name="max">
        ///     The exclusive maximum bound. Must be greater than min.
        ///     <value>Double.MaxValue</value>
        /// </param>
        /// <returns>A random <see cref="Double" /> value.</returns>
        [PublicAPI]
        [Pure]
        public static Double GetRandomDouble( Double min = Double.MinValue, Double max = Double.MaxValue )
        {
            if ( max < min )
                throw new ArgumentOutOfRangeException( nameof( max ), max, $"{nameof( max )} must be greater than {nameof( min )}" );

            return min + Rnd.NextDouble() * ( max - min );
        }

        #endregion Methods
    }
}