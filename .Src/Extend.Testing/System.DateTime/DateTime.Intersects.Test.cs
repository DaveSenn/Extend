#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IntersectsTest()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Add( 1.ToMinutes() );
            var intersectingEndDate = startDate.Add( 10.ToMinutes() );

            Assert.True( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Fact]
        public void IntersectsTest1()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Add( 1.ToMinutes() );
            var intersectingEndDate = end.Add( 10.ToMinutes() );

            Assert.True( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Fact]
        public void IntersectsTest2()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Subtract( 10.ToMinutes() );
            var intersectingEndDate = startDate.Add( 10.ToMinutes() );

            Assert.True( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Fact]
        public void IntersectsTest3()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Subtract( 10.ToMinutes() );
            var intersectingEndDate = end.Add( 10.ToMinutes() );

            Assert.True( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Fact]
        public void IntersectsTest4()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = startDate.Subtract( 1.ToDays() );
            var intersectingEndDate = startDate.Subtract( 5.ToHours() );

            Assert.False( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }

        [Fact]
        public void IntersectsTest5()
        {
            var startDate = DateTime.Now;
            var end = startDate.Add( 1.ToHours() );

            var intersectingStartDate = end.Add( 1.ToHours() );
            var intersectingEndDate = end.Add( 2.ToHours() );

            Assert.False( startDate.Intersects( end, intersectingStartDate, intersectingEndDate ) );
        }
    }
}