#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void SpecificationForItemsTest()
        {
            var targets = new List<String>();
            var actual = targets.SpecificationForItems( x => x.Length > 3 );

            var result = actual.IsSatisfiedBy( "1234" );
            Assert.IsTrue( result );
        }

        [Test]
        public void SpecificationForItemsTest1()
        {
            var targets = new List<String>();
            var actual = targets.SpecificationForItems( x => x.Length > 3 );

            var result = actual.IsSatisfiedBy( "123" );
            Assert.IsFalse( result );
        }

        [Test]
        public void SpecificationForItemsTest2()
        {
            var targets = new List<String>();
            var actual = targets.SpecificationForItems( x => x.Length > 3, "msg" );

            var result = actual.IsSatisfiedByWithMessages( "1234" )
                               .ToList();
            Assert.AreEqual( 0, result.Count );
        }

        [Test]
        public void SpecificationForItemsTest3()
        {
            var targets = new List<String>();
            var actual = targets.SpecificationForItems( x => x.Length > 3, "msg" );

            var result = actual.IsSatisfiedByWithMessages( "123" )
                               .ToList();
            Assert.AreEqual( 1, result.Count );
            Assert.AreEqual( 1, result.Count( x => x == "msg" ) );
        }

        [Test]
        public void SpecificationForItemsTestNullCheck()
        {
            var targets = new List<String>();
            Func<String, Boolean> expression = null;
            Action test = () => targets.SpecificationForItems( expression );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}