#region Using

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class TreeNodeTest
    {
        /// <summary>
        ///     Class used to test <see cref="ITreeNodeAware{T}" /> handling of <see cref="TreeNode{T}" />.
        /// </summary>
        private class TestTreeNodeItem : ITreeNodeAware<TestTreeNodeItem>
        {
            #region Implementation of ITreeNodeAware<TestTreeNodeItem>

            /// <summary>
            ///     Gets or sets the node of the object.
            /// </summary>
            /// <value>The node of the object.</value>
            public ITreeNode<TestTreeNodeItem> Node { get; set; }

            #endregion
        }

        /// <summary>
        ///     Constructor with no parameters
        /// </summary>
        [Test]
        public void CtorTestCase()
        {
            var target = new TreeNode<String>();
            Assert.IsNull( target.Value );
            Assert.IsNull( target.Parent );
            Assert.AreEqual( 0, target.Children.Count );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: value
        /// </summary>
        [Test]
        public void CtorTestCase1()
        {
            var value = RandomValueEx.GetRandomString();

            var target = new TreeNode<String>( value );
            Assert.AreEqual( value, target.Value );
            Assert.IsNull( target.Parent );
            Assert.AreEqual( 0, target.Children.Count );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: parent
        /// </summary>
        [Test]
        public void CtorTestCase2()
        {
            var parent = new TreeNode<String>
            {
                AncestorsTraversalDirection = TreeTraversalDirection.TopDown,
                DisposeTraversalDirection = TreeTraversalDirection.BottomUp,
                DescendantsTraversalDirection = TreeTraversalDirection.TopDown,
                SearchTraversalDirection = TreeTraversalDirection.BottomUp
            };

            var target = new TreeNode<String>( parent );
            Assert.IsNull( target.Value );
            Assert.AreSame( parent, target.Parent );
            Assert.AreEqual( 0, target.Children.Count );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.TopDown, target.AncestorsTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.TopDown, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: children
        /// </summary>
        [Test]
        public void CtorTestCase3()
        {
            var exParent = new TreeNode<String>();
            var children = new TreeNodeCollection<String>( exParent )
            {
                "Item0",
                "Item1",
                "Item2"
            };
            children.ForEach( x => x.DisposeTraversalDirection = TreeTraversalDirection.TopDown );

            var target = new TreeNode<String>( children );
            Assert.IsNull( target.Value );
            Assert.IsNull( target.Parent );

            Assert.AreEqual( 3, target.Children.Count );
            target.Children.ForEach( x => Assert.AreSame( target, x.Parent ) );
            target.Children.ForEach(
                x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.AncestorsTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DescendantsTraversalDirection ) );

            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: value, children
        /// </summary>
        [Test]
        public void CtorTestCase4()
        {
            var exParent = new TreeNode<String>();
            var value = RandomValueEx.GetRandomString();
            var children = new TreeNodeCollection<String>( exParent )
            {
                "Item0",
                "Item1",
                "Item2"
            };
            children.ForEach( x => x.DisposeTraversalDirection = TreeTraversalDirection.TopDown );

            var target = new TreeNode<String>( value, children );
            Assert.AreEqual( value, target.Value );
            Assert.IsNull( target.Parent );

            Assert.AreEqual( 3, target.Children.Count );
            target.Children.ForEach( x => Assert.AreSame( target, x.Parent ) );
            target.Children.ForEach(
                x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.AncestorsTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DescendantsTraversalDirection ) );

            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: value, parent
        /// </summary>
        [Test]
        public void CtorTestCase5()
        {
            var value = RandomValueEx.GetRandomString();
            var parent = new TreeNode<String>
            {
                AncestorsTraversalDirection = TreeTraversalDirection.TopDown,
                DisposeTraversalDirection = TreeTraversalDirection.BottomUp,
                DescendantsTraversalDirection = TreeTraversalDirection.TopDown,
                SearchTraversalDirection = TreeTraversalDirection.BottomUp
            };

            var target = new TreeNode<String>( value, parent );
            Assert.AreEqual( value, target.Value );
            Assert.AreSame( parent, target.Parent );
            Assert.AreEqual( 0, target.Children.Count );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.TopDown, target.AncestorsTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.TopDown, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: children
        /// </summary>
        [Test]
        public void CtorTestCase6()
        {
            var value = RandomValueEx.GetRandomString();
            var parent = new TreeNode<String>
            {
                AncestorsTraversalDirection = TreeTraversalDirection.TopDown,
                DisposeTraversalDirection = TreeTraversalDirection.BottomUp,
                DescendantsTraversalDirection = TreeTraversalDirection.TopDown,
                SearchTraversalDirection = TreeTraversalDirection.BottomUp
            };
            var exParent = new TreeNode<String>();
            var children = new TreeNodeCollection<String>( exParent )
            {
                "Item0",
                "Item1",
                "Item2"
            };
            children.ForEach( x => x.DisposeTraversalDirection = TreeTraversalDirection.TopDown );

            var target = new TreeNode<String>( value, parent, children );
            Assert.AreEqual( value, target.Value );
            Assert.AreSame( parent, target.Parent );

            Assert.AreEqual( 3, target.Children.Count );
            target.Children.ForEach( x => Assert.AreSame( target, x.Parent ) );
            target.Children.ForEach(
                x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.AreEqual( TreeTraversalDirection.TopDown, x.AncestorsTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.AreEqual( TreeTraversalDirection.TopDown, x.DescendantsTraversalDirection ) );

            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.TopDown, target.AncestorsTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.TopDown, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Test for switching parent
        /// </summary>
        [Test]
        public void CtorTestCase7()
        {
            var exParent = new TreeNode<String>( "Ex" );
            var children = new TreeNodeCollection<String>( exParent )
            {
                "Item0",
            };

            var target = new TreeNode<String>( "Target", children );
            Assert.AreEqual( 1, target.Children.Count, "Target should have 1 child" );
            Assert.AreSame( target, target.Children.First().Parent, "Parent should have been updated to target" );
            Assert.AreEqual( 0, exParent.Children.Count, "The child should have been detached from it's old parent" );
        }

        /// <summary>
        ///     Check if added as child to parent.
        /// </summary>
        [Test]
        public void ParentTestCase()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNode<String> { Parent = parent };
            Assert.AreSame( parent, target.Parent );
            Assert.IsTrue( parent.Children.Contains( target ) );
        }

        /// <summary>
        ///     Check if added as child to new parent and removed from old parent.
        /// </summary>
        [Test]
        public void ParentTestCase1()
        {
            var parent = new TreeNode<String>();
            var exParent = new TreeNode<String>();

            var target = new TreeNode<String>( exParent );
            Assert.AreSame( exParent, target.Parent );

            target.Parent = parent;
            Assert.AreSame( parent, target.Parent );
            Assert.IsTrue( parent.Children.Contains( target ) );
            Assert.IsFalse( exParent.Children.Contains( target ) );
        }

        /// <summary>
        ///     Check if added as child to parent and if children are getting updated.
        /// </summary>
        [Test]
        public void ParentTestCase2()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNode<String> { "Item1" };
            Assert.AreSame( target, target.Children.First().Parent );
            Assert.AreEqual( 1, target.Children.First().Depth );

            target.Parent = parent;
            Assert.AreSame( parent, target.Parent );
            Assert.IsTrue( parent.Children.Contains( target ) );
            Assert.AreSame( target, target.Children.First().Parent );
            Assert.AreEqual( 2, target.Children.First().Depth );
        }

        [Test]
        public void RootTestCase()
        {
            var target = new TreeNode<String>();
            Assert.AreSame( target, target.Root );
        }

        [Test]
        public void RootTestCase1()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNode<String>( parent );
            Assert.AreSame( parent, target.Root );
        }

        /// <summary>
        ///     Normal value
        /// </summary>
        [Test]
        public void ValueTestCase()
        {
            var target = new TreeNode<String>();
            var expected = RandomValueEx.GetRandomString();
            target.Value = expected;
            Assert.AreEqual( expected, target.Value );
        }

        /// <summary>
        ///     Value implementing <see cref="ITreeNodeAware{T}" />.
        /// </summary>
        [Test]
        public void ValueTestCase1()
        {
            var target = new TreeNode<TestTreeNodeItem>();
            var expected = new TestTreeNodeItem();
            Assert.IsNull( expected.Node );
            target.Value = expected;
            Assert.AreSame( expected, target.Value );
            Assert.AreSame( target, expected.Node );
        }

        /// <summary>
        ///     Value implementing <see cref="ITreeNodeAware{T}" />.
        ///     Reset value to check if node gets set to null.
        /// </summary>
        [Test]
        public void ValueTestCase2()
        {
            var target = new TreeNode<TestTreeNodeItem>();
            var expected = new TestTreeNodeItem();
            Assert.IsNull( expected.Node );
            target.Value = expected;
            Assert.AreSame( expected, target.Value );
            Assert.AreSame( target, expected.Node );

            var newValue = new TestTreeNodeItem();
            target.Value = newValue;
            Assert.AreSame( newValue, target.Value );
            Assert.AreSame( target, newValue.Node );

            //Check if node is null.
            Assert.IsNull( expected.Node );
        }
    }
}