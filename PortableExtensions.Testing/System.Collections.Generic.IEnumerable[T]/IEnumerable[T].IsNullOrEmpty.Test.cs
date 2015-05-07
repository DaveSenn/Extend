#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void IsNullOrEmptyTestCase()
        {
            List<String> list = null;
            Assert.IsTrue( list.IsNullOrEmpty() );

            list = new List<String>();
            Assert.IsTrue( list.IsNullOrEmpty() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsFalse( list.IsNullOrEmpty() );
        }
    }
}