#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void IntersectsTestCase()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Add( 1.ToMinutes() );
            var intersectingEndDate = startDate.Add( 10.ToMinutes() );

            Assert.IsTrue( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Test]
        public void IntersectsTestCase1()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Add( 1.ToMinutes() );
            var intersectingEndDate = end.Add( 10.ToMinutes() );

            Assert.IsTrue( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Test]
        public void IntersectsTestCase2()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Subtract( 10.ToMinutes() );
            var intersectingEndDate = startDate.Add( 10.ToMinutes() );

            Assert.IsTrue( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Test]
        public void IntersectsTestCase3()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Subtract( 10.ToMinutes() );
            var intersectingEndDate = end.Add( 10.ToMinutes() );

            Assert.IsTrue( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Test]
        public void IntersectsTestCase4()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Subtract( 1.ToDays() );
            var intersectingEndDate = startDate.Subtract( 5.ToHours() );

            Assert.IsFalse( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Test]
        public void IntersectsTestCase5()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = end.Add( 1.ToHours() );
            var intersectingEndDate = end.Add( 2.ToHours() );

            Assert.IsFalse( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }
    }
}