#region Using

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some methods to generate random values.
    /// </summary>
    public static class RandomValueEx
    {
        #region Fields

        /// <summary>
        ///     Random used to generate random numbers.
        /// </summary>
        private static readonly Random Rnd = new Random();

        #endregion Fields

        #region Methods

        /// <summary>
        ///     Gets random string.
        /// </summary>
        /// <returns>A random string.</returns>
        public static String GetRandomString()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        ///     Gets a list of random strings.
        /// </summary>
        /// <param name="numberOfItems">The number of items to generate.</param>
        /// <returns>A list of random strings.</returns>
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
        /// <param name="min">
        ///     The inclusive min bound.
        ///     <value>Int32.MinValue</value>
        /// </param>
        /// <param name="max">
        ///     The exclusive maximum bound. Must be greater than min.
        ///     <value>Int32.MaxValue</value>
        /// </param>
        /// <returns>A random integer value.</returns>
        public static Int32 GetRandomInt32( Int32 min = Int32.MinValue, Int32 max = Int32.MaxValue )
        {
            if ( max <= min )
                throw new ArgumentOutOfRangeException( "max", "max must be greater than min" );

            return Rnd.Next( min, max );
        }

        /// <summary>
        ///     Gets a random integer value which is in the specified range.
        /// </summary>
        /// <param name="min">
        ///     The inclusive min bound.
        ///     <value>Int16.MinValue</value>
        /// </param>
        /// <param name="max">
        ///     The exclusive maximum bound. Must be greater than min.
        ///     <value>Int16.MaxValue</value>
        /// </param>
        /// <returns>A random integer value.</returns>
        public static Int16 GetRandomInt16( Int16 min = Int16.MinValue, Int16 max = Int16.MaxValue )
        {
            if ( max <= min )
                throw new ArgumentOutOfRangeException( "max", "max must be greater than min" );

            return (Int16) Rnd.Next( min, max );
        }

        /// <summary>
        ///     Gets a random Boolean value.
        /// </summary>
        /// <returns>A random Boolean value.</returns>
        public static Boolean GetRandomBoolean()
        {
            return GetRandomInt32() % 2 == 0;
        }

        /// <summary>
        ///     Gets a random date time value.
        /// </summary>
        /// <returns>A random date time value.</returns>
        public static DateTime GetRandomDateTime( DateTime? baseDateTime = null, Int32? daysToChange = null )
        {
            var dt = baseDateTime ?? DateTime.Now;
            var addDays = GetRandomBoolean();
            var daysToAddOrSubtract = daysToChange ?? GetRandomInt32( 1, 2000 );
            dt = dt.AddDays( addDays ? daysToAddOrSubtract : ( -daysToAddOrSubtract ) );
            return dt;
        }

        /// <summary>
        ///     Gets a random value of the enumeration of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <returns>A random value of the enumeration of the specified type.</returns>
        public static T GetRandomEnum<T>() where T : struct
        {
            var values = Enum.GetValues(typeof(T)).Cast<T>();
            var enumerable = values as T[];
            return enumerable.ElementAt(Rnd.Next(0, enumerable.Count()));
        }

        /// <summary>
        ///     Gets a random long value which is in the specified range.
        /// </summary>
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
            if ( max <= min )
                throw new ArgumentOutOfRangeException( "max", "max must be greater than min" );

            var uRange = (UInt64) ( max - min );

            UInt64 ulongRand;
            do
            {
                var buffer = new Byte[8];
                Rnd.NextBytes( buffer );
                ulongRand = (UInt64) BitConverter.ToInt64( buffer, 0 );
            } while ( ulongRand > UInt64.MaxValue - ( ( UInt64.MaxValue % uRange ) + 1 ) % uRange );

            return (Int64) ( ulongRand % uRange ) + min;
        }

        #endregion Methods
    }
}