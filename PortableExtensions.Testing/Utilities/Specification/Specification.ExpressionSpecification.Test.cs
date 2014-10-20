#region Usings

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class ExpressionSpecificationTest
    {
        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CtorTestCaseNulLCheck ()
        {
            var target = new ExpressionSpecification<String>( null );
        }

        [Test]
        public void IsSatisfiedByTestCase ()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedBy( "123" );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase1 ()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedBy( "123456" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase ()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedByWithMessages( "123" ).ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.IsNull( actual [0] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase1 ()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedByWithMessages( "123456" ).ToList();
            Assert.AreEqual( 0, actual.Count );
        }
    }
}