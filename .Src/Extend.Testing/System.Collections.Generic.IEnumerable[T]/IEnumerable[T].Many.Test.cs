#region Usings

using System;
using System.Collections.Generic;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void ManyTest()
        {
            var list = new List<String>();
            Assert.False( list.Many() );

            list = RandomValueEx.GetRandomStrings( 1 );
            Assert.False( list.Many() );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.True( list.Many() );
        }

        [Fact]
        public void ManyTest1()
        {
            var list = new List<String>();
            Assert.False( list.Many( x => true ) );

            list = RandomValueEx.GetRandomStrings( 1 );
            Assert.False( list.Many( x => true ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.False( list.Many( x => false ) );
            Assert.True( list.Many( x => true ) );
        }

        [Fact]
        public void ManyTest1NullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.Many( x => true );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ManyTest1NullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().Many( null );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ManyTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.Many();

            Assert.Throws<ArgumentNullException>( test );
        }
    }
}