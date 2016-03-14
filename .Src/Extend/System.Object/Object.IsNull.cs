﻿#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Gets whether the given <see cref="Object" /> is null or not.
        /// </summary>
        /// <param name="obj">The <see cref="Object" /> to check.</param>
        /// <returns>A value of true if the <see cref="Object" /> is null, otherwise false.</returns>
        public static Boolean IsNull( this Object obj ) => obj == null;
    }
}