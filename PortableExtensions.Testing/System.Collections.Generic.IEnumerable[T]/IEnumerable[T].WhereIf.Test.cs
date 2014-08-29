#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [TestCase]
        public void WhereIfTestCase()
        {
            var list = new List<String>();

            var actual = list.WhereIf( true, x => true );
            Assert.AreEqual( 0, actual.CountOptimized() );

            actual = list.WhereIf( true, x => false );
            Assert.AreEqual( 0, actual.CountOptimized() );

            actual = list.WhereIf( false, x => true );
            Assert.AreEqual( 0, actual.CountOptimized() );

            list = RandomValueEx.GetRandomStrings();

            actual = list.WhereIf( true, x => true );
            Assert.AreEqual( list.Count, actual.CountOptimized() );

            actual = list.WhereIf( true, x => false );
            Assert.AreEqual( 0, actual.CountOptimized() );

            actual = list.WhereIf( false, x => true );
            Assert.AreSame( list, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void WhereIfTestCaseNullCheck()
        {
            List<Object> list = null;
            list.WhereIf( true, x => true );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void WhereIfTestCaseNullCheck1()
        {
            Func<Object, Boolean> func = null;
            new List<Object>().WhereIf( true, func );
        }

        [TestCase]
        public void WhereIfTestCase1()
        {
            var list = new List<String>();

            var actual = list.WhereIf( true, ( x, i ) => true );
            Assert.AreEqual( 0, actual.CountOptimized() );

            actual = list.WhereIf( true, ( x, i ) => false );
            Assert.AreEqual( 0, actual.CountOptimized() );

            actual = list.WhereIf( false, ( x, i ) => true );
            Assert.AreEqual( 0, actual.CountOptimized() );

            list = RandomValueEx.GetRandomStrings();

            actual = list.WhereIf( true, ( x, i ) => true );
            Assert.AreEqual( list.Count, actual.CountOptimized() );

            actual = list.WhereIf( true, ( x, i ) => false );
            Assert.AreEqual( 0, actual.CountOptimized() );

            actual = list.WhereIf( false, ( x, i ) => true );
            Assert.AreSame( list, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void WhereIfTestCase1NullCheck()
        {
            List<Object> list = null;
            list.WhereIf( true, ( x, i ) => true );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void WhereIfTestCase1NullCheck1()
        {
            Func<Object, Int32, Boolean> func = null;
            new List<Object>().WhereIf( true, func );
        }
    }
}