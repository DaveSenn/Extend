#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Test]
        public void ManyTest()
        {
            var list = new List<String>();
            Assert.IsFalse( list.Many() );

            list = RandomValueEx.GetRandomStrings( 1 );
            Assert.IsFalse( list.Many() );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsTrue( list.Many() );
        }

        [Test]
        public void ManyTest1()
        {
            var list = new List<String>();
            Assert.IsFalse( list.Many( x => true ) );

            list = RandomValueEx.GetRandomStrings( 1 );
            Assert.IsFalse( list.Many( x => true ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsFalse( list.Many( x => false ) );
            Assert.IsTrue( list.Many( x => true ) );
        }

        [Test]
        public void ManyTest1NullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.Many( x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ManyTest1NullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().Many( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ManyTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.Many();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}