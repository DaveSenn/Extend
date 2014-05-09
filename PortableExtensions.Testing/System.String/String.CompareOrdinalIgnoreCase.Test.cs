#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void CompareOrdinalIgnoreCaseTestCase()
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