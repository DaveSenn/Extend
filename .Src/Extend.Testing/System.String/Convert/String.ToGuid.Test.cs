#region Usings

using System;
using FluentAssertions;
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
        public void ToGuidTestCase1NullCheck()
        {
            Action test = () => StringEx.ToGuid( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}