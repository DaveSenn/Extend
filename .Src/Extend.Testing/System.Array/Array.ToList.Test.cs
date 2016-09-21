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
        public void ToListTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var list = array.ToList( x => "test" + x );

            Assert.AreEqual( "test0", list[0] );
            Assert.AreEqual( "test1", list[1] );
            Assert.AreEqual( "test2", list[2] );
        }

        [Test]
        public void ToListTestNullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.ToList( x => "test" + x );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToListTestNullCheck1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            Func<Object, String> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.ToList( func );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}