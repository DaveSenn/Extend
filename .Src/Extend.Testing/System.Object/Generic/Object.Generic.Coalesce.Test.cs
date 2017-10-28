#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void CoalesceTest()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = ObjectEx.Coalesce( null, null, null, null, expected, "Test2" );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void CoalesceTest1()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = ObjectEx.Coalesce( null, null, null, null, expected, "Test2" );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void CoalesceTest2()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = expected.Coalesce( null, null, null, expected, "Test2" );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void CoalesceTest3()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = expected.Coalesce( "Test2" );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void CoalesceTest4()
        {
            var expected = RandomValueEx.GetRandomString();
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = expected.Coalesce( value );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void CoalesceTest5()
        {
            var expected = RandomValueEx.GetRandomString();
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.Coalesce( expected );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void CoalesceTestInvalidOperationCheck()
        {
            Object[] array = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => ObjectEx.Coalesce( null, array, null );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void CoalesceTestNullCheck()
        {
            String s = null;
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => s.Coalesce( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}