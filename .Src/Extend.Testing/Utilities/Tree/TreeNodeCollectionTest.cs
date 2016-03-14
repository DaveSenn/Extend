#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class TreeNodeCollectionTest
    {
        /// <summary>
        ///     Update parent
        /// </summary>
        [Test]
        public void AddNodeTestCase()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item );

            Assert.IsTrue( target.Contains( item ) );
            Assert.AreEqual( 1, target.Count );

            Assert.AreSame( parent, item.Parent );
            Assert.AreEqual( 1, item.Depth );
        }

        /// <summary>
        ///     Don't update parent
        /// </summary>
        [Test]
        public void AddNodeTestCase1()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item, false );

            Assert.IsTrue( target.Contains( item ) );
            Assert.AreEqual( 1, target.Count );

            Assert.IsNull( item.Parent );
            Assert.AreEqual( 0, item.Depth );
        }

        /// <summary>
        ///     Don't update parent, item has already a parent
        /// </summary>
        [Test]
        public void AddNodeTestCase2()
        {
            var itemParent = new TreeNode<String>();
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>( itemParent );
            target.Add( item, false );

            Assert.IsTrue( target.Contains( item ) );
            Assert.AreEqual( 1, target.Count );

            Assert.AreSame( itemParent, item.Parent );
            Assert.AreEqual( 1, item.Depth );
        }

        /// <summary>
        ///     Try add same item twice.
        /// </summary>
        [Test]
        public void AddNodeTestCase3()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item );
            target.Add( item );

            Assert.IsTrue( target.Contains( item ) );
            Assert.AreEqual( 1, target.Count );

            Assert.AreSame( parent, item.Parent );
            Assert.AreEqual( 1, item.Depth );
        }

        [Test]
        public void AddTestCaseNullCheck()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            ITreeNode<String> item = null;
            Action test = () => target.Add( item );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddValueTestCase()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var expected = RandomValueEx.GetRandomString();
            var actual = target.Add( expected );

            Assert.IsTrue( target.Contains( actual ) );
            Assert.AreEqual( 1, target.Count );

            Assert.AreSame( parent, actual.Parent );
            Assert.AreEqual( actual.Value, expected );
            Assert.AreEqual( 1, actual.Depth );
        }

        [Test]
        public void AddValueTestCase1()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            String expected = null;
            var actual = target.Add( expected );

            Assert.IsTrue( target.Contains( actual ) );
            Assert.AreEqual( 1, target.Count );

            Assert.AreEqual( actual.Value, expected );
            Assert.AreSame( parent, actual.Parent );
            Assert.AreEqual( 1, actual.Depth );
        }

        /// <summary>
        ///     Add same value twice
        /// </summary>
        [Test]
        public void AddValueTestCase2()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var expected = RandomValueEx.GetRandomString();
            var actual = target.Add( expected );
            var actual1 = target.Add( expected );

            Assert.AreEqual( 2, target.Count );
            Assert.IsTrue( target.Contains( actual ) );
            Assert.IsTrue( target.Contains( actual1 ) );

            Assert.AreSame( parent, actual.Parent );
            Assert.AreEqual( actual.Value, expected );
            Assert.AreEqual( 1, actual.Depth );

            Assert.AreSame( parent, actual1.Parent );
            Assert.AreEqual( actual1.Value, expected );
            Assert.AreEqual( 1, actual1.Depth );
        }

        [Test]
        public void CollectionInitTestCase()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent )
            {
                "test1",
                new TreeNode<String>( "test2" ),
                "test3",
                new TreeNode<String>( "test4" )
            };

            Assert.AreSame( parent, target.Parent );
            Assert.AreSame( parent, target[0].Parent );
            Assert.AreSame( parent, target[1].Parent );
            Assert.AreSame( parent, target[2].Parent );
            Assert.AreSame( parent, target[3].Parent );

            Assert.AreSame( "test1", target[0].Value );
            Assert.AreSame( "test2", target[1].Value );
            Assert.AreSame( "test3", target[2].Value );
            Assert.AreSame( "test4", target[3].Value );
        }

        [Test]
        public void CtorTestCase()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNodeCollection<String>( parent );
            Assert.AreSame( parent, target.Parent );
        }

        [Test]
        public void DetachFromParentTestCase()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            target.DetachFromParent();
            Assert.IsNull( target.Parent );
        }

        [Test]
        public void DetachFromParentTestCase1()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNodeCollection<String>( parent ) { "1", "2", "3" };
            Assert.AreEqual( 3, target.Count );
            target.ForEach( x => Assert.AreSame( parent, x.Parent ) );

            target.DetachFromParent();
            Assert.IsNull( target.Parent );
            target.ForEach( x => Assert.IsNull( x.Parent ) );
        }

        [Test]
        public void IterationTestCase()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent )
            {
                "test1",
                new TreeNode<String>( "test2" ),
                "test3",
                new TreeNode<String>( "test4" )
            };

            target.ForEach( ( x, i ) => Assert.AreEqual( "test" + ( i + 1 ), x.Value ) );
        }

        [Test]
        public void ParentTestCase()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            Assert.AreEqual( parent, target.Parent );
        }

        [Test]
        public void ParentTestCase1()
        {
            var target = new TreeNodeCollection<String>( null );

            Assert.IsNull( target.Parent );
        }

        [Test]
        public void ParentTestCase2()
        {
            var target = new TreeNodeCollection<String>( null );
            Assert.IsNull( target.Parent );

            var parent = new TreeNode<String>();
            target.Parent = parent;
            Assert.AreSame( parent, target.Parent );
        }

        [Test]
        public void ParentTestCase3()
        {
            var target = new TreeNodeCollection<String>( null ) { "1", "2" };
            Assert.IsNull( target.Parent );
            target.ForEach( x => Assert.IsNull( x.Parent ) );

            var parent = new TreeNode<String>();
            target.Parent = parent;
            Assert.AreSame( parent, target.Parent );
            target.ForEach( x => Assert.AreSame( parent, x.Parent ) );
        }

        [Test]
        public void ParentTestCase4()
        {
            var target = new TreeNodeCollection<String>( null ) { "1", "2" };
            Assert.IsNull( target.Parent );
            target.ForEach( x => Assert.IsNull( x.Parent ) );

            var parent = new TreeNode<String>();
            target.Parent = parent;
            Assert.AreSame( parent, target.Parent );
            target.ForEach( x => Assert.AreSame( parent, x.Parent ) );

            target.Add( "3" );
            target.Add( "4" );
            target.ForEach( x => Assert.AreSame( parent, x.Parent ) );

            var newParent = new TreeNode<String>();
            target.Parent = newParent;

            Assert.AreSame( newParent, target.Parent );
            target.ForEach( x => Assert.AreSame( newParent, x.Parent ) );
        }

        [Test]
        public void ParentTestCase5()
        {
            var target = new TreeNodeCollection<String>( null ) { "1", "2" };
            Assert.IsNull( target.Parent );
            target.ForEach( x => Assert.IsNull( x.Parent ) );

            var parent = new TreeNode<String>();
            target.Parent = parent;
            Assert.AreSame( parent, target.Parent );
            target.ForEach( x => Assert.AreSame( parent, x.Parent ) );

            target.Add( "3" );
            target.Add( "4" );
            target.ForEach( x => Assert.AreSame( parent, x.Parent ) );

            ITreeNode<String> newParent = null;
            target.Parent = newParent;

            Assert.AreSame( newParent, target.Parent );
            target.ForEach( x => Assert.AreSame( newParent, x.Parent ) );
        }

        [Test]
        public void ParentTestCase6()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );
            target.Parent = null;

            Assert.AreEqual( null, target.Parent );
        }

        [Test]
        public void ParentTestCase7()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );
            target.Parent = parent;

            Assert.AreEqual( parent, target.Parent );
        }

        /// <summary>
        ///     Set parent.
        /// </summary>
        [Test]
        public void RemoveNodeTestCase()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item );

            var item1 = new TreeNode<String>();
            target.Add( item1 );

            var result = target.Remove( item );
            Assert.IsTrue( result );
            Assert.IsNull( item.Parent );
            Assert.IsFalse( target.Contains( item ) );

            result = target.Remove( item1 );
            Assert.IsTrue( result );
            Assert.IsNull( item1.Parent );
            Assert.IsFalse( target.Contains( item1 ) );

            Assert.AreEqual( 0, target.Count );
        }

        /// <summary>
        ///     Item is not in collection
        /// </summary>
        [Test]
        public void RemoveNodeTestCase1()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String> { Parent = parent };

            var result = target.Remove( item );
            Assert.IsFalse( result );
            Assert.AreSame( parent, item.Parent );
            Assert.IsFalse( target.Contains( item ) );
        }

        /// <summary>
        ///     Don't set parent.
        /// </summary>
        [Test]
        public void RemoveNodeTestCase2()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item );

            var item1 = new TreeNode<String>();
            target.Add( item1 );

            var result = target.Remove( item, false );
            Assert.IsTrue( result );
            Assert.AreSame( parent, item.Parent );
            Assert.IsFalse( target.Contains( item ) );

            result = target.Remove( item1, false );
            Assert.IsTrue( result );
            Assert.AreSame( parent, item1.Parent );
            Assert.IsFalse( target.Contains( item1 ) );

            Assert.AreEqual( 0, target.Count );
        }

        [Test]
        public void RemoveNodeTestCaseNullCheck()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            ITreeNode<String> item = null;
            Action test = () => target.Remove( item );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToStringTestCase()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var actual = target.ToString();
            Assert.AreEqual( "Count: 0, Parent: [Depth: 0 - Value: [NULL], Children: 0, Parent: [[NULL]]]", actual );
        }

        [Test]
        public void ToStringTestCase1()
        {
            var target = new TreeNodeCollection<String>( null );

            var actual = target.ToString();
            Assert.AreEqual( "Count: 0, Parent: [[NULL]]", actual );
        }

        [Test]
        public void ToStringTestCase2()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent ) { "1", "2" };

            var actual = target.ToString();
            Assert.AreEqual( "Count: 2, Parent: [Depth: 0 - Value: [NULL], Children: 2, Parent: [[NULL]]]", actual );
        }

        [Test]
        public void ToStringTestCase3()
        {
            var target = new TreeNodeCollection<String>( null ) { "1", "2", "3" };

            var actual = target.ToString();
            Assert.AreEqual( "Count: 3, Parent: [[NULL]]", actual );
        }
    }
}