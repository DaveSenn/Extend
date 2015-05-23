#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void JoinTestCase()
        {
            var actual = ",".Join( new[]
            {
                "1",
                "2"
            } );
            Assert.AreEqual( "1,2", actual );
        }

        [Test]
        public void JoinTestCase1()
        {
            var actual = ",".Join( new Object[]
            {
                "1",
                "2"
            } );
            Assert.AreEqual( "1,2", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCase1NullCheck()
        {
            StringEx.Join( null,
                           new Object[]
                           {
                           } );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCase1NullCheck1()
        {
            Object[] array = null;
            "".Join( array );
        }

        [Test]
        public void JoinTestCase2()
        {
            var actual = ",".Join( new List<String> { "1", "2" } );
            Assert.AreEqual( "1,2", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCase2NullCheck()
        {
            StringEx.Join( null,
                           new Object[]
                           {
                           } );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCase2NullCheck1()
        {
            List<String> list = null;
            "".Join( list );
        }

        [Test]
        public void JoinTestCase3()
        {
            var actual = ",".Join( new List<Object> { "1", "2" } );
            Assert.AreEqual( "1,2", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCase3NullCheck()
        {
            StringEx.Join( null,
                           new Object[]
                           {
                           } );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCase3NullCheck1()
        {
            List<Object> list = null;
            "".Join( list );
        }

        [Test]
        public void JoinTestCase4()
        {
            var array = new[]
            {
                "1",
                "2",
                "3"
            };

            var actual = ",".Join( array, 1, 2 );
            Assert.AreEqual( "2,3", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCase4NullCheck()
        {
            String seperator = null;
            var array = new[]
            {
                "1",
                "2",
                "3"
            };

            var actual = seperator.Join( array, 1, 2 );
            Assert.AreEqual( "2,3", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCase4NullCheck1()
        {
            String[] array = null;

            var actual = ",".Join( array, 1, 2 );
            Assert.AreEqual( "2,3", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCaseNullCheck()
        {
            StringEx.Join( null,
                           new String[]
                           {
                           } );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void JoinTestCaseNullCheck1()
        {
            String[] array = null;
            "".Join( array );
        }
    }
}