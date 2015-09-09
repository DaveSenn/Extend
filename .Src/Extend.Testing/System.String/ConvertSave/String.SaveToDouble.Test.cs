#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SaveToDoubleTestCase()
        {
            const Double expected = 100.1d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDouble();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToDoubleTestCase1()
        {
            const Double expected = 123.12334d;
            var actual = "InvalidValue".SaveToDouble( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToDoubleTestCase2()
        {
            const Double expected = 12345234.1321d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToDoubleTestCase3()
        {
            const Double expected = 12345234.1321d;
            var actual = "InvalidValue".SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToDoubleTestCase4()
        {
            const Double expected = 100.1d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDouble( Double.MinValue );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToDoubleTestCase5()
        {
            var actual = "InvalidValue".SaveToDouble();

            Assert.AreEqual( default( Double ), actual );
        }

        [Test]
        public void SaveToDoubleTestCase6()
        {
            const Double expected = 12345234.1321d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture, Double.MaxValue );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToDoubleTestCase7()
        {
            var actual = "InvalidValue".SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( default( Double ), actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SaveToDoubleTestCaseNullCheck()
        {
            StringEx.SaveToDouble( null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SaveToDoubleTestCaseNullCheck1()
        {
            "".SaveToDouble( NumberStyles.AllowExponent, null );
        }
    }
}