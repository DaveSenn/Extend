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
        public void SaveToGuidInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToGuid();

            actual
                .Should()
                .Be( default(Guid) );
        }

        [Test]
        public void SaveToGuidInvalidValueWithDefaultTest()
        {
            var expected = Guid.NewGuid();
            var actual = "InvalidValue".SaveToGuid( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToGuidNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToGuid();

            actual
                .Should()
                .Be( default(Guid) );
        }

        [Test]
        public void SaveToGuidNullWitDefaultTest()
        {
            var expected = Guid.NewGuid();
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToGuid( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToGuidTest()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString()
                                 .SaveToGuid();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToGuidWithDefaultTest()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString()
                                 .SaveToGuid( Guid.NewGuid() );

            actual
                .Should()
                .Be( expected );
        }
    }
}