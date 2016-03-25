#region Usings

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
        public void ExceptTest()
        {
            var first = new List<Int32> { 1, 3, 5, 7 };
            var second = new List<Int32> { 2, 4, 6, 8 };

            var actual = first.Except( second, x => x )
                              .ToList();
            actual.Should()
                  .HaveCount( 4 );
            actual.Should()
                  .ContainInOrder( new List<Int32> { 1, 3, 5, 7 } );
        }

        [Test]
        public void ExceptTest1()
        {
            var first = new List<Int32> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var second = new List<Int32> { 2, 4, 6, 8 };

            var actual = first.Except( second, x => x )
                              .ToList();
            actual.Should()
                  .HaveCount( 4 );
            actual.Should()
                  .ContainInOrder( new List<Int32> { 1, 3, 5, 7 } );
        }

        [Test]
        public void ExceptTest2()
        {
            var first = new List<String> { "a", "bb", "ccc" };
            var second = new List<String> { "22", "4444", "55555" };

            var actual = first.Except( second, x => x, new StringLengthComparer() )
                              .ToList();
            actual.Should()
                  .HaveCount( 2 );
            actual.Should()
                  .Contain( "a", "ccc" );
        }

        [Test]
        public void ExceptTest3()
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

            var actual = first.Except( second, x => x.Name )
                              .ToList();
            actual.Should()
                  .HaveCount( 2 );

            actual.Any( x => x.Name == "a" )
                  .Should()
                  .BeTrue();
            actual.Any( x => x.Name == "c" )
                  .Should()
                  .BeTrue();
        }

        [Test]
        public void ExpectFirstNullTest()
        {
            List<Int32> first = null;
            var second = new List<Int32> { 2, 4, 6, 8 };

            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => first.Except( second, x => x );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExpectSecondNullTest()
        {
            var first = new List<Int32> { 2, 4, 6, 8 };
            List<Int32> second = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => first.Except( second, x => x );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExpectSelectorNullTest()
        {
            var first = new List<Int32> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var second = new List<Int32> { 2, 4, 6, 8 };
            Func<Int32, Int32> keySelector = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => first.Except( second, keySelector );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}