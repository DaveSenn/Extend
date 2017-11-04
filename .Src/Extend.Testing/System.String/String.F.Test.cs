#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void FManyArgumentsTest()
        {
            const String arg0 = "0";
            const String arg1 = "1";
            const String arg2 = "2";
            const String arg3 = "3";
            const String arg4 = "4";
            const String arg5 = "5";
            const String arg6 = "6";
            const String arg7 = "7";
            const String arg8 = "8";

            var actual = "{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}".F( arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 );
            Assert.Equal( "0-1-2-3-4-5-6-7-8", actual );
        }

        [Fact]
        public void FTest()
        {
            const String format = "Test: {0}";
            var value = RandomValueEx.GetRandomString();

            var expected = $"Test: {value}";
            var actual = format.F( value );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void FTest1()
        {
            const String format = "Test: {0}, {1}";
            var value = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();

            var expected = $"Test: {value}, {value1}";
            var actual = format.F( value, value1 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void FTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FTest2()
        {
            const String format = "Test: {0}, {1}, {2}";

            const String expected = "Test: 1, test, 99.9999";
            var actual = format.F( 1, "test", 99.9999 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void FTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FTest3()
        {
            const String format = "Test: {0}, {1}, {2}, {3}";

            const String expected = "Test: string, 666, string2, 123";
            var actual = format.F( "string", 666, "string2", 123 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void FTest3NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, new Object(), new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FTest4()
        {
            const String format = "Test: {0}, {1}, {2}";
            var value = RandomValueEx.GetRandomString()
                                     .Substring( 0, 2 );
            var value1 = RandomValueEx.GetRandomString()
                                      .Substring( 0, 2 );
            var value2 = RandomValueEx.GetRandomString()
                                      .Substring( 0, 2 );
            var value3 = RandomValueEx.GetRandomString()
                                      .Substring( 0, 2 );

            var expected = String.Format( CultureInfo.InvariantCulture, format, value, value1, value2 );
            // ReSharper disable once FormatStringProblem
            var actual = format.F( CultureInfo.InvariantCulture, value, value1, value2, value3 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void FTest4NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, CultureInfo.InvariantCulture, new Object(), new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}