#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void SaveToCharTestCase()
        {
            const Char expected = 'c';
            var actual = expected.ToString().SaveToChar();

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToCharTestCase1()
        {
            const Char expected = 'a';
            var actual = "InvalidValue".SaveToChar( expected );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToCharTestCaseNullCheck()
        {
            StringEx.SaveToChar( null );
        }
    }
}