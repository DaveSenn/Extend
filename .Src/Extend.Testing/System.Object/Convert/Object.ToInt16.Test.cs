#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToInt16Test()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var value = expected.ToString();
            var actual = ObjectEx.ToInt16( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToInt16Test1()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var value = expected.ToString();
            var actual = ObjectEx.ToInt16( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToInt16Test1NullCheck()
        {
            Action test = () => ObjectEx.ToInt16( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt16Test1NullCheck1()
        {
            Action test = () => ObjectEx.ToInt16( "false", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt16TestNullCheck()
        {
            Action test = () => ObjectEx.ToInt16( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}