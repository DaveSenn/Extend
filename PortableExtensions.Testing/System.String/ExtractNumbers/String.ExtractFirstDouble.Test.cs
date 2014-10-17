#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ExtractFirstDoubleTestCase ()
        {
            var value0 = 100.2;
            var value1 = 100.212;
            var value2 = -1100.2231232;
            var value3 = 12300;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                                .Replace( ",", "." );

            var actual =
                stringValue.ExtractFirstDouble( stringValue.IndexOf( value1.ToString( CultureInfo.InvariantCulture ),
                                                                     StringComparison.Ordinal ) );
            Assert.AreEqual( value1, actual );

            actual = stringValue.ExtractFirstDouble();
            Assert.AreEqual( value0, actual );
        }

        [Test]
        public void ExtractFirstDoubleTestCase1 ()
        {
            var sValue = "asdf-100.1234asdf";
            var actual = sValue.ExtractFirstDouble();

            Assert.AreEqual( -100.1234d, actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentOutOfRangeException) )]
        public void ExtractFirstDoubleTestCase1ArgumentOutOfRangeException ()
        {
            var sValue = RandomValueEx.GetRandomString();
            sValue.ExtractFirstDouble( sValue.Length );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentOutOfRangeException) )]
        public void ExtractFirstDoubleTestCase2ArgumentOutOfRangeException ()
        {
            var sValue = RandomValueEx.GetRandomString();
            sValue.ExtractFirstDouble( -1 );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ExtractFirstDoubleTestCaseNullCheck ()
        {
            StringEx.ExtractFirstDouble( null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ExtractFirstDoubleTestCaseNullCheck1 ()
        {
            StringEx.ExtractFirstDouble( null, 0 );
        }
    }
}