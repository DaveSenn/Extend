#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SaveToCharTestCase()
        {
            const Char expected = 'c';
            var actual = expected.ToString().SaveToChar();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToCharTestCase1()
        {
            const Char expected = 'a';
            var actual = "InvalidValue".SaveToChar( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToCharTestCaseNullCheck()
        {
            StringEx.SaveToChar( null );
        }
    }
}