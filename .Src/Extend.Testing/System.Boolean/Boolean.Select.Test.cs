#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class BooleanExTest
    {
        [Test]
        public void SelectValueTestCase()
        {
            var trueValue = "true";
            var falseValue = "false";

            var actual = false.SelectValue( trueValue, falseValue );
            Assert.AreEqual( falseValue, actual );

            actual = true.SelectValue( trueValue, falseValue );
            Assert.AreEqual( trueValue, actual );
        }
    }
}