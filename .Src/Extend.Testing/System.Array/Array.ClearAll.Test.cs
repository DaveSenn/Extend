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
        public void ClearAllTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.ClearAll();

            Assert.AreEqual( null, array.GetValue( 0 ) );
            Assert.AreEqual( null, array.GetValue( 1 ) );
            Assert.AreEqual( null, array.GetValue( 2 ) );
        }

        [Test]
        public void ClearAllTestNullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.ClearAll();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}