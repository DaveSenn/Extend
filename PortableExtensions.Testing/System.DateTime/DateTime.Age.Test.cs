#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void AgeTestCase()
        {
            var dateTime = new DateTime(1980, 1, 1);
            var expected = DateTime.Now.Year - 1980;
            var actual = dateTime.Age();
            Assert.AreEqual(expected, actual);

            dateTime = DateTime.Now.AddYears(-2).Add(1.ToDays());

            expected = 1;
            actual = dateTime.Age();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AgeTestCase1()
        {
            var dateTime = DateTime.Now.AddYears(-2).Add(1.ToDays());
            const Int32 expected = 1;

            var actual = dateTime.Age();
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AgeTestCase2()
        {
            var dateTime = DateTime.Now.AddYears(-1).AddMonths(-3);
            const Int32 expected = 1;

            var actual = dateTime.Age();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AgeTestCase3()
        {
            var dateTime = DateTime.Now.AddDays(1);
            const Int32 expected = -1;

            var actual = dateTime.Age();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AgeTestCase4()
        {
            var dateTime = DateTime.Now.AddYears(3);
            const Int32 expected = -3;

            var actual = dateTime.Age();
            Assert.AreEqual(expected, actual);
        }
    }
}
