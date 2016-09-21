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
        public void ExtractFirstInt64Test()
        {
            const Int32 value0 = 100;
            const Int32 value1 = 102;
            const Int32 value2 = -1100;
            const Int32 value3 = 12300;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                                .Replace( ",", "." );

            var actual =
                stringValue.ExtractFirstInt64( stringValue.IndexOf( value1.ToString( CultureInfo.InvariantCulture ),
                                                                    StringComparison.Ordinal ) );
            Assert.AreEqual( value1, actual );

            actual = stringValue.ExtractFirstInt64();
            Assert.AreEqual( value0, actual );
        }

        [Test]
        public void ExtractFirstInt64Test1()
        {
            const String sValue = "asdf-100asdf";
            var actual = sValue.ExtractFirstInt64();

            Assert.AreEqual( -100, actual );
        }

        [Test]
        public void ExtractFirstInt64TestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractFirstInt64( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExtractFirstInt64TestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractFirstInt64( null, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}