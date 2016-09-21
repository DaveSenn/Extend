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
        public void GenericClearTest()
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
        public void GenericClearTest1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ArrayEx.Clear<String>( null, 0, 2 );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}