#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
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
            Assert.AreEqual( "0-1-2-3-4-5-6-7-8", actual );
        }

        [Test]
        public void FTest()
        {
            const String format = "Test: {0}";
            var value = RandomValueEx.GetRandomString();

            var expected = String.Format( format, value );
            var actual = format.F( value );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void FTest1()
        {
            const String format = "Test: {0}, {1}";
            var value = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();

            var expected = String.Format( format, value, value1 );
            var actual = format.F( value, value1 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void FTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void FTest2()
        {
            const String format = "Test: {0}, {1}, {2}";
            var value = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();
            var value2 = RandomValueEx.GetRandomString();

            var expected = String.Format( format, value, value1, value2 );
            var actual = format.F( value, value1, value2 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void FTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void FTest3()
        {
            const String format = "Test: {0}, {1}, {2}";
            var value = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();
            var value2 = RandomValueEx.GetRandomString();
            var value3 = RandomValueEx.GetRandomString();

            var expected = String.Format( format, value, value1, value2, value3 );
            var actual = format.F( value, value1, value2, value3 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void FTest3NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, new Object(), new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
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

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void FTest4NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, CultureInfo.InvariantCulture, new Object(), new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void FTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.F( null, new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}