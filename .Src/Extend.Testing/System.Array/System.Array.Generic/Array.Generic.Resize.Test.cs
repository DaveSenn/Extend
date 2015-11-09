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
        public void GenericResizeTestCase()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            array = array.Resize( 10 );
            Assert.AreEqual( 10, array.Length );
        }

        [Test]
        public void GenericResizeTestCaseNullCheck()
        {
            String[] array = null;
            Action test = () => array.Resize( 10 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}