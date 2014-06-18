#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void SaveToDoubleTestCase()
        {
            const Double expected = 100.1d;
            var actual = expected.ToString(CultureInfo.InvariantCulture).SaveToDouble();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SaveToDoubleTestCase1()
        {
            const Double expected = 123.12334d;
            var actual = "InvalidValue".SaveToDouble(expected);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SaveToDoubleTestCase2()
        {
            const Double expected = 12345234.1321d;
            var actual = expected.ToString(CultureInfo.InvariantCulture)
                .SaveToDouble(NumberStyles.Any, CultureInfo.InvariantCulture);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SaveToDoubleTestCase3()
        {
            const Double expected = 12345234.1321d;
            var actual = "InvalidValue".SaveToDouble(NumberStyles.Any, CultureInfo.InvariantCulture, expected);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveToDoubleTestCaseNullCheck()
        {
            StringEx.SaveToDouble(null);
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToDoubleTestCaseNullCheck1()
        {
            "".SaveToDouble( NumberStyles.AllowExponent, null );
        }
    }
}