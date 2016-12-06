#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Test]
        public void EnsureNotNullTest()
        {
            List<String> list = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = list.EnsureNotNull();

            Assert.IsNotNull( actual );
            Assert.AreEqual( 0, actual.Count() );
            Assert.IsNull( list );
        }

        [Test]
        public void EnsureNotNullTest1()
        {
            var list = new List<String>
            {
                "1",
                "2",
                "3"
            };
            var actual = list.EnsureNotNull();
            var actualList = actual.ToList();

            Assert.AreEqual( 3, actualList.Count );
            Assert.AreEqual( "1", actualList.ElementAt( 0 ) );
            Assert.AreEqual( "2", actualList.ElementAt( 1 ) );
            Assert.AreEqual( "3", actualList.ElementAt( 2 ) );
            Assert.AreSame( list, actual );
        }
    }
}