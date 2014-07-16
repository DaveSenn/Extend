#region Using

using System;
using System.Collections.Generic;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IDictionary{TKey,TValue}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IDictionaryEx
    {
        /// <summary>
        ///     Adds the given key value pair to the dictionary if the key does not already exist.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The key can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to act on.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value to be added, if the key does not already exist.</param>
        /// <returns>
        ///     Returns the value for the key.
        ///     This will be either the existing value for the key if the key is already in the
        ///     dictionary, or the new value if the key was not in the dictionary.
        /// </returns>
        public static TValue GetOrAdd<TKey, TValue>( this IDictionary<TKey, TValue> dictionary, TKey key, TValue value )
        {
            dictionary.ThrowIfNull( () => dictionary );
            key.ThrowIfNull( () => key );

            if ( !dictionary.ContainsKey( key ) )
                dictionary.Add( key, value );

            return dictionary[key];
        }

        /// <summary>
        ///     Adds the given key value pair to the dictionary if the key does not already exist.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The key can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to act on.</param>
        /// <param name="keyValuePair">The key value pair to add or get.</param>
        /// <returns>
        ///     Returns the value for the key.
        ///     This will be either the existing value for the key if the key is already in the
        ///     dictionary, or the new value if the key was not in the dictionary.
        /// </returns>
        public static TValue GetOrAdd<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                     KeyValuePair<TKey, TValue> keyValuePair )
        {
            dictionary.ThrowIfNull( () => dictionary );
            keyValuePair.Key.ThrowIfNull( () => keyValuePair.Key );

            if ( !dictionary.ContainsKey( keyValuePair.Key ) )
                dictionary.Add( keyValuePair );

            return keyValuePair.Value;
        }

        /// <summary>
        ///     Adds the key value pair to the dictionary, by using the specified function, if the key does not already exist.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The factory can not be null.</exception>
        /// <exception cref="ArgumentNullException">The key can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to act on.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">TThe function used to generate a value for the key.</param>
        /// <returns>
        ///     Returns the value for the key. This will be either the existing value for the key if the key is already in the
        ///     dictionary, or the new value for the key as returned by value factory if the key was not in the dictionary.
        /// </returns>
        public static TValue GetOrAdd<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                     TKey key,
                                                     Func<TValue> valueFactory )
        {
            dictionary.ThrowIfNull( () => dictionary );
            key.ThrowIfNull( () => key );
            valueFactory.ThrowIfNull( () => valueFactory );

            if ( !dictionary.ContainsKey( key ) )
                dictionary.Add( key, valueFactory() );

            return dictionary[key];
        }

        /// <summary>
        ///     Adds the key value pair to the dictionary, by using the specified function, if the key does not already exist.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The factory can not be null.</exception>
        /// <exception cref="ArgumentNullException">The key can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to act on.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">TThe function used to generate a value for the key.</param>
        /// <returns>
        ///     Returns the value for the key. This will be either the existing value for the key if the key is already in the
        ///     dictionary, or the new value for the key as returned by value factory if the key was not in the dictionary.
        /// </returns>
        public static TValue GetOrAdd<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                     TKey key,
                                                     Func<TKey, TValue> valueFactory )
        {
            dictionary.ThrowIfNull( () => dictionary );
            key.ThrowIfNull( () => key );
            valueFactory.ThrowIfNull( () => valueFactory );

            if ( !dictionary.ContainsKey( key ) )
                dictionary.Add( key, valueFactory( key ) );

            return dictionary[key];
        }
    }
}