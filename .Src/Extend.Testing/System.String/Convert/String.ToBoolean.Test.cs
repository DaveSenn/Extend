#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ToBooleanTestCase()
        {
            var value = RandomValueEx.GetRandomBoolean();
            var actual = value.ToString()
                              .ToBoolean();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToBooleanTestCase1()
        {
            var value = RandomValueEx.GetRandomBoolean();
            var actual = value.ToString()
                              .ToBoolean( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToBooleanTestCase1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToBoolean( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToBooleanTestCase1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".ToBoolean( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToBooleanTestCaseNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToBoolean( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}