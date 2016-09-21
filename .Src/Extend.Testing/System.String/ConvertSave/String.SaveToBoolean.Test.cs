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
        public void SaveToBooleanInvalidValueTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = "InvalidValue".SaveToBoolean( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToBooleanNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToBoolean();

            actual
                .Should()
                .Be( default(Boolean) );
        }

        [Test]
        public void SaveToBooleanNullTest1()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToBoolean( !default(Boolean) );

            actual
                .Should()
                .Be( !default(Boolean) );
        }

        [Test]
        public void SaveToBooleanTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = expected.ToString()
                                 .SaveToBoolean();

            actual
                .Should()
                .Be( expected );
        }
    }
}