#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CollectionTExTest
    {
        [Test]
        public void AddIfTest()
        {
            var c = new List<String>();

            var result = c.AddIf( x => true, RandomValueEx.GetRandomString() );
            Assert.AreEqual( 1, c.Count );
            Assert.IsTrue( result );

            result = c.AddIf( x => false, RandomValueEx.GetRandomString() );
            Assert.AreEqual( 1, c.Count );
            Assert.IsFalse( result );
        }

        [Test]
        public void AddIfTestNullCheck()
        {
            List<String> c = null;
            Action test = () => c.AddIf( x => true, RandomValueEx.GetRandomString() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfTestNullCheck1()
        {
            var c = new List<String>();
            Action test = () => c.AddIf( null, RandomValueEx.GetRandomString() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}