#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void EnsureNotNullTestCase()
        {
            List<String> list = null;
            var actual = list.EnsureNotNull();

            Assert.IsNotNull( actual );
            Assert.AreEqual( 0, actual.Count() );
            Assert.IsNull( list );
        }

        [Test]
        public void EnsureNotNullTestCase1()
        {
            var list = new List<String>
            {
                "1",
                "2",
                "3"
            };
            var actual = list.EnsureNotNull();

            Assert.AreEqual( 3, actual.Count() );
            Assert.AreEqual( "1", actual.ElementAt( 0 ) );
            Assert.AreEqual( "2", actual.ElementAt( 1 ) );
            Assert.AreEqual( "3", actual.ElementAt( 2 ) );
            Assert.AreSame( list, actual );
        }
    }
}