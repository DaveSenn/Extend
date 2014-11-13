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
        /// Constructor with no parameters
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
        /// Constructor with the following parameters: value
        /// </summary>
        [Test]
        public void CtorTestCase1()
        {
            var value = RandomValueEx.GetRandomString();

            var target = new TreeNode<String>(value);
            Assert.AreEqual(value, target.Value);
            Assert.IsNull(target.Parent);
            Assert.AreEqual(0, target.Children.Count);
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection);
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.SearchTraversalDirection);
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection);
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection);
        }

        /// <summary>
        /// Constructor with the following parameters: parent
        /// </summary>
        [Test]
        public void CtorTestCase2()
        {
            var parent = new TreeNode<String>()
            {
                AncestorsTraversalDirection = TreeTraversalDirection.TopDown,
                DisposeTraversalDirection = TreeTraversalDirection.BottomUp,
                DescendantsTraversalDirection = TreeTraversalDirection.TopDown,
                SearchTraversalDirection = TreeTraversalDirection.BottomUp
            };

            var target = new TreeNode<String>(parent);
            Assert.IsNull(target.Value);
            Assert.AreSame(parent, target.Parent);
            Assert.AreEqual(0, target.Children.Count);
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection);
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.SearchTraversalDirection);
            Assert.AreEqual(TreeTraversalDirection.TopDown, target.AncestorsTraversalDirection);
            Assert.AreEqual(TreeTraversalDirection.TopDown, target.DescendantsTraversalDirection);
        }

        /// <summary>
        /// Constructor with the following parameters: children
        /// </summary>
        [Test]
        public void CtorTestCase3()
        {
            var exParent = new TreeNode<String>();
            var children = new TreeNodeCollection<String>(exParent)
            {
                "Item0",
                "Item1",
                "Item2"
            };

            var target = new TreeNode<String>(children);
            Assert.IsNull(target.Value);
            Assert.IsNull(target.Parent);
            Assert.AreEqual(3, target.Children.Count);
            target.Children.ForEach( x => Assert.AreSame( target, x.Parent ) );
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection);
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.SearchTraversalDirection);
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection);
            Assert.AreEqual(TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection);
        }
    }
}

/*
Value = value;
Parent = parent;
if ( Parent != null && !Parent.Children.Contains( this ) )
    Parent.Children.Add( this );
Children = children ?? new TreeNodeCollection<T>( this );
DisposeTraversalDirection = TreeTraversalDirection.BottomUp;
 */