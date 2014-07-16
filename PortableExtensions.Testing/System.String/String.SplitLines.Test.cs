#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void SplitLinesTestCase()
        {
            var value = "test";

            var actual = value.SplitLines( StringSplitOptions.RemoveEmptyEntries );
            Assert.AreEqual( 1, actual.Length );
            Assert.AreEqual( value, actual[0] );

            actual = value.SplitLines( StringSplitOptions.None );
            Assert.AreEqual( 1, actual.Length );
            Assert.AreEqual( value, actual[0] );
        }

        [TestCase]
        public void SplitLinesTestCase1()
        {
            var value = "test{0}test{0}{0}".F( Environment.NewLine );

            var actual = value.SplitLines( StringSplitOptions.RemoveEmptyEntries );
            Assert.AreEqual( 2, actual.Length );
            Assert.AreEqual( "test", actual[0] );
            Assert.AreEqual( "test", actual[1] );

            actual = value.SplitLines( StringSplitOptions.None );
            Assert.AreEqual( 4, actual.Length );
            Assert.AreEqual( "test", actual[0] );
            Assert.AreEqual( "test", actual[1] );
            Assert.AreEqual( String.Empty, actual[2] );
            Assert.AreEqual( String.Empty, actual[3] );
        }

        [TestCase]
        public void SplitLinesTestCase2()
        {
            var value = "test";

            var actual = value.SplitLines();
            Assert.AreEqual( 1, actual.Length );
            Assert.AreEqual( value, actual[0] );
        }

        [TestCase]
        public void SplitLinesTestCase3()
        {
            var value = "test{0}test{0}{0}".F( Environment.NewLine );

            var actual = value.SplitLines();
            Assert.AreEqual( 2, actual.Length );
            Assert.AreEqual( "test", actual[0] );
            Assert.AreEqual( "test", actual[1] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SplitLinesTestCase2NullCheck()
        {
            String value = null;
            value.SplitLines();
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SplitLinesTestCaseNullCheck()
        {
            String value = null;

            value.SplitLines( StringSplitOptions.RemoveEmptyEntries );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SplitLinesTestCaseNullCheck1()
        {
            String value = null;

            value.SplitLines( StringSplitOptions.None );
        }
    }
}