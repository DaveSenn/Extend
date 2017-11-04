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
        public void CoalesceOrDefault1Test()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.CoalesceOrDefault( s, null, null, "expected", "Test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CoalesceOrDefault4Test()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = expected.CoalesceOrDefault( "default", null, null );

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void CoalesceOrDefault5Test()
        {
            String value = null;
            const String expected = "expected";
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.CoalesceOrDefault( "default", null, null, expected );

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void CoalesceOrDefault6Test()
        {
            String value = null;
            const String expected = "expected";
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.CoalesceOrDefault( expected, null, null, null );

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void CoalesceOrDefaultTest()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ObjectEx.CoalesceOrDefault( null, s, null, null, expected, "Test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CoalesceOrDefaultTest2()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = ObjectEx.CoalesceOrDefault( null, () => s, null, null, expected, "Test2" );

            Assert.Equal( expected, actual );

            actual = ObjectEx.CoalesceOrDefault( null, () => expected, null, null );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void CoalesceOrDefaultTest2NullCheck()
        {
            String s = null;
            Func<String> func = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => s.CoalesceOrDefault( func, null, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CoalesceOrDefaultTest3()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = expected.CoalesceOrDefault( () => s, null, null, "Test2" );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void CoalesceOrDefaultTestNullCheck()
        {
            String s = null;
            String s1 = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => s.CoalesceOrDefault( s1, null, null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}