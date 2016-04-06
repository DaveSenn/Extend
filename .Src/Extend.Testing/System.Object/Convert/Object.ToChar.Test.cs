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
        public void ToCharTest()
        {
            const Char expected = 'a';
            var value = expected.ToString();
            var actual = ObjectEx.ToChar( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToCharTestInvalidCastException()
        {
            Action test = () => ObjectEx.ToChar( "ab" );

            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToCharTestNullCheck()
        {
            Action test = () => ObjectEx.ToChar( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}