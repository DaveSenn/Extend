#region Usings

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

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
        ///     Adds the given key value pair to the dictionary, if the key does not already exist,
        ///     otherwise updates the value of the given key in the dictionary.
        /// </summary>
        /// <exception cref="ArgumentNullException">dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">key can not be null.</exception>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to work on.</param>
        /// <param name="key">The key to be added or whose value should be updated.</param>
        /// <param name="value">The value to be added or updated.</param>
        /// <returns>The new value for the key.</returns>
        [PublicAPI]
        public static TValue AddOrUpdate<TKey, TValue>( [NotNull] this IDictionary<TKey, TValue> dictionary,
                                                        [NotNull] TKey key,
                                                        TValue value )
        {
            dictionary.ThrowIfNull( nameof( dictionary ) );
            key.ThrowIfNull( nameof( key ) );

            if ( dictionary.ContainsKey( key ) )
                dictionary[key] = value;
            else
                dictionary.Add( key, value );

            return dictionary[key];
        }

        /// <summary>
        ///     Adds the given key value pair to the dictionary, if the key does not already exist,
        ///     otherwise updates the value of the given key in the dictionary.
        /// </summary>
        /// <exception cref="ArgumentNullException">dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">key can not be null.</exception>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to work on.</param>
        /// <param name="keyValuePair">The KeyValuePair to be added or updated.</param>
        /// <returns>The new value for the key.</returns>
        [PublicAPI]
        public static TValue AddOrUpdate<TKey, TValue>( [NotNull] this IDictionary<TKey, TValue> dictionary,
                                                        KeyValuePair<TKey, TValue> keyValuePair )
        {
            dictionary.ThrowIfNull( nameof( dictionary ) );
            keyValuePair.Key.ThrowIfNull( nameof( keyValuePair.Key ) );

            if ( dictionary.ContainsKey( keyValuePair.Key ) )
                dictionary[keyValuePair.Key] = keyValuePair.Value;
            else
                dictionary.Add( keyValuePair );

            return dictionary[keyValuePair.Key];
        }

        /// <summary>
        ///     Adds the given key and the value created by the value factory to the dictionary, if the key does not already exist,
        ///     otherwise updates the value of the given key in the dictionary.
        /// </summary>
        /// <exception cref="ArgumentNullException">dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">key can not be null.</exception>
        /// <exception cref="ArgumentNullException">valueFactory can not be null.</exception>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="dictionary">The Dictionary to work on.</param>
        /// <param name="key">The Key.</param>
        /// <param name="valueFactory">The factory which creates the value for the key value pair.</param>
        /// <returns>The new value for the key.</returns>
        [PublicAPI]
        public static TValue AddOrUpdate<TKey, TValue>( [NotNull] this IDictionary<TKey, TValue> dictionary,
                                                        [NotNull] TKey key,
                                                        [NotNull] Func<TValue> valueFactory )
        {
            dictionary.ThrowIfNull( nameof( dictionary ) );
            key.ThrowIfNull( nameof( key ) );
            valueFactory.ThrowIfNull( nameof( valueFactory ) );

            if ( dictionary.ContainsKey( key ) )
                dictionary[key] = valueFactory();
            else
                dictionary.Add( key, valueFactory() );

            return dictionary[key];
        }

        /// <summary>
        ///     Adds the given key and the value created by the value factory to the dictionary, if the key does not already exist,
        ///     otherwise updates the value of the given key in the dictionary.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="dictionary">The Dictionary to work on.</param>
        /// <param name="key">The Key.</param>
        /// <param name="valueFactory">The factory which creates the value for the key value pair.</param>
        /// <returns>The new value for the key.</returns>
        [PublicAPI]
        public static TValue AddOrUpdate<TKey, TValue>( [NotNull] this IDictionary<TKey, TValue> dictionary,
                                                        [NotNull] TKey key,
                                                        [NotNull] Func<TKey, TValue> valueFactory )
        {
            dictionary.ThrowIfNull( nameof( dictionary ) );
            key.ThrowIfNull( nameof( key ) );
            valueFactory.ThrowIfNull( nameof( valueFactory ) );

            if ( dictionary.ContainsKey( key ) )
                dictionary[key] = valueFactory( key );
            else
                dictionary.Add( key, valueFactory( key ) );

            return dictionary[key];
        }
    }
}