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
        /// <param name="start">
        ///     The start of the integer range, default is
        ///     <value>Int32.MinValue</value>
        /// </param>
        /// <param name="end">
        ///     The end of the integer range, default is
        ///     <value>Int32.MaxValue</value>
        /// </param>
        /// <returns>A random integer value.</returns>
        public static Int32 GetRandomInt32( Int32? start = null, Int32? end = null )
        {
            return Rnd.Next( start ?? Int32.MinValue, end ?? Int32.MaxValue );
        }

        /// <summary>
        ///     Gets a random integer value which is in the specified range.
        /// </summary>
        /// <param name="start">
        ///     The start of the integer range, default is
        ///     <value>Int16.MinValue</value>
        /// </param>
        /// <param name="end">
        ///     The end of the integer range, default is
        ///     <value>Int16.MaxValue</value>
        /// </param>
        /// <returns>A random integer value.</returns>
        public static Int16 GetRandomInt16( Int16? start = null, Int16? end = null )
        {
            return (Int16) Rnd.Next( start ?? Int16.MinValue, end ?? Int16.MaxValue );
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
            var values = Enum.GetValues( typeof ( T ) ).Cast<T>();
            return values.ElementAt( Rnd.Next( 0, values.Count() ) );
        }

        #endregion Methods
    }
}