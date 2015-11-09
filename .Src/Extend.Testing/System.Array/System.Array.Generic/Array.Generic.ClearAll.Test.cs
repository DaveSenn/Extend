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
        public void GenericClearAllTestCase()
        {
            var array = new[]
            {
                "test",
                "test"
            };
            array.ClearAll();

            Assert.AreEqual( null, array[0] );
            Assert.AreEqual( null, array[1] );
        }

        [Test]
        public void GenericClearAllTestCase1()
        {
            String[] array = null;
            Action test = () => array.ClearAll();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}