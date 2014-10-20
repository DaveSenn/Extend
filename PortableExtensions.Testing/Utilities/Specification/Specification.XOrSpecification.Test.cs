#region Usings

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class XOrSpecificationTest
    {
        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CtorTestCaseNulLCheck ()
        {
            var target = new XOrSpecification<String>( new ExpressionSpecification<String>( x => true ), null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CtorTestCaseNulLCheck1 ()
        {
            var target = new XOrSpecification<String>( null, new ExpressionSpecification<String>( x => true ) );
        }

        [Test]
        public void IsSatisfiedByTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actaul );
        }

        [Test]
        public void IsSatisfiedByTestCase1 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actaul );
        }

        [Test]
        public void IsSatisfiedByTestCase2 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actaul );
        }

        [Test]
        public void IsSatisfiedByTestCase3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actaul );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 1, actaul.Count );
            Assert.AreEqual(actaul[0], "The given object matches both specifications.");
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase1 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actaul.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase2 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actaul.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 2, actaul.Count );
            Assert.IsNull( actaul [0] );
            Assert.IsNull( actaul [1] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase4 ()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 1, actaul.Count );
            Assert.AreEqual( actaul [0], "The given object matches both specifications." );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase5 ()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actaul.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase6 ()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actaul.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase7 ()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 2, actaul.Count );
            Assert.AreEqual( 1, actaul.Count( x => x == "msgLeft" ) );
            Assert.AreEqual( 1, actaul.Count( x => x == "msgRight" ) );
        }
    }
}