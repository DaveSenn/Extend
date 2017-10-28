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
        public void IntersectFirstNullTest()
        {
            List<String> first = null;
            var second = new List<String> { "a", "d", "z" };

            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => first.Intersect( second, x => x );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IntersectSecondNullTest()
        {
            var first = new List<String> { "a", "d", "z" };
            List<String> second = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => first.Intersect( second, x => x );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IntersectSelectorNullTest()
        {
            var first = new List<String> { "a", "b", "c" };
            var second = new List<String> { "a", "d", "z" };
            Func<String, String> keySelector = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => first.Intersect( second, keySelector );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IntersectTest()
        {
            var first = new List<String> { "a", "b", "c" };
            var second = new List<String> { "a", "d", "z" };

            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = first.Intersect( second, x => x )
                              .ToList();
            actual.Should()
                  .HaveCount( 1 );
            actual.Should()
                  .Contain( "a" );
        }

        [Fact]
        public void IntersectTest1()
        {
            var first = new List<TestModel>
            {
                new TestModel { Name = "a" },
                new TestModel { Name = "b" },
                new TestModel { Name = "c" },
                new TestModel { Name = "d" }
            };
            var second = new List<TestModel>
            {
                new TestModel { Name = "g" },
                new TestModel { Name = "b" },
                new TestModel { Name = "z" },
                new TestModel { Name = "d" }
            };

            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = first.Intersect( second, x => x.Name )
                              .ToList();
            actual.Should()
                  .HaveCount( 2 );

            actual.Any( x => x.Name == "b" )
                  .Should()
                  .BeTrue();
            actual.Any( x => x.Name == "d" )
                  .Should()
                  .BeTrue();
        }

        [Fact]
        public void IntersectTest2()
        {
            var first = new List<TestModel>
            {
                new TestModel { Name = "a" },
                new TestModel { Name = "aa" },
                new TestModel { Name = "aaa" },
                new TestModel { Name = "aaaa" }
            };
            var second = new List<TestModel>
            {
                new TestModel { Name = "1" },
                new TestModel { Name = "333" },
                new TestModel { Name = "4444" },
                new TestModel { Name = "1234567890" }
            };

            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = first.Intersect( second, x => x.Name, new StringLengthComparer() )
                              .ToList();
            actual.Should()
                  .HaveCount( 3 );

            actual.Any( x => x.Name == "a" )
                  .Should()
                  .BeTrue();
            actual.Any( x => x.Name == "aaa" )
                  .Should()
                  .BeTrue();
            actual.Any( x => x.Name == "aaaa" )
                  .Should()
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
            public Int32 GetHashCode( String obj ) => obj.Length.GetHashCode();

            #endregion
        }

        private class TestModel
        {
            #region Properties

            public String Name { get; set; }

            #endregion
        }

        #endregion
    }
}