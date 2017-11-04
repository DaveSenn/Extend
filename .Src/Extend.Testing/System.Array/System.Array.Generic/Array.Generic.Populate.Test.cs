#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ArrayExTest
    {
        [Fact]
        public void PopulateTest()
        {
            var array = new Int32[10];
            var actual = array.Populate( 100 );

            Assert.Same( array, actual );
            Assert.Equal( 10, array.Length );
            for ( var i = 0; i < array.Length; i++ )
            {
                Assert.Equal( 100, array[i] );
                Assert.Equal( 100, actual[i] );
            }
        }

        [Fact]
        public void PopulateTestNullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Populate( RandomValueEx.GetRandomString() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}