#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Test]
        public void IsNullOrEmptyTest()
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