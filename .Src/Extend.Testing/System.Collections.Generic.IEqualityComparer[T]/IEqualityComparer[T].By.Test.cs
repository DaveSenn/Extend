#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public class IEqualityComparerExTest
    {
        [Fact]
        public void BySelectorNullTest()
        {
            Func<String, String> keySelector = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IEqualityComparerEx.By( keySelector, new StringLengthComparer() );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ByTest()
        {
            // ReSharper disable once RedundantArgumentDefaultValue
            var actual = IEqualityComparerEx.By<String, Int32>( x => x.Length, null );
            var equals = actual.Equals( "test", "1234" );
            equals.Should()
                  .BeTrue();
        }

        [Fact]
        public void ByTest1()
        {
            var actual = IEqualityComparerEx.By<String, String>( x => x, new StringLengthComparer() );
            var equals = actual.Equals( "test", "1234" );
            equals.Should()
                  .BeTrue();
        }

        #region Nested Types

        private class StringLengthComparer : IEqualityComparer<String>
        {
            #region Implementation of IEqualityComparer<in string>

            /// <summary>
            ///     Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            ///     true if the specified objects are equal; otherwise, false.
            /// </returns>
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

        #endregion
    }
}