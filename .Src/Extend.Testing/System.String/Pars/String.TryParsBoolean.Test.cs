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
        public void TryParsBooleanTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var result = !expected;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsBoolean( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsBooleanTestNullCheck()
        {
            var outValue = false;
            Action test = () => StringEx.TryParsBoolean( null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}