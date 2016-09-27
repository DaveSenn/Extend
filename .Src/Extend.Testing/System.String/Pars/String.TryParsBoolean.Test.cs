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
        public void TryParsBooleanInvalidValueTest()
        {
            Boolean outValue;
            var actual = "InvalidValue".TryParsBoolean( out outValue );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsBooleanNullTest()
        {
            Boolean outValue;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsBoolean( out outValue );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsBooleanTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            // ReSharper disable once RedundantAssignment
            var outValue = !expected;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsBoolean( out outValue );

            actual
                .Should()
                .BeTrue();

            outValue
                .Should()
                .Be( expected );
        }
    }
}