#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void TryParsCharTest()
        {
            var expected = 'b';
            var result = 'a';
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsChar( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsCharTestNullCheck()
        {
            var outValue = 's';
            Action test = () => StringEx.TryParsChar( null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}