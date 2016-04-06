#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void PopulateTest()
        {
            var array = new Int32[10];
            var actual = array.Populate( 100 );

            Assert.AreSame( array, actual );
            Assert.AreEqual( 10, array.Length );
            for ( var i = 0; i < array.Length; i++ )
            {
                Assert.AreEqual( 100, array[i] );
                Assert.AreEqual( 100, actual[i] );
            }
        }

        [Test]
        public void PopulateTestNullCheck()
        {
            String[] array = null;
            Action test = () => array.Populate( RandomValueEx.GetRandomString() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}