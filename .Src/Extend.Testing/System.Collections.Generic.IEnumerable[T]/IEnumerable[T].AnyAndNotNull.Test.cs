#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void AnyAndNotNullNullCheck1()
        {
            Action test = () => new List<String>().AnyAndNotNull( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void PathCombineTest()
        {
            List<String> list = null;
            Assert.IsFalse( list.AnyAndNotNull() );

            list = new List<String>();
            Assert.IsFalse( list.AnyAndNotNull() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsTrue( list.AnyAndNotNull() );
        }

        [Test]
        public void PathCombineTest1()
        {
            List<String> list = null;
            Assert.IsFalse( list.AnyAndNotNull( x => true ) );

            list = new List<String>();
            Assert.IsFalse( list.AnyAndNotNull( x => true ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsFalse( list.AnyAndNotNull( x => false ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsTrue( list.AnyAndNotNull( x => true ) );
        }
    }
}