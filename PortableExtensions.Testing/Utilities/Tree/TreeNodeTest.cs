#region Usings

using System;
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
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.AncestorsTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DescendantsTraversalDirection ) );

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
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.AncestorsTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DescendantsTraversalDirection ) );

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
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.TopDown, x.AncestorsTraversalDirection ) );
            target.Children.ForEach( x => Assert.AreEqual( TreeTraversalDirection.TopDown, x.DescendantsTraversalDirection ) );

            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.TopDown, target.AncestorsTraversalDirection );
            Assert.AreEqual( TreeTraversalDirection.TopDown, target.DescendantsTraversalDirection );
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
            Assert.IsNull(expected.Node);
            target.Value = expected;
            Assert.AreSame(expected, target.Value);
            Assert.AreSame(target, expected.Node);

            var newValue = new TestTreeNodeItem();
            target.Value = newValue;
            Assert.AreSame(newValue, target.Value);
            Assert.AreSame(target, newValue.Node);
            
            //Check if node is null.
            Assert.IsNull( expected.Node );
        }

        [Test]
        public void ParentTestCase()
        {
        }
    }
}

/*
 public ITreeNode<T> Parent
        {
            get { return _parent; }
            set
            {
                if ( value == _parent )
                    return;

                //Switch parent
                var oldParent = _parent;
                _parent = value;

                //Remove node from old parent
                if ( oldParent != null )
                    oldParent.Children.Remove( this );
            }
        }
 */