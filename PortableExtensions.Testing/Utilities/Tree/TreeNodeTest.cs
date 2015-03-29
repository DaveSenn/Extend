#region Usings

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

        private void AssertAncestorsTraversalDirection<T>( TreeTraversalDirection expected, ITreeNode<T> node )
        {
            Assert.AreEqual( expected, node.AncestorsTraversalDirection );
            node.Children.ForEach( x => AssertAncestorsTraversalDirection( expected, x ) );
        }

        private void AssertSearchTraversalDirection<T>( TreeTraversalDirection expected, ITreeNode<T> node )
        {
            Assert.AreEqual( expected, node.SearchTraversalDirection );
            node.Children.ForEach( x => AssertSearchTraversalDirection( expected, x ) );
        }

        private void AssertDisposeTraversalDirection<T>( TreeTraversalDirection expected, ITreeNode<T> node )
        {
            Assert.AreEqual( expected, node.DisposeTraversalDirection );
            node.Children.ForEach( x => AssertDisposeTraversalDirection( expected, x ) );
        }

        private void AssertDescendantsTraversalDirection<T>( TreeTraversalDirection expected, ITreeNode<T> node )
        {
            Assert.AreEqual( expected, node.DescendantsTraversalDirection );
            node.Children.ForEach( x => AssertDescendantsTraversalDirection( expected, x ) );
        }

        [Test]
        public void AncestorsTestCase()
        {
            var target = new TreeNode<String>( "root" );
            var actual = target.Ancestors.ToList();
            Assert.AreEqual( 0, actual.Count );

            var node1 = new TreeNode<String>( "1", target );
            actual = node1.Ancestors.ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.AreSame( target, actual[0] );

            var node2 = new TreeNode<String>( "1", node1 );
            actual = node2.Ancestors.ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreSame( node1, actual[0] );
            Assert.AreSame( target, actual[1] );
        }

        [Test]
        public void AncestorsTraversalDirectionTestCase()
        {
            var target = new TreeNode<String>
            {
                "Item1",
                "Item2",
                new TreeNode<String>( "ItemA" )
                {
                    "ItemA1",
                    "ItemA2"
                }
            };

            var expected = RandomValueEx.GetRandomEnum<TreeTraversalDirection>();
            target.AncestorsTraversalDirection = expected;
            AssertAncestorsTraversalDirection( expected, target );
        }

        /// <summary>
        ///     Set children of node and add then children
        /// </summary>
        [Test]
        public void ChildrenTestCase()
        {
            var target = new TreeNode<String>();
            var children = new TreeNodeCollection<String>( target );

            target.Children = children;
            Assert.AreSame( children, target.Children );

            children.Add( "Item1" );
            children.Add( "Item2" );

            Assert.AreEqual( 2, target.Children.Count );
            Assert.AreSame( children, target.Children );

            children.ForEach( x => Assert.AreSame( target, x.Parent ) );
        }

        /// <summary>
        ///     Set children (Collection with some items)
        /// </summary>
        [Test]
        public void ChildrenTestCase1()
        {
            var target = new TreeNode<String>();
            var children = new TreeNodeCollection<String>( target ) { "Item1", "Item2" };

            target.Children = children;
            Assert.AreSame( children, target.Children );
            Assert.AreEqual( 2, target.Children.Count );

            children.ForEach( x => Assert.AreSame( target, x.Parent ) );
        }

        /// <summary>
        ///     Switch children of two nodes
        /// </summary>
        /// <remarks>
        ///     Feel free to improve the implementation.
        /// </remarks>
        [Test]
        [ExpectedException( typeof (InvalidOperationException) )]
        public void ChildrenTestCase2()
        {
            var node1 = new TreeNode<String>( "node1" )
            {
                "Item1",
                "Item2"
            };

            var node2 = new TreeNode<String>( "node2" )
            {
                "ItemA",
                "ItemB"
            };

            Assert.AreEqual( 2, node1.Children.Count );
            node1.Children.ForEach( x => Assert.AreSame( node1, x.Parent ) );

            Assert.AreEqual( 2, node2.Children.Count );
            node2.Children.ForEach( x => Assert.AreSame( node2, x.Parent ) );

            var node1Children = node1.Children;
            var node2Children = node2.Children;

            //Add children from 2 to 1
            node1.Children = node2Children;
            //Add children from 1 to 2
            node2.Children = node1Children;
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
            Assert.AreSame( target,
                            target.Children.First()
                                  .Parent,
                            "Parent should have been updated to target" );
            Assert.AreEqual( 0, exParent.Children.Count, "The child should have been detached from it's old parent" );
        }

        [Test]
        public void DepthTestCase()
        {
            var target = new TreeNode<String>( "root" );
            Assert.AreEqual( 0, target.Depth );

            var item1 = new TreeNode<String>( "1" );
            Assert.AreEqual( 0, item1.Depth );
            target.Add( item1 );
            Assert.AreEqual( 1, item1.Depth );

            var item2 = new TreeNode<String>( "1" );
            Assert.AreEqual( 0, item2.Depth );
            item1.Add( item2 );
            Assert.AreEqual( 2, item2.Depth );
        }

        /// <summary>
        ///     Creates the following tree.
        ///     root
        ///     | 1
        ///     | | A
        ///     | | B
        ///     | 2
        /// </summary>
        [Test]
        public void DescendantsTestCase()
        {
            var target = new TreeNode<String>( "root" );
            var actual = target.Descendants.ToList();
            Assert.AreEqual( 0, actual.Count );

            var node1 = new TreeNode<String>( "1", target );
            //Descendants of root
            actual = target.Descendants.ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.AreSame( actual[0], node1 );
            //Descendants of node1
            actual = node1.Descendants.ToList();
            Assert.AreEqual( 0, actual.Count );

            var nodeA = new TreeNode<String>( "A", node1 );
            //Descendants of root
            actual = target.Descendants.ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreSame( actual[0], node1 );
            Assert.AreSame( actual[1], nodeA );
            //Descendants of node1
            actual = node1.Descendants.ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.AreSame( actual[0], nodeA );
            //Descendants of nodeA
            actual = nodeA.Descendants.ToList();
            Assert.AreEqual( 0, actual.Count );

            var nodeB = new TreeNode<String>( "B", node1 );
            //Descendants of root
            actual = target.Descendants.ToList();
            Assert.AreEqual( 3, actual.Count );
            Assert.AreSame( actual[0], node1 );
            Assert.AreSame( actual[1], nodeA );
            Assert.AreSame( actual[2], nodeB );
            //Descendants of node1
            actual = node1.Descendants.ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreSame( actual[0], nodeA );
            Assert.AreSame( actual[1], nodeB );
            //Descendants of nodeB
            actual = nodeB.Descendants.ToList();
            Assert.AreEqual( 0, actual.Count );

            var node2 = new TreeNode<String>( "2", target );
            //Descendants of root
            actual = target.Descendants.ToList();
            Assert.AreEqual( 4, actual.Count );
            Assert.AreSame( actual[0], node1 );
            Assert.AreSame( actual[1], nodeA );
            Assert.AreSame( actual[2], nodeB );
            Assert.AreSame( actual[3], node2 );
            //Descendants of node2
            actual = node2.Descendants.ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void DescendantsTraversalDirectionTestCase()
        {
            var target = new TreeNode<String>
            {
                "Item1",
                "Item2",
                new TreeNode<String>( "ItemA" )
                {
                    "ItemA1",
                    "ItemA2"
                }
            };

            var expected = RandomValueEx.GetRandomEnum<TreeTraversalDirection>();
            target.DescendantsTraversalDirection = expected;
            AssertDescendantsTraversalDirection( expected, target );
        }

        [Test]
        public void DisposeTraversalDirectionTestCase()
        {
            var target = new TreeNode<String>
            {
                "Item1",
                "Item2",
                new TreeNode<String>( "ItemA" )
                {
                    "ItemA1",
                    "ItemA2"
                }
            };

            var expected = RandomValueEx.GetRandomEnum<TreeTraversalDirection>();
            target.DisposeTraversalDirection = expected;
            AssertDisposeTraversalDirection( expected, target );
        }

        /// <summary>
        ///     Search TopDown only top level
        /// </summary>
        [Test]
        public void FindNodeOverloadTestCase()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "1" ),
                },
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindNode( "1" )
                               .ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( "root", actual[0].Parent.Value );
            Assert.AreEqual( "2", actual[1].Parent.Value );
        }

        /// <summary>
        ///     Search BottomUp only top level
        /// </summary>
        [Test]
        public void FindNodeOverloadTestCase1()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "1" ),
                },
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindNode( "1" )
                               .ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( "2", actual[0].Parent.Value );
            Assert.AreEqual( "root", actual[1].Parent.Value );
        }

        /// <summary>
        ///     Search TopDown only top level
        /// </summary>
        [Test]
        public void FindNodeTestCase()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" ),
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" ),
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindNode( x => x.Value.StartsWith( "1" ) )
                               .ToList();
            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( "1", actual[0].Value );
            Assert.AreEqual( "111", actual[1].Value );
            Assert.AreEqual( "11", actual[2].Value );
            Assert.AreEqual( "1111", actual[3].Value );
        }

        /// <summary>
        ///     Search TopDown all level
        /// </summary>
        [Test]
        public void FindNodeTestCase1()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" ),
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" ),
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindNode( x => x.Value == "root" || x.Value.StartsWith( "1" ) || x.Value.StartsWith( "b" ) )
                               .ToList();
            Assert.AreEqual( 7, actual.Count );
            Assert.AreEqual( "root", actual[0].Value );
            Assert.AreEqual( "1", actual[1].Value );
            Assert.AreEqual( "b", actual[2].Value );
            Assert.AreEqual( "111", actual[3].Value );
            Assert.AreEqual( "11", actual[4].Value );
            Assert.AreEqual( "b1", actual[5].Value );
            Assert.AreEqual( "1111", actual[6].Value );
        }

        /// <summary>
        ///     Search BottomUp only top level
        /// </summary>
        [Test]
        public void FindNodeTestCase2()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" ),
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" ),
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindNode( x => x.Value.StartsWith( "1" ) )
                               .ToList();
            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( "1111", actual[0].Value );
            Assert.AreEqual( "11", actual[1].Value );
            Assert.AreEqual( "111", actual[2].Value );
            Assert.AreEqual( "1", actual[3].Value );
        }

        /// <summary>
        ///     Search BottomUp all level
        /// </summary>
        [Test]
        public void FindNodeTestCase3()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" ),
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" ),
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindNode( x => x.Value == "root" || x.Value.StartsWith( "1" ) || x.Value.StartsWith( "b" ) )
                               .ToList();
            Assert.AreEqual( 7, actual.Count );
            Assert.AreEqual( "1111", actual[0].Value );
            Assert.AreEqual( "b1", actual[1].Value );
            Assert.AreEqual( "11", actual[2].Value );
            Assert.AreEqual( "111", actual[3].Value );
            Assert.AreEqual( "b", actual[4].Value );
            Assert.AreEqual( "1", actual[5].Value );
            Assert.AreEqual( "root", actual[6].Value );
        }

        /// <summary>
        ///     Search TopDown only top level
        /// </summary>
        [Test]
        public void FindValueTestCase()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" ),
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" ),
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindValue( x => x.Value.StartsWith( "1" ) )
                               .ToList();
            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( "1", actual[0] );
            Assert.AreEqual( "111", actual[1] );
            Assert.AreEqual( "11", actual[2] );
            Assert.AreEqual( "1111", actual[3] );
        }

        /// <summary>
        ///     Search TopDown all level
        /// </summary>
        [Test]
        public void FindValueTestCase1()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" ),
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" ),
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindValue( x => x.Value == "root" || x.Value.StartsWith( "1" ) || x.Value.StartsWith( "b" ) )
                               .ToList();
            Assert.AreEqual( 7, actual.Count );
            Assert.AreEqual( "root", actual[0] );
            Assert.AreEqual( "1", actual[1] );
            Assert.AreEqual( "b", actual[2] );
            Assert.AreEqual( "111", actual[3] );
            Assert.AreEqual( "11", actual[4] );
            Assert.AreEqual( "b1", actual[5] );
            Assert.AreEqual( "1111", actual[6] );
        }

        /// <summary>
        ///     Search BottomUp only top level
        /// </summary>
        [Test]
        public void FindValueTestCase2()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" ),
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" ),
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindValue( x => x.Value.StartsWith( "1" ) )
                               .ToList();
            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( "1111", actual[0] );
            Assert.AreEqual( "11", actual[1] );
            Assert.AreEqual( "111", actual[2] );
            Assert.AreEqual( "1", actual[3] );
        }

        /// <summary>
        ///     Search BottomUp all level
        /// </summary>
        [Test]
        public void FindValueTestCase3()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" ),
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" ),
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindValue( x => x.Value == "root" || x.Value.StartsWith( "1" ) || x.Value.StartsWith( "b" ) )
                               .ToList();
            Assert.AreEqual( 7, actual.Count );
            Assert.AreEqual( "1111", actual[0] );
            Assert.AreEqual( "b1", actual[1] );
            Assert.AreEqual( "11", actual[2] );
            Assert.AreEqual( "111", actual[3] );
            Assert.AreEqual( "b", actual[4] );
            Assert.AreEqual( "1", actual[5] );
            Assert.AreEqual( "root", actual[6] );
        }

        [Test]
        public void HasChildrenTestCase()
        {
            var target = new TreeNode<String>( "root" );
            Assert.IsFalse( target.HasChildren );

            var item1 = new TreeNode<String>( "1" );
            Assert.IsFalse( item1.HasChildren );
            target.Add( item1 );
            Assert.IsFalse( item1.HasChildren );
            Assert.IsTrue( target.HasChildren );

            var item2 = new TreeNode<String>( "1" );
            Assert.IsFalse( item2.HasChildren );
            Assert.AreEqual( 0, item2.Depth );
            item1.Add( item2 );
            Assert.AreEqual( 2, item2.Depth );
            Assert.IsFalse( item2.HasChildren );
            Assert.IsTrue( item1.HasChildren );
            Assert.IsTrue( target.HasChildren );
        }

        [Test]
        public void HasParentTestCase()
        {
            var target = new TreeNode<String>( "root" );
            Assert.IsFalse( target.HasParent );

            var item1 = new TreeNode<String>( "1" );
            Assert.IsFalse( item1.HasParent );
            target.Add( item1 );
            Assert.IsTrue( item1.HasParent );

            var item2 = new TreeNode<String>( "1" );
            Assert.IsFalse( item2.HasParent );
            item1.Add( item2 );
            Assert.IsTrue( item2.HasParent );
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
            Assert.AreSame( target,
                            target.Children.First()
                                  .Parent );
            Assert.AreEqual( 1,
                             target.Children.First()
                                   .Depth );

            target.Parent = parent;
            Assert.AreSame( parent, target.Parent );
            Assert.IsTrue( parent.Children.Contains( target ) );
            Assert.AreSame( target,
                            target.Children.First()
                                  .Parent );
            Assert.AreEqual( 2,
                             target.Children.First()
                                   .Depth );
        }

        /// <summary>
        ///     Remove item from node1 and add it to node2
        /// </summary>
        [Test]
        public void RemoveAndAddChild()
        {
            var node1 = new TreeNode<String>( "node1" )
            {
                "Item1",
                "Item2"
            };

            var node2 = new TreeNode<String>( "node2" )
            {
                "ItemA",
                "ItemB"
            };

            Assert.AreEqual( 2, node1.Children.Count );
            node1.Children.ForEach( x => Assert.AreSame( node1, x.Parent ) );

            Assert.AreEqual( 2, node2.Children.Count );
            node2.Children.ForEach( x => Assert.AreSame( node2, x.Parent ) );

            var child = node1.Children.First();
            node2.Add( child );

            node1.Children.Remove( child );

            Assert.AreEqual( 1, node1.Children.Count );
            node1.Children.ForEach( x => Assert.AreSame( node1, x.Parent ) );

            Assert.AreEqual( 3, node2.Children.Count );
            node2.Children.ForEach( x => Assert.AreSame( node2, x.Parent ) );
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

        [Test]
        public void SearchTraversalDirectionTestCase()
        {
            var target = new TreeNode<String>
            {
                "Item1",
                "Item2",
                new TreeNode<String>( "ItemA" )
                {
                    "ItemA1",
                    "ItemA2"
                }
            };

            var expected = RandomValueEx.GetRandomEnum<TreeTraversalDirection>();
            target.SearchTraversalDirection = expected;
            AssertSearchTraversalDirection( expected, target );
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