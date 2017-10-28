#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void GetEqualItemsFromStartArgumentNullException()
        {
            Action test = () =>
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var result = IEnumerableTEx.GetEqualItemsFromStart( null, Enumerable.Empty<Int32>() );
                result.Should()
                      .BeNull( "Should have thrown exception" );
            };
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetEqualItemsFromStartArgumentNullException1()
        {
            Action test = () =>
            {
                var result = Enumerable.Empty<Int32>()
                                       // ReSharper disable once AssignNullToNotNullAttribute
                                       .GetEqualItemsFromStart( null );
                result.Should()
                      .BeNull( "Should have thrown exception" );
            };
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetEqualItemsFromStartTest()
        {
            var source = new[] { 4, 8, 15, 16, 23, 42 };
            var other = new[] { 4, 8, 15, 99, 123, 999 };
            var result = source.GetEqualItemsFromStart( other );
            result.Should()
                  .Equal( 4, 8, 15 );
        }

        [Fact]
        public void GetEqualItemsFromStartTest1()
        {
            var source = new[] { 4, 8, 15, 16, 23, 42 };
            var other = new Int32[] { };

            var result = source.GetEqualItemsFromStart( other );
            result.Count()
                  .Should()
                  .Be( 0 );
        }

        [Fact]
        public void GetEqualItemsFromStartTest2()
        {
            var source = new Int32[] { };
            var other = new[] { 4, 8, 15, 16, 23, 42 };

            var result = source.GetEqualItemsFromStart( other );
            result.Count()
                  .Should()
                  .Be( 0 );
        }

        [Fact]
        public void GetEqualItemsFromStartTest3()
        {
            var source = new[] { 4, 8, 15, 16, 23, 42 };
            var other = new[] { -4, 8, -15, -99, -123, 999 };

            var result = source.GetEqualItemsFromStart( other, new TestComparer() );
            result.Should()
                  .Equal( 4, 8, 15 );
        }

        #region Nested Types

        private class TestComparer : IEqualityComparer<Int32>
        {
            #region Implementation of IEqualityComparer<in int>

            /// <summary>
            ///     Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            ///     true if the specified objects are equal; otherwise, false.
            /// </returns>
            public Boolean Equals( Int32 x, Int32 y ) => Math.Abs( x ) == Math.Abs( y );

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
            public Int32 GetHashCode( Int32 obj ) => EqualityComparer<Int32>.Default.GetHashCode( Math.Abs( obj ) );

            #endregion
        }

        #endregion
    }
}