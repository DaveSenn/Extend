#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ToGuidTestCase()
        {
            var value = Guid.NewGuid();
            var actual = value.ToString()
                              .ToGuid();

            Assert.AreEqual( value, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToGuidTestCase1NullCheck()
        {
            StringEx.ToGuid( null );
        }
    }
}