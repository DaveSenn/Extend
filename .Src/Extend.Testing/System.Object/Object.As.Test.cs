#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void AsTest()
        {
            Object value = 10;
            var actual = value.As<Int32>();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void AsTestNullCheck()
        {
            Action test = () => ObjectEx.As<String>( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}