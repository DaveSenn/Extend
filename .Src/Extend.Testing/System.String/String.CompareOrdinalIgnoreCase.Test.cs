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
        public void CompareOrdinalIgnoreNullTest()
        {
            var left = RandomValueEx.GetRandomString();
            String right = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = left.CompareOrdinalIgnoreCase( right );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void CompareOrdinalIgnoreNullTest1()
        {
            String left = null;
            var right = RandomValueEx.GetRandomString();

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = left.CompareOrdinalIgnoreCase( right );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void CompareOrdinalIgnoreTest()
        {
            var value1 = RandomValueEx.GetRandomString();
            var value2 = value1;

            var actual = value1.CompareOrdinalIgnoreCase( value2 );
            Assert.IsTrue( actual );

            value2 = value1.ToUpper();
            actual = value1.CompareOrdinalIgnoreCase( value2 );
            Assert.IsTrue( actual );

            value2 = RandomValueEx.GetRandomString();
            actual = value1.CompareOrdinalIgnoreCase( value2 );
            Assert.IsFalse( actual );
        }
    }
}