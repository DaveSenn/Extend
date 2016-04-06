#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void ClearTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.Clear( 0, 2 );

            Assert.AreEqual( null, array.GetValue( 0 ) );
            Assert.AreEqual( null, array.GetValue( 1 ) );
            Assert.AreEqual( "2", array.GetValue( 2 ) );
        }

        [Test]
        public void ClearTestNullCheck()
        {
            Array array = null;
            Action test = () => array.Clear( 0, 0 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}