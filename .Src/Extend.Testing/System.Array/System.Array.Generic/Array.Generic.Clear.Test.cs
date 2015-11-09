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
        public void GenericClearTestCase()
        {
            var array = new[]
            {
                "test",
                "test"
            };
            array.Clear( 0, 2 );

            Assert.AreEqual( null, array[0] );
            Assert.AreEqual( null, array[1] );
        }

        [Test]
        public void GenericClearTestCase1()
        {
            Action test = () => ArrayEx.Clear<String>( null, 0, 2 );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}