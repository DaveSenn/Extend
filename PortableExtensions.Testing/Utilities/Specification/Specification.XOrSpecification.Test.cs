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
        public void AndTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestCase1 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestCase2 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void AndTestCase3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestCase4 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void AndTestCaseNullCheck ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            ExpressionSpecification<String> other = null;
            target.And( other );
        }

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
            Assert.AreEqual( actaul [0], "The given object matches both specifications." );
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

        [Test]
        public void OrTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase1 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void OrTestCase2 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase4 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void OrTestCaseNullCheck ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            ExpressionSpecification<String> other = null;
            target.Or( other );
        }

        [Test]
        public void XOrTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void XOrTestCase1 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void XOrTestCase2 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void XOrTestCase3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void XOrTestCase4 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void XOrTestCaseNullCheck ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            ExpressionSpecification<String> other = null;
            target.XOr( other );
        }
    }
}