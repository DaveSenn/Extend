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
        public void SaveToInt16TestCase()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString(CultureInfo.InvariantCulture).SaveToInt16();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SaveToInt16TestCase1()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = "InvalidValue".SaveToInt16(expected);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SaveToInt16TestCase2()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString(CultureInfo.InvariantCulture)
                .SaveToInt16(NumberStyles.Any, CultureInfo.InvariantCulture);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SaveToInt16TestCase3()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = "InvalidValue".SaveToInt16(NumberStyles.Any, CultureInfo.InvariantCulture, expected);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveToInt16TestCaseNullCheck()
        {
            StringEx.SaveToInt16(null);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveToInt16TestCaseNullCheck1()
        {
            "".SaveToInt16(NumberStyles.AllowExponent, null);
        }
    }
}