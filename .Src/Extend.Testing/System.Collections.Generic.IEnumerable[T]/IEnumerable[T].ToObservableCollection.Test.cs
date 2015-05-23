#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void ToObservableCollectionTestCase()
        {
            var list = RandomValueEx.GetRandomStrings();
            var actual = list.ToObservableCollection();

            Assert.AreEqual( list.Count, actual.Count );
            for ( var i = 0; i < list.Count; i++ )
                Assert.AreEqual( list[i], actual[i] );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToObservableCollectionTestCaseNullCheck()
        {
            List<Object> list = null;
            list.ToObservableCollection();
        }
    }
}