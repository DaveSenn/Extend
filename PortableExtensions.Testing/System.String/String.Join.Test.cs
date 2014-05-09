#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void JoinTestCase()
        {
            var actual = ",".Join( new[]
            {
                "1",
                "2"
            } );
            Assert.AreEqual( "1,2", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void JoinTestCaseNullCheck()
        {
            StringEx.Join( null, new String[]
            {
            } );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void JoinTestCaseNullCheck1()
        {
            String[] array = null;
            "".Join( array );
        }

        [TestCase]
        public void JoinTestCase1()
        {
            var actual = ",".Join( new Object[]
            {
                "1",
                "2"
            } );
            Assert.AreEqual( "1,2", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void JoinTestCase1NullCheck()
        {
            StringEx.Join( null, new Object[]
            {
            } );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void JoinTestCase1NullCheck1()
        {
            Object[] array = null;
            "".Join( array );
        }

        [TestCase]
        public void JoinTestCase2()
        {
            var actual = ",".Join( new List<String> { "1", "2" } );
            Assert.AreEqual( "1,2", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void JoinTestCase2NullCheck()
        {
            StringEx.Join( null, new Object[]
            {
            } );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void JoinTestCase2NullCheck1()
        {
            List<String> list = null;
            "".Join( list );
        }

        [TestCase]
        public void JoinTestCase3()
        {
            var actual = ",".Join( new List<Object> { "1", "2" } );
            Assert.AreEqual( "1,2", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void JoinTestCase3NullCheck()
        {
            StringEx.Join( null, new Object[]
            {
            } );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void JoinTestCase3NullCheck1()
        {
            List<Object> list = null;
            "".Join( list );
        }
    }
}