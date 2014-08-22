#region Using

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
        [TestCase]
        public void RandomizeTestCase()
        {
            var list = new List<String>();
            var result = list.Randomize();
            Assert.AreEqual(list.Count, result.CountOptimized());

            list = RandomValueEx.GetRandomStrings( 100 );
            result = list.Randomize();
            Assert.AreEqual(list.Count, result.CountOptimized());
            Assert.IsTrue( list.All( x => result.Contains( x ) ) );

            var resultList = result.ToList();
            for ( var i = 0; i < list.Count; i++ )
                if ( list[i] != resultList[i] )
                    return;
            Assert.IsTrue( false, "The items are in the same order in both collections." );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RandomizeTestCaseNullCheck()
        {
            List<Object> list = null;
            list.Randomize();
        }
    }
}