#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class RandomValueExTest
    {
        [Test]
        public void GetRandomStringTestCase()
        {
            var actual = RandomValueEx.GetRandomString();
            Assert.IsTrue( actual.Length > 0 );
        }

        [Test]
        public void GetRandomStringsTestCase()
        {
            var actual = RandomValueEx.GetRandomStrings( 100 );
            Assert.AreEqual( 100, actual.Count );
            actual.ForEach( x => Assert.IsTrue( x.Length > 0 ) );
        }

        [Test]
        public void GetRandomInt32TestCase()
        {
            var actual = RandomValueEx.GetRandomInt32( 10, 20 );
            Assert.IsTrue( actual >= 10, "To small" );
            Assert.IsTrue( actual < 20, "To big" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetRandomInt32TestCaseArgumentOutOfRangeException()
        {
            RandomValueEx.GetRandomInt32( 20, 20 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetRandomInt32TestCaseArgumentOutOfRangeException1()
        {
            RandomValueEx.GetRandomInt32( 20, 10 );
        }

        [Test]
        public void GetRandomInt16TestCase()
        {
            var actual = RandomValueEx.GetRandomInt16( 10, 20 );
            Assert.IsTrue( actual >= 10, "To small" );
            Assert.IsTrue( actual < 20, "To big" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetRandomInt16TestCaseArgumentOutOfRangeException()
        {
            RandomValueEx.GetRandomInt16( 20, 20 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetRandomInt16TestCaseArgumentOutOfRangeException1()
        {
            RandomValueEx.GetRandomInt16( 20, 10 );
        }

        [Test]
        public void GetRandomBooleanTestCase()
        {
            RandomValueEx.GetRandomBoolean();
        }

        [Test]
        public void GetRandomDateTimeTestCase()
        {
            var actual = RandomValueEx.GetRandomDateTime( DateTime.Now, 10 );
            var added = actual.Day == DateTime.Now.Add( 10.ToDays() ).Day;
            var subtracted = actual.Day == DateTime.Now.Subtract( 10.ToDays() ).Day;

            Assert.IsTrue( added || subtracted );
        }

        [Test]
        public void GetRandomEnumTestCase()
        {
            RandomValueEx.GetRandomEnum<DayOfWeek>();
        }

        [Test]
        public void GetRandomInt64TestCase()
        {
            var actual = RandomValueEx.GetRandomInt64( 10, 20 );
            Assert.IsTrue( actual >= 10, "To small" );
            Assert.IsTrue( actual < 20, "To big" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetRandomInt64TestCaseArgumentOutOfRangeException()
        {
            RandomValueEx.GetRandomInt64( 20, 20 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetRandomInt64TestCaseArgumentOutOfRangeException1()
        {
            RandomValueEx.GetRandomInt64( 20, 10 );
        }
    }
}