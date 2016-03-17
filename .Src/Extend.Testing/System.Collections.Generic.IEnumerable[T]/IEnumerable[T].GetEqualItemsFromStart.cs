﻿#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void GetEqualItemsFromStartTest()
        {
            var source = new[] { 4, 8, 15, 16, 23, 42 };
            var other = new[] { 4, 8, 15, 99, 123, 999 };
            var result = source.GetEqualItemsFromStart(other);
            result.Should()
                  .Equal(4, 8, 15);
        }

        [Test]
        public void GetEqualItemsFromStartTest1()
        {
            var source = new[] { 4, 8, 15, 16, 23, 42 };
            var other = new Int32[] { };

            var result = source.GetEqualItemsFromStart(other);
            result.Count()
                  .Should()
                  .Be(0);
        }

        [Test]
        public void GetEqualItemsFromStartTest2()
        {
            var source = new Int32[] { };
            var other = new[] { 4, 8, 15, 16, 23, 42 };

            var result = source.GetEqualItemsFromStart(other);
            result.Count()
                  .Should()
                  .Be(0);
        }

        [Test]
        public void GetEqualItemsFromStartArgumentNullException()
        {
            IEnumerable<Int32> source = null;
            var other = Enumerable.Empty<Int32>();

            Action test = () => source.GetEqualItemsFromStart( other );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetEqualItemsFromStartTest3()
        {
            var source = new[] { 4, 8, 15, 16, 23, 42 };
            var other = new[] { -4, 8, -15, -99, -123, 999 };

            var result = source.GetEqualItemsFromStart(other, new TestComparer());
            result.Should()
                  .Equal(4, 8, 15);
        }

        private class TestComparer : IEqualityComparer<Int32>
        {
            #region Implementation of IEqualityComparer<in int>

            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
            public Boolean Equals( Int32 x, Int32 y )
            {
                return Math.Abs( x ) == Math.Abs( y );
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
            public Int32 GetHashCode( Int32 obj )
            {
                return EqualityComparer<Int32>.Default.GetHashCode(Math.Abs(obj));
            }

            #endregion
        }
    }
}