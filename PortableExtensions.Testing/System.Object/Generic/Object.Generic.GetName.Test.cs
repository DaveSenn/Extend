#region Using

using System;
using System.Linq.Expressions;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void GetNameTestCase()
        {
            var varName = "";
            var actual = varName.GetName( x => varName );

            Assert.AreEqual( "varName", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetNameTestCaseNullCheck()
        {
            Expression<Func<Object, Object>> fieldName = null;
            "".GetName( fieldName );
        }
    }
}