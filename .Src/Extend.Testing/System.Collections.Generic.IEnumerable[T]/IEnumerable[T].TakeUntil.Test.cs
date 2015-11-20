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
        public void TakeUntilTestCase()
        {
            var list = new List<String>();
            var result = list.TakeUntil( x => true );
            Assert.AreEqual( list.Count, result.Count() );

            list = RandomValueEx.GetRandomStrings( 10 );
            result = list.TakeUntil( x => false );
            Assert.AreEqual( list.Count, result.Count() );

            var counter = 0;
            var resultList = list.TakeUntil( x =>
            {
                counter++;
                return counter > 5;
            } )
                                 .ToList();
            Assert.AreEqual( 5, resultList.Count );

            for ( var i = 0; i < resultList.Count; i++ )
                Assert.AreEqual( list[i], resultList[i] );
        }

        [Test]
        public void TakeUntilTestCaseNullCheck()
        {
            List<Object> list = null;
            Action test = () => list.TakeUntil( x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TakeUntilTestCaseNullCheck1()
        {
            Action test = () => new List<Object>().TakeUntil( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}