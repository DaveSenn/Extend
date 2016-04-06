#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void IsMultipleOfTest()
        {
            Int64 value = RandomValueEx.GetRandomInt32();
            Int64 factor = RandomValueEx.GetRandomInt32();

            var expected = value % factor == 0;
            var actual = value.IsMultipleOf( factor );
            Assert.AreEqual( expected, actual );

            value = 10;
            factor = 2;

            expected = true;
            actual = value.IsMultipleOf( factor );
            Assert.AreEqual( expected, actual );

            value = 10;
            factor = 3;

            expected = false;
            actual = value.IsMultipleOf( factor );
            Assert.AreEqual( expected, actual );
        }
    }
}