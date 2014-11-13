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