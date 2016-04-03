#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class IEqualityComparerExTest
    {
        private class StringLengthComparer : IEqualityComparer<String>
        {
            #region Implementation of IEqualityComparer<in string>

            /// <summary>
            ///     Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            ///     true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object of type <paramref name="T" /> to compare.</param>
            /// <param name="y">The second object of type <paramref name="T" /> to compare.</param>
            public Boolean Equals( String x, String y ) => x.Length == y.Length;

            /// <summary>
            ///     Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            ///     A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object" /> for which a hash code is to be returned.</param>
            /// <exception cref="T:System.ArgumentNullException">
            ///     The type of <paramref name="obj" /> is a reference type and
            ///     <paramref name="obj" /> is null.
            /// </exception>
            public Int32 GetHashCode( String obj ) => obj.GetHashCode();

            #endregion
        }

        [Test]
        public void BySelectorNullTest()
        {
            Func<String, String> keySelector = null;
            Action test = () => IEqualityComparerEx.By( keySelector, new StringLengthComparer() );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ByTest()
        {
            var actual = IEqualityComparerEx.By<String, Int32>( x => x.Length, null );
            var equals = actual.Equals( "test", "1234" );
            equals.Should()
                  .BeTrue();
        }

        [Test]
        public void ByTest1()
        {
            var actual = IEqualityComparerEx.By<String, String>( x => x, new StringLengthComparer() );
            var equals = actual.Equals( "test", "1234" );
            equals.Should()
                  .BeTrue();
        }
    }
}