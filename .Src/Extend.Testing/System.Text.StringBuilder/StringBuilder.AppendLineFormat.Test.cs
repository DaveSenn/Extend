#region Usings

using System;
using System.Text;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class StringBuilderExTest
    {
        [Fact]
        public void AppendLineFormatTest()
        {
            var value0 = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();

            var sb = new StringBuilder();
            sb.AppendLine( "Line 1" );
            sb.AppendLineFormat( "Test: {0} {1}", value0, value1 );
            sb.AppendLine( "Line 3" );

            var expected = "Line 1\r\nTest: {0} {1}\r\nLine 3\r\n".F( value0, value1 );
            var actual = sb.ToString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void AppendLineFormatTest1()
        {
            var value0 = RandomValueEx.GetRandomString();

            var sb = new StringBuilder();
            sb.AppendLine( "Line 1" );
            sb.AppendLineFormat( "Test: {0}", value0 );
            sb.AppendLine( "Line 3" );

            var expected = "Line 1\r\nTest: {0}\r\nLine 3\r\n".F( value0 );
            var actual = sb.ToString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void AppendLineFormatTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringBuilderEx.AppendLineFormat( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AppendLineFormatTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new StringBuilder().AppendLineFormat( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AppendLineFormatTest2()
        {
            var value0 = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();

            var sb = new StringBuilder();
            sb.AppendLine( "Line 1" );
            sb.AppendLineFormat( "Test: {0} {1}", value0, value1 );
            sb.AppendLine( "Line 3" );

            var expected = "Line 1\r\nTest: {0} {1}\r\nLine 3\r\n".F( value0, value1 );
            var actual = sb.ToString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void AppendLineFormatTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringBuilderEx.AppendLineFormat( null, "", "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AppendLineFormatTest2NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new StringBuilder().AppendLineFormat( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AppendLineFormatTest3()
        {
            var value0 = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();
            var value2 = RandomValueEx.GetRandomString();

            var sb = new StringBuilder();
            sb.AppendLine( "Line 1" );
            sb.AppendLineFormat( "Test: {0} {1} {2}", value0, value1, value2 );
            sb.AppendLine( "Line 3" );

            var expected = "Line 1\r\nTest: {0} {1} {2}\r\nLine 3\r\n".F( value0, value1, value2 );
            var actual = sb.ToString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void AppendLineFormatTest3NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringBuilderEx.AppendLineFormat( null, "", "", "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AppendLineFormatTest3NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new StringBuilder().AppendLineFormat( null, "", "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AppendLineFormatTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringBuilderEx.AppendLineFormat( null,
                                                                  "",
                                                                  "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AppendLineFormatTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new StringBuilder().AppendLineFormat( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AppendLineFormatTestNullCheck2()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new StringBuilder().AppendLineFormat( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}