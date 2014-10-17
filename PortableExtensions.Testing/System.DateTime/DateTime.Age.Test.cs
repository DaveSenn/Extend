#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void AgeTestCase ()
        {
            var dateTime = new DateTime( 1980, 1, 1 );
            var expected = DateTime.Now.Year - 1980;
            var actual = dateTime.Age();
            Assert.AreEqual( expected, actual );

            dateTime = DateTime.Now.AddYears( -2 ).Add( 1.ToDays() );

            expected = 1;
            actual = dateTime.Age();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase1 ()
        {
            var dateTime = DateTime.Now.AddYears( -2 ).Add( 1.ToDays() );
            const Int32 expected = 1;

            var actual = dateTime.Age();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase10 ()
        {
            var dateTime = DateTime.Now;
            var currentDate = DateTime.Now.AddYears( 2 ).AddDays( 1 );
            const Int32 expected = 2;

            var actual = dateTime.Age( currentDate );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase11 ()
        {
            var dateTime = DateTime.Now;
            var currentDate = DateTime.Now.AddYears( 2 ).AddDays( -1 );
            const Int32 expected = 1;

            var actual = dateTime.Age( currentDate );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase12 ()
        {
            var dateTime = DateTime.Now;
            var currentDate = DateTime.Now.AddYears( -2 );
            const Int32 expected = -2;

            var actual = dateTime.Age( currentDate );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase13 ()
        {
            var dateTime = DateTime.Now;
            var currentDate = DateTime.Now.AddYears( -2 ).AddDays( 1 );
            const Int32 expected = -1;

            var actual = dateTime.Age( currentDate );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase14 ()
        {
            var dateTime = DateTime.Now;
            var currentDate = DateTime.Now.AddYears( -2 ).AddMonths( 1 );
            const Int32 expected = -1;

            var actual = dateTime.Age( currentDate );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase2 ()
        {
            var dateTime = DateTime.Now.AddYears( -1 ).AddMonths( -3 );
            const Int32 expected = 1;

            var actual = dateTime.Age();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase3 ()
        {
            var dateTime = DateTime.Now.AddDays( 1 );
            const Int32 expected = 0;

            var actual = dateTime.Age();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase4 ()
        {
            var dateTime = DateTime.Now.AddYears( 3 );
            const Int32 expected = -3;

            var actual = dateTime.Age();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase5 ()
        {
            var dateTime = DateTime.Now.AddMonths( 1 );
            const Int32 expected = 0;

            var actual = dateTime.Age();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase6 ()
        {
            var dateTime = DateTime.Now;
            const Int32 expected = 0;

            var actual = dateTime.Age();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase7 ()
        {
            var dateTime = DateTime.Now.AddYears( 1 ).AddMonths( 1 );
            const Int32 expected = -2;

            var actual = dateTime.Age();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase8 ()
        {
            var dateTime = DateTime.Now.AddYears( 1 ).AddDays( 1 );
            const Int32 expected = -2;

            var actual = dateTime.Age();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void AgeTestCase9 ()
        {
            var dateTime = DateTime.Now;
            var currentDate = DateTime.Now.AddYears( 2 );
            const Int32 expected = 2;

            var actual = dateTime.Age( currentDate );
            Assert.AreEqual( expected, actual );
        }
    }
}