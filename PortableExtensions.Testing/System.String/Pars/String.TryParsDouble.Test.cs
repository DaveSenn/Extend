#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void TryParsDoubleTestCase()
        {
            var expected = 100.123d;
            var result = 100d;
            var actual = expected.ToString( CultureInfo.InvariantCulture ).TryParsDouble( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDoubleTestCaseNullCheck()
        {
            var outValue = 100d;
            StringEx.TryParsDouble( null, out outValue );
        }

        [TestCase]
        public void TryParsDoubleTestCase1()
        {
            var culture = new CultureInfo( "en-US" );
            var expected = 100.123d;
            var result = 100d;
            var actual = expected.ToString( culture ).TryParsDouble( NumberStyles.Any, culture, out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDoubleTestCase1NullCheck()
        {
            var outValue = 100d;
            StringEx.TryParsDouble( null, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDoubleTestCase1NullCheck1()
        {
            var outValue = 100d;
            "100".TryParsDouble( NumberStyles.Any, null, out outValue );
        }
    }
}

/*
 public static Boolean TryParsDouble( this String value, NumberStyles style, IFormatProvider provider,
                                             out Double outValue )
        {
            value.ThrowIfNull( () => value );
            provider.ThrowIfNull( () => provider );

            return Double.TryParse( value, style, provider, out outValue );
        }
 */