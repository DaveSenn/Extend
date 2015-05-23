#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IDictionary{TKey,TValue}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IDictionaryEx
    {
        /// <summary>
        ///     Adds the given key value pair to the dictionary, if it not already contains the key.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The key can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">the type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to which the item should get added.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>True if the item was added to the dictionary, otherwise false.</returns>
        public static Boolean AddIfNotContainsKey<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                                 TKey key,
                                                                 TValue value )
        {
            dictionary.ThrowIfNull( () => dictionary );
            key.ThrowIfNull( () => key );

            if ( dictionary.ContainsKey( key ) )
                return false;

            dictionary.Add( key, value );
            return true;
        }

        /// <summary>
        ///     Adds the given key value pair to the dictionary, if it not already contains the key.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The key value pair can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">the type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to which the item should get added.</param>
        /// <param name="keyValuePair">The KeyValuePair to add.</param>
        /// <returns>True if the item was added to the dictionary, otherwise false.</returns>
        public static Boolean AddIfNotContainsKey<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                                 KeyValuePair<TKey, TValue> keyValuePair )
        {
            dictionary.ThrowIfNull( () => dictionary );
            keyValuePair.Key.ThrowIfNull( () => keyValuePair.Key );

            if ( dictionary.ContainsKey( keyValuePair.Key ) )
                return false;

            dictionary.Add( keyValuePair );
            return true;
        }

        /// <summary>
        ///     Adds the key and value returned by the given factory to the dictionary, if it not already contains the key.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The key can not be null.</exception>
        /// <exception cref="ArgumentNullException">The factory can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">the type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to which the item should get added.</param>
        /// <param name="key">The key.</param>
        /// <param name="valueFactory">The factory which creates the value for the key value pair.</param>
        /// <returns>True if the item was added to the dictionary, otherwise false.</returns>
        public static Boolean AddIfNotContainsKey<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                                 TKey key,
                                                                 Func<TValue> valueFactory )
        {
            dictionary.ThrowIfNull( () => dictionary );
            key.ThrowIfNull( () => key );
            valueFactory.ThrowIfNull( () => valueFactory );

            if ( dictionary.ContainsKey( key ) )
                return false;

            dictionary.Add( key, valueFactory() );
            return true;
        }

        /// <summary>
        ///     Adds the key and value returned by the given factory to the dictionary, if it not already contains the key.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The key can not be null.</exception>
        /// <exception cref="ArgumentNullException">The factory can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">the type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to which the item should get added.</param>
        /// <param name="key">The key.</param>
        /// <param name="valueFactory">The factory which creates the value for the key value pair.</param>
        /// <returns>True if the item was added to the dictionary, otherwise false.</returns>
        public static Boolean AddIfNotContainsKey<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                                 TKey key,
                                                                 Func<TKey, TValue> valueFactory )
        {
            dictionary.ThrowIfNull( () => dictionary );
            key.ThrowIfNull( () => key );
            valueFactory.ThrowIfNull( () => valueFactory );

            if ( dictionary.ContainsKey( key ) )
                return false;

            dictionary.Add( key, valueFactory( key ) );
            return true;
        }
    }
}