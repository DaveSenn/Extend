#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void WhereIfTest()
        {
            var list = new List<String>();

            var actual = list.WhereIf( true, x => true );
            Assert.Empty( actual );

            actual = list.WhereIf( true, x => false );
            Assert.Empty( actual );

            actual = list.WhereIf( false, x => true );
            Assert.Empty( actual );

            list = RandomValueEx.GetRandomStrings();

            actual = list.WhereIf( true, x => true );
            Assert.Equal( list.Count, actual.Count() );

            actual = list.WhereIf( true, x => false );
            Assert.Empty( actual );

            actual = list.WhereIf( false, x => true );
            Assert.Same( list, actual );
        }

        [Fact]
        public void WhereIfTest1()
        {
            var list = new List<String>();

            var actual = list.WhereIf( true, ( x, i ) => true );
            Assert.Empty( actual );

            actual = list.WhereIf( true, ( x, i ) => false );
            Assert.Empty( actual );

            actual = list.WhereIf( false, ( x, i ) => true );
            Assert.Empty( actual );

            list = RandomValueEx.GetRandomStrings();

            actual = list.WhereIf( true, ( x, i ) => true );
            Assert.Equal( list.Count, actual.Count() );

            actual = list.WhereIf( true, ( x, i ) => false );
            Assert.Empty( actual );

            actual = list.WhereIf( false, ( x, i ) => true );
            Assert.Same( list, actual );
        }

        [Fact]
        public void WhereIfTest1NullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.WhereIf( true, ( x, i ) => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WhereIfTest1NullCheck1()
        {
            Func<Object, Int32, Boolean> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().WhereIf( true, func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WhereIfTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.WhereIf( true, x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WhereIfTestNullCheck1()
        {
            Func<Object, Boolean> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().WhereIf( true, func );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}