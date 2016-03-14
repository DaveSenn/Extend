﻿#region Usings

using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void GetLinesArgumentNullExceptionTest()
        {
            String value = null;
            Action test = () => value.GetLines()
                                     .ToList();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetLinesTest()
        {
            var text = "Line1" + Environment.NewLine + "Line2" + Environment.NewLine + "Line3" + Environment.NewLine + "Line4" + Environment.NewLine;

            var actual = text.GetLines()
                             .ToList();

            actual.Should()
                  .HaveCount( 4 );
            actual[0].Should()
                     .Be( "Line1" );
            actual[1].Should()
                     .Be( "Line2" );
            actual[2].Should()
                     .Be( "Line3" );
            actual[3].Should()
                     .Be( "Line4" );
        }

        [Test]
        public void GetLinesTest1()
        {
            var text = "Line1" + Environment.NewLine + Environment.NewLine + "Line2" + Environment.NewLine + "Line3" + Environment.NewLine + "Line4" + Environment.NewLine;

            var actual = text.GetLines()
                             .ToList();

            actual.Should()
                  .HaveCount( 5 );
            actual[0].Should()
                     .Be( "Line1" );
            actual[1].Should()
                     .Be( "" );
            actual[2].Should()
                     .Be( "Line2" );
            actual[3].Should()
                     .Be( "Line3" );
            actual[4].Should()
                     .Be( "Line4" );
        }

        [Test]
        public void GetLinesTest2()
        {
            var actual = "".GetLines()
                           .ToList();

            actual.Should()
                  .HaveCount( 0 );
        }
    }
}