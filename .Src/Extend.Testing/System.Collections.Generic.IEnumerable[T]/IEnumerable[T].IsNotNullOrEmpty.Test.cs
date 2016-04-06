#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CollectionTExTest
    {
        [Test]
        public void IsNotNullOrEmptyTest()
        {
            List<String> list = null;
            Assert.IsFalse( list.IsNotNullOrEmpty() );

            list = new List<String>();
            Assert.IsFalse( list.IsNotNullOrEmpty() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsTrue( list.IsNotNullOrEmpty() );
        }
    }
}