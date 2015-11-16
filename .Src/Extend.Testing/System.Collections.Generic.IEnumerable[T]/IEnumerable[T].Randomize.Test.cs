#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void RandomizeTestCase()
        {
            var list = new List<String>();
            var result = list.Randomize();
            Assert.AreEqual( list.Count, result.Count() );

            list = RandomValueEx.GetRandomStrings( 100 );
            result = list.Randomize();
            Assert.AreEqual( list.Count, result.Count() );
            Assert.IsTrue( list.All( x => result.Contains( x ) ) );

            var resultList = result.ToList();
            if ( list.Where( ( t, i ) => t != resultList[i] ).Any() )
                return;
            Assert.IsTrue( false, "The items are in the same order in both collections." );
        }

        [Test]
        public void RandomizeTestCaseNullCheck()
        {
            List<Object> list = null;
            Action test = () => list.Randomize();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}