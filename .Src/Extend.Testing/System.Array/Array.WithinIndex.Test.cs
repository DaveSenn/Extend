#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void WithinIndexTestCase()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };

            var actual = array.WithinIndex( 2 );
            Assert.IsTrue( actual );

            actual = array.WithinIndex( -1 );
            Assert.IsFalse( actual );

            actual = array.WithinIndex( 5 );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void WithinIndexTestCaseNullCheck()
        {
            Array array = null;
            array.WithinIndex( 10 );
        }
    }
}