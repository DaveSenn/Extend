#region Usings

using System;
using System.Text;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class StringBuilderExTest
    {
        [Test]
        public void AppendLineFormatTestCase()
        {
            var value0 = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();

            var sb = new StringBuilder();
            sb.AppendLine( "Line 1" );
            sb.AppendLineFormat( "Test: {0} {1}",
                                 new Object[]
                                 {
                                     value0,
                                     value1
                                 } );
            sb.AppendLine( "Line 3" );

            var expected = "Line 1\r\nTest: {0} {1}\r\nLine 3\r\n".F( value0, value1 );
            var actual = sb.ToString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AppendLineFormatTestCase1()
        {
            var value0 = RandomValueEx.GetRandomString();

            var sb = new StringBuilder();
            sb.AppendLine( "Line 1" );
            sb.AppendLineFormat( "Test: {0}", value0 );
            sb.AppendLine( "Line 3" );

            var expected = "Line 1\r\nTest: {0}\r\nLine 3\r\n".F( value0 );
            var actual = sb.ToString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AppendLineFormatTestCase1NullCheck()
        {
            StringBuilderEx.AppendLineFormat( null, "", "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AppendLineFormatTestCase1NullCheck1()
        {
            new StringBuilder().AppendLineFormat( null, "" );
        }

        [Test]
        public void AppendLineFormatTestCase2()
        {
            var value0 = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();

            var sb = new StringBuilder();
            sb.AppendLine( "Line 1" );
            sb.AppendLineFormat( "Test: {0} {1}", value0, value1 );
            sb.AppendLine( "Line 3" );

            var expected = "Line 1\r\nTest: {0} {1}\r\nLine 3\r\n".F( value0, value1 );
            var actual = sb.ToString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AppendLineFormatTestCase2NullCheck()
        {
            StringBuilderEx.AppendLineFormat( null, "", "", "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AppendLineFormatTestCase2NullCheck1()
        {
            new StringBuilder().AppendLineFormat( null, "", "" );
        }

        [Test]
        public void AppendLineFormatTestCase3()
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
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AppendLineFormatTestCase3NullCheck()
        {
            StringBuilderEx.AppendLineFormat( null, "", "", "", "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AppendLineFormatTestCase3NullCheck1()
        {
            new StringBuilder().AppendLineFormat( null, "", "", "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AppendLineFormatTestCaseNullCheck()
        {
            StringBuilderEx.AppendLineFormat( null,
                                              "",
                                              new Object[]
                                              {
                                                  ""
                                              } );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AppendLineFormatTestCaseNullCheck1()
        {
            new StringBuilder().AppendLineFormat( null,
                                                  new Object[]
                                                  {
                                                      ""
                                                  } );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AppendLineFormatTestCaseNullCheck2()
        {
            new StringBuilder().AppendLineFormat( "", null );
        }
    }
}