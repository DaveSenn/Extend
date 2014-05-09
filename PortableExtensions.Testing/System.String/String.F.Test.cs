#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void FormatTestCase()
        {
            var format = "Test: {0}";
            var value = RandomValueEx.GetRandomString();

            var expected = String.Format( format, value );
            var actual = format.F( value );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void FormatTestCaseNullCheck()
        {
            StringEx.F( null, new Object() );
        }

        [TestCase]
        public void FormatTestCase1()
        {
            var format = "Test: {0}, {1}";
            var value = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();

            var expected = String.Format( format, value, value1 );
            var actual = format.F( value, value1 );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void FormatTestCase1NullCheck()
        {
            StringEx.F( null, new Object(), new Object() );
        }

        [TestCase]
        public void FormatTestCase2()
        {
            var format = "Test: {0}, {1}, {2}";
            var value = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();
            var value2 = RandomValueEx.GetRandomString();

            var expected = String.Format( format, value, value1, value2 );
            var actual = format.F( value, value1, value2 );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void FormatTestCase2NullCheck()
        {
            StringEx.F( null, new Object(), new Object(), new Object() );
        }

        [TestCase]
        public void FormatTestCase3()
        {
            var format = "Test: {0}, {1}, {2}";
            var value = RandomValueEx.GetRandomString();
            var value1 = RandomValueEx.GetRandomString();
            var value2 = RandomValueEx.GetRandomString();
            var value3 = RandomValueEx.GetRandomString();

            var expected = String.Format( format, value, value1, value2, value3 );
            var actual = format.F( value, value1, value2, value3 );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void FormatTestCase3NullCheck()
        {
            StringEx.F( null, new Object(), new Object(), new Object(), new Object() );
        }

        [TestCase]
        public void FormatTestCase4()
        {
            var format = "Test: {0}, {1}, {2}";
            var value = RandomValueEx.GetRandomString().Substring( 0, 2 );
            var value1 = RandomValueEx.GetRandomString().Substring( 0, 2 );
            var value2 = RandomValueEx.GetRandomString().Substring( 0, 2 );
            var value3 = RandomValueEx.GetRandomString().Substring( 0, 2 );

            var expected = String.Format( CultureInfo.InvariantCulture, format, value, value1, value2, value3 );
            var actual = format.F( CultureInfo.InvariantCulture, value, value1, value2, value3 );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void FormatTestCase4NullCheck()
        {
            StringEx.F( null, CultureInfo.InvariantCulture, new Object(), new Object(), new Object(), new Object() );
        }
    }
}