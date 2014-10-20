#region Usings

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class AndSpecificationTest
    {
        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CtorTestCaseNulLCheck ()
        {
            var target = new AndSpecification<String>( new ExpressionSpecification<String>( x => true ), null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CtorTestCaseNulLCheck1 ()
        {
            var target = new AndSpecification<String>( null, new ExpressionSpecification<String>( x => true ) );
        }

        [Test]
        public void IsSatisfiedByTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase1 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase2 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCas1 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.IsNull( actual [0] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCas2 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.IsNull( actual [0] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCas3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.IsNull( actual [0] );
            Assert.IsNull( actual [1] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCas5 ()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.AreEqual( "msgLeft", actual [0] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCas6 ()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.AreEqual( "msgRight", actual [0] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCas7 ()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x == "msgLeft" ) );
            Assert.AreEqual( 1, actual.Count( x => x == "msgRight" ) );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase4 ()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new AndSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count );
        }
    }
}