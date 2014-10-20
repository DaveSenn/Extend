#region Usings

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class OrSpecificationTest
    {
        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CtorTestCaseNulLCheck ()
        {
            var target = new OrSpecification<String>( new ExpressionSpecification<String>( x => true ), null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CtorTestCaseNulLCheck1 ()
        {
            var target = new OrSpecification<String>( null, new ExpressionSpecification<String>( x => true ) );
        }

        [Test]
        public void IsSatisfiedByTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase1 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase2 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCas4 ()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase1 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase2 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.IsNull( actual [0] );
            Assert.IsNull( actual [1] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase5 ()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase6 ()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase7 ()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x == "msgLeft" ) );
            Assert.AreEqual( 1, actual.Count( x => x == "msgRight" ) );
        }
    }
}