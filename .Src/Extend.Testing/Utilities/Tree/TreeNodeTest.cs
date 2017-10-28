#region Usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class TreeNodeTest
    {
        [Fact]
        public void AddOverloadTest()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var target = new TreeNode<String>( "root" );
            target.Add( new TreeNode<String>( "1" ) );
            target.Add( new TreeNode<String>( "2" ) );

            Assert.Equal( 2, target.Children.Count );
            Assert.Equal( "1",
                          target.Children.ElementAt( 0 )
                                .Value );
            Assert.Equal( "2",
                          target.Children.ElementAt( 1 )
                                .Value );
        }

        [Fact]
        public void AddTest()
        {
// ReSharper disable once UseObjectOrCollectionInitializer
            var target = new TreeNode<String>( "root" );
            target.Add( "1" );
            target.Add( "2" );

            Assert.Equal( 2, target.Children.Count );
            Assert.Equal( "1",
                          target.Children.ElementAt( 0 )
                                .Value );
            Assert.Equal( "2",
                          target.Children.ElementAt( 1 )
                                .Value );
        }

        [Fact]
        public void AncestorsTest()
        {
            var target = new TreeNode<String>( "root" );
            var actual = target.Ancestors.ToList();
            Assert.Empty( actual );

            var node1 = new TreeNode<String>( "1", target );
            actual = node1.Ancestors.ToList();
            Assert.Single( actual );
            Assert.Same( target, actual[0] );

            var node2 = new TreeNode<String>( "1", node1 );
            actual = node2.Ancestors.ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Same( node1, actual[0] );
            Assert.Same( target, actual[1] );
        }

        [Fact]
        public void AncestorsTraversalDirectionTest()
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
        [Fact]
        public void ChildrenTest()
        {
            var target = new TreeNode<String>();
            var children = new TreeNodeCollection<String>( target );

            target.Children = children;
            Assert.Same( children, target.Children );

            children.Add( "Item1" );
            children.Add( "Item2" );

            Assert.Equal( 2, target.Children.Count );
            Assert.Same( children, target.Children );

            children.ForEach( x => Assert.Same( target, x.Parent ) );
        }

        /// <summary>
        ///     Set children (Collection with some items)
        /// </summary>
        [Fact]
        public void ChildrenTest1()
        {
            var target = new TreeNode<String>();
            var children = new TreeNodeCollection<String>( target ) { "Item1", "Item2" };

            target.Children = children;
            Assert.Same( children, target.Children );
            Assert.Equal( 2, target.Children.Count );

            children.ForEach( x => Assert.Same( target, x.Parent ) );
        }

        /// <summary>
        ///     Switch children of two nodes
        /// </summary>
        /// <remarks>
        ///     Feel free to improve the implementation.
        /// </remarks>
        [Fact]
        public void ChildrenTest2()
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

            Assert.Equal( 2, node1.Children.Count );
            node1.Children.ForEach( x => Assert.Same( node1, x.Parent ) );

            Assert.Equal( 2, node2.Children.Count );
            node2.Children.ForEach( x => Assert.Same( node2, x.Parent ) );

            var node2Children = node2.Children;

            //Add children from 2 to 1
            Action test = () => node1.Children = node2Children;

            test.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void ChildrenTest3()
        {
            var target = new TreeNode<String>();
            var children = new TreeNodeCollection<String>( target ) { "Item1", "Item2" };

            target.Children = children;
            Assert.Same( children, target.Children );
            Assert.Equal( 2, target.Children.Count );
            children.ForEach( x => Assert.Same( target, x.Parent ) );

            target.Children = children;
            Assert.Same( children, target.Children );
            Assert.Equal( 2, target.Children.Count );
            children.ForEach( x => Assert.Same( target, x.Parent ) );
        }

        /// <summary>
        ///     Constructor with no parameters
        /// </summary>
        [Fact]
        public void CtorTest()
        {
            var target = new TreeNode<String>();
            Assert.Null( target.Value );
            Assert.Null( target.Parent );
            Assert.Equal( 0, target.Children.Count );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: value
        /// </summary>
        [Fact]
        public void CtorTest1()
        {
            var value = RandomValueEx.GetRandomString();

            var target = new TreeNode<String>( value );
            Assert.Equal( value, target.Value );
            Assert.Null( target.Parent );
            Assert.Equal( 0, target.Children.Count );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: parent
        /// </summary>
        [Fact]
        public void CtorTest2()
        {
            var parent = new TreeNode<String>
            {
                AncestorsTraversalDirection = TreeTraversalDirection.TopDown,
                DisposeTraversalDirection = TreeTraversalDirection.BottomUp,
                DescendantsTraversalDirection = TreeTraversalDirection.TopDown,
                SearchTraversalDirection = TreeTraversalDirection.BottomUp
            };

            var target = new TreeNode<String>( parent );
            Assert.Null( target.Value );
            Assert.Same( parent, target.Parent );
            Assert.Equal( 0, target.Children.Count );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.AncestorsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: children
        /// </summary>
        [Fact]
        public void CtorTest3()
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
            Assert.Null( target.Value );
            Assert.Null( target.Parent );

            Assert.Equal( 3, target.Children.Count );
            target.Children.ForEach( x => Assert.Same( target, x.Parent ) );
            target.Children.ForEach(
                x => Assert.Equal( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection ) );
            target.Children.ForEach( x => Assert.Equal( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.Equal( TreeTraversalDirection.BottomUp, x.AncestorsTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.Equal( TreeTraversalDirection.BottomUp, x.DescendantsTraversalDirection ) );

            Assert.Equal( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: value, children
        /// </summary>
        [Fact]
        public void CtorTest4()
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
            Assert.Equal( value, target.Value );
            Assert.Null( target.Parent );

            Assert.Equal( 3, target.Children.Count );
            target.Children.ForEach( x => Assert.Same( target, x.Parent ) );
            target.Children.ForEach(
                x => Assert.Equal( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection ) );
            target.Children.ForEach( x => Assert.Equal( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.Equal( TreeTraversalDirection.BottomUp, x.AncestorsTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.Equal( TreeTraversalDirection.BottomUp, x.DescendantsTraversalDirection ) );

            Assert.Equal( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: value, parent
        /// </summary>
        [Fact]
        public void CtorTest5()
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
            Assert.Equal( value, target.Value );
            Assert.Same( parent, target.Parent );
            Assert.Equal( 0, target.Children.Count );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.AncestorsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Constructor with the following parameters: children
        /// </summary>
        [Fact]
        public void CtorTest6()
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
            Assert.Equal( value, target.Value );
            Assert.Same( parent, target.Parent );

            Assert.Equal( 3, target.Children.Count );
            target.Children.ForEach( x => Assert.Same( target, x.Parent ) );
            target.Children.ForEach(
                x => Assert.Equal( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection ) );
            target.Children.ForEach( x => Assert.Equal( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.Equal( TreeTraversalDirection.TopDown, x.AncestorsTraversalDirection ) );
            target.Children.ForEach(
                x => Assert.Equal( TreeTraversalDirection.TopDown, x.DescendantsTraversalDirection ) );

            Assert.Equal( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.AncestorsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.DescendantsTraversalDirection );
        }

        /// <summary>
        ///     Test for switching parent
        /// </summary>
        [Fact]
        public void CtorTest7()
        {
            var exParent = new TreeNode<String>( "Ex" );
            var children = new TreeNodeCollection<String>( exParent )
            {
                "Item0"
            };

            var target = new TreeNode<String>( "Target", children );
            Assert.Equal( 1, target.Children.Count );
            Assert.Same( target,
                         target.Children.First()
                               .Parent );
            Assert.Equal( 0, exParent.Children.Count );
        }

        /// <summary>
        ///     Test for full constructor
        /// </summary>
        [Fact]
        public void CtorTest8()
        {
            var value = RandomValueEx.GetRandomString();
            var parent = new TreeNode<String>( "parent" );
            var children = new TreeNodeCollection<String>( parent )
            {
                new TreeNode<String>( "1" )
            };

            var actual = new TreeNode<String>( value, parent, children );
            Assert.Equal( value, actual.Value );
            Assert.Same( parent, actual.Parent );
            Assert.Same( children, actual.Children );
        }

        [Fact]
        public void DepthTest()
        {
            var target = new TreeNode<String>( "root" );
            Assert.Equal( 0, target.Depth );

            var item1 = new TreeNode<String>( "1" );
            Assert.Equal( 0, item1.Depth );
            target.Add( item1 );
            Assert.Equal( 1, item1.Depth );

            var item2 = new TreeNode<String>( "1" );
            Assert.Equal( 0, item2.Depth );
            item1.Add( item2 );
            Assert.Equal( 2, item2.Depth );
        }

        /// <summary>
        ///     Creates the following tree.
        ///     root
        ///     | 1
        ///     | | A
        ///     | | B
        ///     | 2
        /// </summary>
        [Fact]
        public void DescendantsTest()
        {
            var target = new TreeNode<String>( "root" );
            var actual = target.Descendants.ToList();
            Assert.Empty( actual );

            var node1 = new TreeNode<String>( "1", target );
            //Descendants of root
            actual = target.Descendants.ToList();
            Assert.Single( actual );
            Assert.Same( actual[0], node1 );
            //Descendants of node1
            actual = node1.Descendants.ToList();
            Assert.Empty( actual );

            var nodeA = new TreeNode<String>( "A", node1 );
            //Descendants of root
            actual = target.Descendants.ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Same( actual[0], node1 );
            Assert.Same( actual[1], nodeA );
            //Descendants of node1
            actual = node1.Descendants.ToList();
            Assert.Single( actual );
            Assert.Same( actual[0], nodeA );
            //Descendants of nodeA
            actual = nodeA.Descendants.ToList();
            Assert.Empty( actual );

            var nodeB = new TreeNode<String>( "B", node1 );
            //Descendants of root
            actual = target.Descendants.ToList();
            Assert.Equal( 3, actual.Count );
            Assert.Same( actual[0], node1 );
            Assert.Same( actual[1], nodeA );
            Assert.Same( actual[2], nodeB );
            //Descendants of node1
            actual = node1.Descendants.ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Same( actual[0], nodeA );
            Assert.Same( actual[1], nodeB );
            //Descendants of nodeB
            actual = nodeB.Descendants.ToList();
            Assert.Empty( actual );

            var node2 = new TreeNode<String>( "2", target );
            //Descendants of root
            actual = target.Descendants.ToList();
            Assert.Equal( 4, actual.Count );
            Assert.Same( actual[0], node1 );
            Assert.Same( actual[1], nodeA );
            Assert.Same( actual[2], nodeB );
            Assert.Same( actual[3], node2 );
            //Descendants of node2
            actual = node2.Descendants.ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void DescendantsTest1()
        {
            var target = new TreeNode<String>( "root" );
            var actual = target.Descendants.ToList();
            Assert.Empty( actual );

            target.Children = null;
            actual = target.Descendants.ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void DescendantsTestNotSupportedException()
        {
            var target = new TreeNode<String>( "root" )
            {
                "1",
                "2",
                new AlternativeTreeNode<String>()
            };

            Action test = () =>
            {
                // ReSharper disable once UnusedVariable
                var actual = target.Descendants;
            };
            test.ShouldThrow<NotSupportedException>();
        }

        [Fact]
        public void DescendantsTraversalDirectionTest()
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

        [Fact]
        public void DisposeTest()
        {
            var target = new TreeNode<String>
            {
                "1",
                "2"
            };
            target.Dispose();
        }

        [Fact]
        public void DisposeTest1()
        {
            var values = new List<String>();
            var target = new TreeNode<DisposeTestHelper>
            {
                new DisposeTestHelper { Value = "1", DisposeAction = s => values.Add( s ) },
                new DisposeTestHelper { Value = "2", DisposeAction = s => values.Add( s ) },
                new DisposeTestHelper { Value = "3", DisposeAction = s => values.Add( s ) }
            };
            target.DisposeTraversalDirection = TreeTraversalDirection.TopDown;
            target.Dispose();

            Assert.Equal( 3, values.Count );
            Assert.Equal( "1", values[0] );
            Assert.Equal( "2", values[1] );
            Assert.Equal( "3", values[2] );
        }

        [Fact]
        public void DisposeTest2()
        {
            var values = new List<String>();
            var target = new TreeNode<DisposeTestHelper>
            {
                new DisposeTestHelper { Value = "1", DisposeAction = s => values.Add( s ) },
                new DisposeTestHelper { Value = "2", DisposeAction = s => values.Add( s ) },
                new DisposeTestHelper { Value = "3", DisposeAction = s => values.Add( s ) }
            };
            target.DisposeTraversalDirection = TreeTraversalDirection.BottomUp;
            target.Dispose();

            Assert.Equal( 3, values.Count );
            Assert.Equal( "3", values[0] );
            Assert.Equal( "2", values[1] );
            Assert.Equal( "1", values[2] );
        }

        [Fact]
        public void DisposeTraversalDirectionTest()
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
        [Fact]
        public void FindNodeOverloadTest()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "1" )
                }
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindNode( "1" )
                               .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Equal( "root",
                          actual[0]
                              .Parent.Value );
            Assert.Equal( "2",
                          actual[1]
                              .Parent.Value );
        }

        /// <summary>
        ///     Search BottomUp only top level
        /// </summary>
        [Fact]
        public void FindNodeOverloadTest1()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "1" )
                }
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindNode( "1" )
                               .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Equal( "2",
                          actual[0]
                              .Parent.Value );
            Assert.Equal( "root",
                          actual[1]
                              .Parent.Value );
        }

        /// <summary>
        ///     Search TopDown only top level
        /// </summary>
        [Fact]
        public void FindNodeTest()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" )
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" )
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindNode( x => x.Value.StartsWith( "1", StringComparison.Ordinal ) )
                               .ToList();
            Assert.Equal( 4, actual.Count );
            Assert.Equal( "1",
                          actual[0]
                              .Value );
            Assert.Equal( "111",
                          actual[1]
                              .Value );
            Assert.Equal( "11",
                          actual[2]
                              .Value );
            Assert.Equal( "1111",
                          actual[3]
                              .Value );
        }

        /// <summary>
        ///     Search TopDown all level
        /// </summary>
        [Fact]
        public void FindNodeTest1()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" )
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" )
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindNode( x => x.Value == "root" || x.Value.StartsWith( "1", StringComparison.Ordinal ) || x.Value.StartsWith( "b", StringComparison.Ordinal ) )
                               .ToList();
            Assert.Equal( 7, actual.Count );
            Assert.Equal( "root",
                          actual[0]
                              .Value );
            Assert.Equal( "1",
                          actual[1]
                              .Value );
            Assert.Equal( "b",
                          actual[2]
                              .Value );
            Assert.Equal( "111",
                          actual[3]
                              .Value );
            Assert.Equal( "11",
                          actual[4]
                              .Value );
            Assert.Equal( "b1",
                          actual[5]
                              .Value );
            Assert.Equal( "1111",
                          actual[6]
                              .Value );
        }

        /// <summary>
        ///     Search BottomUp only top level
        /// </summary>
        [Fact]
        public void FindNodeTest2()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" )
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" )
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindNode( x => x.Value.StartsWith( "1", StringComparison.Ordinal ) )
                               .ToList();
            Assert.Equal( 4, actual.Count );
            Assert.Equal( "1111",
                          actual[0]
                              .Value );
            Assert.Equal( "11",
                          actual[1]
                              .Value );
            Assert.Equal( "111",
                          actual[2]
                              .Value );
            Assert.Equal( "1",
                          actual[3]
                              .Value );
        }

        /// <summary>
        ///     Search BottomUp all level
        /// </summary>
        [Fact]
        public void FindNodeTest3()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" )
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" )
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindNode( x => x.Value == "root" || x.Value.StartsWith( "1", StringComparison.Ordinal ) || x.Value.StartsWith( "b", StringComparison.Ordinal ) )
                               .ToList();
            Assert.Equal( 7, actual.Count );
            Assert.Equal( "1111",
                          actual[0]
                              .Value );
            Assert.Equal( "b1",
                          actual[1]
                              .Value );
            Assert.Equal( "11",
                          actual[2]
                              .Value );
            Assert.Equal( "111",
                          actual[3]
                              .Value );
            Assert.Equal( "b",
                          actual[4]
                              .Value );
            Assert.Equal( "1",
                          actual[5]
                              .Value );
            Assert.Equal( "root",
                          actual[6]
                              .Value );
        }

        /// <summary>
        ///     Search TopDown only top level
        /// </summary>
        [Fact]
        public void FindValueTest()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" )
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" )
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindValue( x => x.Value.StartsWith( "1", StringComparison.Ordinal ) )
                               .ToList();
            Assert.Equal( 4, actual.Count );
            Assert.Equal( "1", actual[0] );
            Assert.Equal( "111", actual[1] );
            Assert.Equal( "11", actual[2] );
            Assert.Equal( "1111", actual[3] );
        }

        /// <summary>
        ///     Search TopDown all level
        /// </summary>
        [Fact]
        public void FindValueTest1()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" )
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" )
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.TopDown;

            var actual = target.FindValue( x => x.Value == "root" || x.Value.StartsWith( "1", StringComparison.Ordinal ) || x.Value.StartsWith( "b", StringComparison.Ordinal ) )
                               .ToList();
            Assert.Equal( 7, actual.Count );
            Assert.Equal( "root", actual[0] );
            Assert.Equal( "1", actual[1] );
            Assert.Equal( "b", actual[2] );
            Assert.Equal( "111", actual[3] );
            Assert.Equal( "11", actual[4] );
            Assert.Equal( "b1", actual[5] );
            Assert.Equal( "1111", actual[6] );
        }

        /// <summary>
        ///     Search BottomUp only top level
        /// </summary>
        [Fact]
        public void FindValueTest2()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" )
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" )
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindValue( x => x.Value.StartsWith( "1", StringComparison.Ordinal ) )
                               .ToList();
            Assert.Equal( 4, actual.Count );
            Assert.Equal( "1111", actual[0] );
            Assert.Equal( "11", actual[1] );
            Assert.Equal( "111", actual[2] );
            Assert.Equal( "1", actual[3] );
        }

        /// <summary>
        ///     Search BottomUp all level
        /// </summary>
        [Fact]
        public void FindValueTest3()
        {
            var target = new TreeNode<String>( "root" )
            {
                new TreeNode<String>( "1" ),
                new TreeNode<String>( "2" )
                {
                    new TreeNode<String>( "a" ),
                    new TreeNode<String>( "b" ),
                    new TreeNode<String>( "c" ),
                    new TreeNode<String>( "111" )
                },
                new TreeNode<String>( "3" ),
                new TreeNode<String>( "11" ),
                new TreeNode<String>( "21" )
                {
                    new TreeNode<String>( "a1" ),
                    new TreeNode<String>( "b1" ),
                    new TreeNode<String>( "c1" ),
                    new TreeNode<String>( "1111" )
                },
                new TreeNode<String>( "31" )
            };
            target.SearchTraversalDirection = TreeTraversalDirection.BottomUp;

            var actual = target.FindValue( x => x.Value == "root" || x.Value.StartsWith( "1", StringComparison.Ordinal ) || x.Value.StartsWith( "b", StringComparison.Ordinal ) )
                               .ToList();
            Assert.Equal( 7, actual.Count );
            Assert.Equal( "1111", actual[0] );
            Assert.Equal( "b1", actual[1] );
            Assert.Equal( "11", actual[2] );
            Assert.Equal( "111", actual[3] );
            Assert.Equal( "b", actual[4] );
            Assert.Equal( "1", actual[5] );
            Assert.Equal( "root", actual[6] );
        }

        [Fact]
        public void GetEnumeratorTest()
        {
            var target = new TreeNode<String>( "root" ) { "1", "2", "3" };
            var actual = new List<ITreeNode<String>>();

// ReSharper disable once LoopCanBeConvertedToQuery
            foreach ( var node in target )
                actual.Add( node );

            Assert.Equal( 4, actual.Count );
            Assert.Equal( "root",
                          actual[0]
                              .Value );
            Assert.Equal( "1",
                          actual[1]
                              .Value );
            Assert.Equal( "2",
                          actual[2]
                              .Value );
            Assert.Equal( "3",
                          actual[3]
                              .Value );
        }

        [Fact]
        public void GetEnumeratorTest1()
        {
            var target = new TreeNode<String>( "root" ) { "1", "2", "3" };
            target.TraversalDirection = TreeTraversalDirection.BottomUp;
            var actual = new List<ITreeNode<String>>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach ( var node in target )
                actual.Add( node );

            Assert.Equal( 4, actual.Count );
            Assert.Equal( "3",
                          actual[0]
                              .Value );
            Assert.Equal( "2",
                          actual[1]
                              .Value );
            Assert.Equal( "1",
                          actual[2]
                              .Value );
            Assert.Equal( "root",
                          actual[3]
                              .Value );
        }

        [Fact]
        public void GetEnumeratorTest2()
        {
            var target = new TreeNode<String>( "root" )
            {
                "1",
                new TreeNode<String>( "2" )
                {
                    "3",
                    "4"
                },
                "5"
            };
            var actual = new List<ITreeNode<String>>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach ( var node in target )
                actual.Add( node );

            Assert.Equal( 6, actual.Count );
            Assert.Equal( "root",
                          actual[0]
                              .Value );
            Assert.Equal( "1",
                          actual[1]
                              .Value );
            Assert.Equal( "2",
                          actual[2]
                              .Value );
            Assert.Equal( "3",
                          actual[3]
                              .Value );
            Assert.Equal( "4",
                          actual[4]
                              .Value );
            Assert.Equal( "5",
                          actual[5]
                              .Value );
        }

        [Fact]
        public void GetEnumeratorTest3()
        {
            var target = new TreeNode<String>( "root" )
            {
                "1",
                new TreeNode<String>( "2" )
                {
                    "3",
                    "4"
                },
                "5"
            };
            target.TraversalDirection = TreeTraversalDirection.BottomUp;
            var actual = new List<ITreeNode<String>>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach ( var node in target )
                actual.Add( node );

            Assert.Equal( 6, actual.Count );
            Assert.Equal( "5",
                          actual[0]
                              .Value );
            Assert.Equal( "4",
                          actual[1]
                              .Value );
            Assert.Equal( "3",
                          actual[2]
                              .Value );
            Assert.Equal( "2",
                          actual[3]
                              .Value );
            Assert.Equal( "1",
                          actual[4]
                              .Value );
            Assert.Equal( "root",
                          actual[5]
                              .Value );
        }

        [Fact]
        public void GetEnumeratorTest4()
        {
            var target = new TreeNode<String>( "root" )
            {
                "1",
                new TreeNode<String>( "2" )
                {
                    "3",
                    new TreeNode<String>( "4" )
                    {
                        "5"
                    }
                },
                "6"
            };
            var actual = new List<ITreeNode<String>>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach ( var node in target )
                actual.Add( node );

            Assert.Equal( 7, actual.Count );
            Assert.Equal( "root",
                          actual[0]
                              .Value );
            Assert.Equal( "1",
                          actual[1]
                              .Value );
            Assert.Equal( "2",
                          actual[2]
                              .Value );
            Assert.Equal( "3",
                          actual[3]
                              .Value );
            Assert.Equal( "4",
                          actual[4]
                              .Value );
            Assert.Equal( "5",
                          actual[5]
                              .Value );
            Assert.Equal( "6",
                          actual[6]
                              .Value );
        }

        [Fact]
        public void GetEnumeratorTest5()
        {
            var target = new TreeNode<String>( "root" )
            {
                "1",
                new TreeNode<String>( "2" )
                {
                    "3",
                    new TreeNode<String>( "4" )
                    {
                        "5"
                    }
                },
                "6"
            };
            target.TraversalDirection = TreeTraversalDirection.BottomUp;
            var actual = new List<ITreeNode<String>>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach ( var node in target )
                actual.Add( node );

            Assert.Equal( 7, actual.Count );
            Assert.Equal( "6",
                          actual[0]
                              .Value );
            Assert.Equal( "5",
                          actual[1]
                              .Value );
            Assert.Equal( "4",
                          actual[2]
                              .Value );
            Assert.Equal( "3",
                          actual[3]
                              .Value );
            Assert.Equal( "2",
                          actual[4]
                              .Value );
            Assert.Equal( "1",
                          actual[5]
                              .Value );
            Assert.Equal( "root",
                          actual[6]
                              .Value );
        }

        [Fact]
        public void GetEnumeratorTest6()
        {
            var target = new TreeNode<String>( "root" )
            {
                "1",
                new TreeNode<String>( "2" )
                {
                    "3",
                    new TreeNode<String>( "4" )
                    {
                        "5"
                    }
                },
                "6"
            };
            var actual = target.GetEnumerator();
            actual.Should()
                  .NotBe( null );
            actual.Dispose();
        }

        [Fact]
        public void GetEnumeratorTest7()
        {
            var target = new TreeNode<String>( "root" ) { "1", "2", "3" };
            var actual = new List<ITreeNode<String>>();

            var enumerator = ( (IEnumerable) target ).GetEnumerator();
            while ( enumerator.MoveNext() )
                actual.Add( enumerator.Current as ITreeNode<String> );

            Assert.Equal( 4, actual.Count );
            Assert.Equal( "root",
                          actual[0]
                              .Value );
            Assert.Equal( "1",
                          actual[1]
                              .Value );
            Assert.Equal( "2",
                          actual[2]
                              .Value );
            Assert.Equal( "3",
                          actual[3]
                              .Value );
        }

        [Fact]
        public void GetEnumeratorTest8()
        {
            var target = new TreeNode<String>( "root" ) { "1", "2", "3", new AlternativeTreeNode<String>() };
            target.TraversalDirection = TreeTraversalDirection.TopDown;
            // ReSharper disable once CollectionNeverQueried.Local
            var actual = new List<ITreeNode<String>>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            Action test = () =>
            {
                foreach ( var node in target )
                    actual.Add( node );
            };

            test.ShouldThrow<NotSupportedException>();
        }

        [Fact]
        public void GetEnumeratorTest9()
        {
            var target = new TreeNode<String>( "root" ) { "1", "2", "3", new AlternativeTreeNode<String>() };
            target.TraversalDirection = TreeTraversalDirection.BottomUp;
            // ReSharper disable once CollectionNeverQueried.Local
            var actual = new List<ITreeNode<String>>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            Action test = () =>
            {
                foreach ( var node in target )
                    actual.Add( node );
            };

            test.ShouldThrow<NotSupportedException>();
        }

        [Fact]
        public void HasChildrenTest()
        {
            var target = new TreeNode<String>( "root" );
            Assert.False( target.HasChildren );

            var item1 = new TreeNode<String>( "1" );
            Assert.False( item1.HasChildren );
            target.Add( item1 );
            Assert.False( item1.HasChildren );
            Assert.True( target.HasChildren );

            var item2 = new TreeNode<String>( "1" );
            Assert.False( item2.HasChildren );
            Assert.Equal( 0, item2.Depth );
            item1.Add( item2 );
            Assert.Equal( 2, item2.Depth );
            Assert.False( item2.HasChildren );
            Assert.True( item1.HasChildren );
            Assert.True( target.HasChildren );
        }

        [Fact]
        public void HasChildrenTest1()
        {
            var target = new TreeNode<String>( "root" ) { Children = null };
            Assert.False( target.HasChildren );
        }

        [Fact]
        public void HasParentTest()
        {
            var target = new TreeNode<String>( "root" );
            Assert.False( target.HasParent );

            var item1 = new TreeNode<String>( "1" );
            Assert.False( item1.HasParent );
            target.Add( item1 );
            Assert.True( item1.HasParent );

            var item2 = new TreeNode<String>( "1" );
            Assert.False( item2.HasParent );
            item1.Add( item2 );
            Assert.True( item2.HasParent );
        }

        /// <summary>
        ///     Check if added as child to parent.
        /// </summary>
        [Fact]
        public void ParentTest()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNode<String> { Parent = parent };
            Assert.Same( parent, target.Parent );
            Assert.True( parent.Children.Contains( target ) );
        }

        /// <summary>
        ///     Check if added as child to new parent and removed from old parent.
        /// </summary>
        [Fact]
        public void ParentTest1()
        {
            var parent = new TreeNode<String>();
            var exParent = new TreeNode<String>();

            var target = new TreeNode<String>( exParent );
            Assert.Same( exParent, target.Parent );

            target.Parent = parent;
            Assert.Same( parent, target.Parent );
            Assert.True( parent.Children.Contains( target ) );
            Assert.False( exParent.Children.Contains( target ) );
        }

        /// <summary>
        ///     Check if added as child to parent and if children are getting updated.
        /// </summary>
        [Fact]
        public void ParentTest2()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNode<String> { "Item1" };
            Assert.Same( target,
                         target.Children.First()
                               .Parent );
            Assert.Equal( 1,
                          target.Children.First()
                                .Depth );

            target.Parent = parent;
            Assert.Same( parent, target.Parent );
            Assert.True( parent.Children.Contains( target ) );
            Assert.Same( target,
                         target.Children.First()
                               .Parent );
            Assert.Equal( 2,
                          target.Children.First()
                                .Depth );
        }

        /// <summary>
        ///     Remove item from node1 and add it to node2
        /// </summary>
        [Fact]
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

            Assert.Equal( 2, node1.Children.Count );
            node1.Children.ForEach( x => Assert.Same( node1, x.Parent ) );

            Assert.Equal( 2, node2.Children.Count );
            node2.Children.ForEach( x => Assert.Same( node2, x.Parent ) );

            var child = node1.Children.First();
            node2.Add( child );

            node1.Children.Remove( child );

            Assert.Equal( 1, node1.Children.Count );
            node1.Children.ForEach( x => Assert.Same( node1, x.Parent ) );

            Assert.Equal( 3, node2.Children.Count );
            node2.Children.ForEach( x => Assert.Same( node2, x.Parent ) );
        }

        [Fact]
        public void RootTest()
        {
            var target = new TreeNode<String>();
            Assert.Same( target, target.Root );
        }

        [Fact]
        public void RootTest1()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNode<String>( parent );
            Assert.Same( parent, target.Root );
        }

        [Fact]
        public void SearchTraversalDirectionTest()
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

        [Fact]
        public void SetAllDirectionsTest()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var target = new TreeNode<String>( "root" )
            {
                "1",
                "2",
                "3"
            };

            target.SetAllDirections( TreeTraversalDirection.BottomUp );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.AncestorsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DescendantsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.DisposeTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.SearchTraversalDirection );
            Assert.Equal( TreeTraversalDirection.BottomUp, target.TraversalDirection );

            target.Children.ForEach( x =>
            {
                Assert.Equal( TreeTraversalDirection.BottomUp, x.AncestorsTraversalDirection );
                Assert.Equal( TreeTraversalDirection.BottomUp, x.DescendantsTraversalDirection );
                Assert.Equal( TreeTraversalDirection.BottomUp, x.DisposeTraversalDirection );
                Assert.Equal( TreeTraversalDirection.BottomUp, x.SearchTraversalDirection );
                Assert.Equal( TreeTraversalDirection.BottomUp, x.TraversalDirection );
            } );

            target.SetAllDirections( TreeTraversalDirection.TopDown );
            Assert.Equal( TreeTraversalDirection.TopDown, target.AncestorsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.DescendantsTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.DisposeTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.SearchTraversalDirection );
            Assert.Equal( TreeTraversalDirection.TopDown, target.TraversalDirection );

            target.Children.ForEach( x =>
            {
                Assert.Equal( TreeTraversalDirection.TopDown, x.AncestorsTraversalDirection );
                Assert.Equal( TreeTraversalDirection.TopDown, x.DescendantsTraversalDirection );
                Assert.Equal( TreeTraversalDirection.TopDown, x.DisposeTraversalDirection );
                Assert.Equal( TreeTraversalDirection.TopDown, x.SearchTraversalDirection );
                Assert.Equal( TreeTraversalDirection.TopDown, x.TraversalDirection );
            } );
        }

        [Fact]
        public void SetParentTest()
        {
            var targetA = new TreeNode<String>( "a" );
            var node1 = new TreeNode<String>( "1" );

            var targetB = new TreeNode<String>( "b" );
            var node2 = new TreeNode<String>( "2" );

            //Add 1 to A
            node1.SetParent( targetA );
            Assert.Same( node1.Parent, targetA );

            //Add 1 to A again
            node1.SetParent( targetA );
            Assert.Same( node1.Parent, targetA );

            //Add 2 to B
            node2.SetParent( targetB );
            Assert.Same( node2.Parent, targetB );

            //Add 2 to B again
            node2.SetParent( targetB );
            Assert.Same( node2.Parent, targetB );

            //Add 1 to B
            node1.SetParent( targetB );
            Assert.Same( node1.Parent, targetB );
            Assert.Equal( 0, targetA.Children.Count );
        }

        [Fact]
        public void SetParentTest1()
        {
            var targetA = new TreeNode<String>( "a" )
            {
                Children = null
            };
            var node1 = new TreeNode<String>( "1" );

            //Add 1 to A
            node1.SetParent( targetA );
            Assert.Same( node1.Parent, targetA );
        }

        [Fact]
        public void ToStringTest()
        {
            var target = new TreeNode<String>( "1" );
            var actual = target.ToString();
            Assert.Equal( "[Depth: 0 - Value: '1', Children: 0]", actual );
        }

        [Fact]
        public void ToStringTest1()
        {
            var target = new TreeNode<String>( "1" ) { "1", "2" };
            var node = new TreeNode<String>( "a" );
            target.Add( node );
            var actual = node.ToString();
            Assert.Equal( "    [Depth: 1 - Value: 'a', Children: 0]", actual );
        }

        [Fact]
        public void TraversalDirectionTest()
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
            target.TraversalDirection = expected;
            AssertTraversalDirection( expected, target );
        }

        /// <summary>
        ///     Normal value
        /// </summary>
        [Fact]
        public void ValueTest()
        {
            var target = new TreeNode<String>();
            var expected = RandomValueEx.GetRandomString();
            target.Value = expected;
            Assert.Equal( expected, target.Value );
        }

        /// <summary>
        ///     Value implementing <see cref="ITreeNodeAware{T}" />.
        /// </summary>
        [Fact]
        public void ValueTest1()
        {
            var target = new TreeNode<TestTreeNodeItem>();
            var expected = new TestTreeNodeItem();
            Assert.Null( expected.Node );
            target.Value = expected;
            Assert.Same( expected, target.Value );
            Assert.Same( target, expected.Node );
        }

        /// <summary>
        ///     Value implementing <see cref="ITreeNodeAware{T}" />.
        ///     Reset value to check if node gets set to null.
        /// </summary>
        [Fact]
        public void ValueTest2()
        {
            var target = new TreeNode<TestTreeNodeItem>();
            var expected = new TestTreeNodeItem();
            Assert.Null( expected.Node );
            target.Value = expected;
            Assert.Same( expected, target.Value );
            Assert.Same( target, expected.Node );

            var newValue = new TestTreeNodeItem();
            target.Value = newValue;
            Assert.Same( newValue, target.Value );
            Assert.Same( target, newValue.Node );

            //Check if node is null.
            Assert.Null( expected.Node );
        }

        // ReSharper disable once UnusedParameter.Local
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private void AssertAncestorsTraversalDirection<T>( TreeTraversalDirection expected, ITreeNode<T> node )
        {
            Assert.Equal( expected, node.AncestorsTraversalDirection );
            node.Children.ForEach( x => AssertAncestorsTraversalDirection( expected, x ) );
        }

        // ReSharper disable once UnusedParameter.Local
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private void AssertDescendantsTraversalDirection<T>( TreeTraversalDirection expected, ITreeNode<T> node )
        {
            Assert.Equal( expected, node.DescendantsTraversalDirection );
            node.Children.ForEach( x => AssertDescendantsTraversalDirection( expected, x ) );
        }

        // ReSharper disable once UnusedParameter.Local
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private void AssertDisposeTraversalDirection<T>( TreeTraversalDirection expected, ITreeNode<T> node )
        {
            Assert.Equal( expected, node.DisposeTraversalDirection );
            node.Children.ForEach( x => AssertDisposeTraversalDirection( expected, x ) );
        }

        // ReSharper disable once UnusedParameter.Local
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private void AssertSearchTraversalDirection<T>( TreeTraversalDirection expected, ITreeNode<T> node )
        {
            Assert.Equal( expected, node.SearchTraversalDirection );
            node.Children.ForEach( x => AssertSearchTraversalDirection( expected, x ) );
        }

        // ReSharper disable once UnusedParameter.Local
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private void AssertTraversalDirection<T>( TreeTraversalDirection expected, ITreeNode<T> node )
        {
            Assert.Equal( expected, node.TraversalDirection );
            node.Children.ForEach( x => AssertTraversalDirection( expected, x ) );
        }

        #region Nested Types

        private class AlternativeTreeNode<T> : ITreeNode<T>
        {
            #region Implementation of IDisposable

            /// <summary>
            ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                throw new NotImplementedException();
            }

            #endregion

            #region Implementation of IEnumerable

            /// <summary>
            ///     Returns an enumerator that iterates through a collection.
            /// </summary>
            /// <returns>
            ///     An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
            /// </returns>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            #endregion

            #region Implementation of IEnumerable<out ITreeNode<T>>

            /// <summary>
            ///     Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>
            ///     A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
            /// </returns>
            public IEnumerator<ITreeNode<T>> GetEnumerator() => throw new NotImplementedException();

            #endregion

            #region Implementation of ITreeNode<T>

            /// <summary>
            ///     Gets or sets the value of the node.
            /// </summary>
            /// <value>The value of the node.</value>
            public T Value { get; set; }

            /// <summary>
            ///     Gets or sets the dispose traversal direction.
            /// </summary>
            /// <value>The dispose traversal direction.</value>
            public TreeTraversalDirection DisposeTraversalDirection { get; set; }

            /// <summary>
            ///     Gets or sets the search traversal direction.
            /// </summary>
            /// <value>The search traversal direction.</value>
            public TreeTraversalDirection SearchTraversalDirection { get; set; }

            /// <summary>
            ///     Gets or sets the ancestors traversal direction.
            /// </summary>
            /// <value>The ancestors traversal direction.</value>
            public TreeTraversalDirection AncestorsTraversalDirection { get; set; }

            /// <summary>
            ///     Gets or sets the descendants traversal direction.
            /// </summary>
            /// <value>The descendants traversal direction.</value>
            public TreeTraversalDirection DescendantsTraversalDirection { get; set; }

            /// <summary>
            ///     Gets or sets the traversal direction used to enumerate the nodes.
            /// </summary>
            /// <value>The traversal direction used to enumerate the nodes.</value>
            public TreeTraversalDirection TraversalDirection { get; set; }

            /// <summary>
            ///     Gets or sets the parent of the node.
            /// </summary>
            /// <value>The parent of the node.</value>
            public ITreeNode<T> Parent { get; set; }

            /// <summary>
            ///     Gets the children of the node.
            /// </summary>
            /// <value>The children of the node.</value>
            public ITreeNodeCollection<T> Children { get; set; }

            /// <summary>
            ///     Gets the root of the tree.
            /// </summary>
            /// <value>The root of the tree.</value>
            public ITreeNode<T> Root { get; } = new TreeNode<T>();

            /// <summary>
            ///     Gets the depth of the node.
            /// </summary>
            /// <value>The depth of the node.</value>
            public Int32 Depth { get; } = 0;

            /// <summary>
            ///     Gets a value indicating whether the node has any children or not.
            /// </summary>
            /// <value>A value indicating whether the node has any children or not.</value>
            public Boolean HasChildren { get; } = false;

            /// <summary>
            ///     Gets a value indicating whether the node has a parent or not.
            /// </summary>
            /// <value>A value indicating whether the node has a parent or not.</value>
            public Boolean HasParent { get; } = false;

            /// <summary>
            ///     Gets an enumeration of all tree nodes which are below the current node in the tree.
            /// </summary>
            /// <value>An enumeration of all tree nodes which are below the current node in the tree.</value>
            public IEnumerable<ITreeNode<T>> Descendants { get; } = new List<ITreeNode<T>>();

            /// <summary>
            ///     Gets the values which matches the given predicate.
            /// </summary>
            /// <remarks>
            ///     Starts the search at the current tree node and traverses down the tree (Direction based on
            ///     <see cref="SearchTraversalDirection" />).
            /// </remarks>
            /// <param name="predicate">The predicate.</param>
            /// <returns>Returns the values which matches the given predicate.</returns>
            public IEnumerable<T> FindValue( Func<ITreeNode<T>, Boolean> predicate )
                => throw new NotImplementedException();

            /// <summary>
            ///     Gets the nodes which matches the given predicate.
            /// </summary>
            /// <remarks>
            ///     Starts the search at the current tree node and traverses down the tree (Direction based on
            ///     <see cref="SearchTraversalDirection" />).
            /// </remarks>
            /// <param name="predicate">The predicate.</param>
            /// <returns>Returns the nodes which matches the given predicate.</returns>
            public IEnumerable<ITreeNode<T>> FindNode( Func<ITreeNode<T>, Boolean> predicate )
                => throw new NotImplementedException();

            /// <summary>
            ///     Gets the nodes with the given value.
            /// </summary>
            /// <param name="value">The value to search.</param>
            /// <returns>Returns the nodes with the given value.</returns>
            public IEnumerable<ITreeNode<T>> FindNode( T value )
                => throw new NotImplementedException();

            /// <summary>
            ///     Adds the given value as child to the node.
            /// </summary>
            /// <param name="value">The value to add.</param>
            /// <returns>Returns the added node.</returns>
            public ITreeNode<T> Add( T value )
                => throw new NotImplementedException();

            /// <summary>
            ///     Adds the given node as child to the node, if it is not already a child of the node.
            /// </summary>
            /// <param name="node">The node to add.</param>
            /// <returns>Returns the added node.</returns>
            public ITreeNode<T> Add( ITreeNode<T> node )
                => throw new NotImplementedException();

            /// <summary>
            ///     Sets the parent of the tree node.
            /// </summary>
            /// <param name="parent">The new parent.</param>
            /// <param name="attacheToNewParent">
            ///     A value determining whether the node should add it self to the children of the new parent
            ///     or not.
            /// </param>
            /// <remarks>
            ///     TODO: add test for detachFromOldParent
            /// </remarks>
            /// <param name="detachFromOldParent">A value indicating whether the node should detach itself from it's old parent or not.</param>
            public void SetParent( ITreeNode<T> parent, Boolean attacheToNewParent = true, Boolean detachFromOldParent = true )
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Sets all directions (<see cref="DisposeTraversalDirection" />, <see cref="SearchTraversalDirection" />,
            ///     <see cref="AncestorsTraversalDirection" />, <see cref="DescendantsTraversalDirection" />).
            /// </summary>
            /// <param name="direction">The new direction.</param>
            public void SetAllDirections( TreeTraversalDirection direction )
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        private class DisposeTestHelper : IDisposable

        {
            #region Properties

            public String Value { get; set; }
            public Action<String> DisposeAction { get; set; }

            #endregion

            #region Implementation of IDisposable

            /// <summary>
            ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose() => DisposeAction?.Invoke( Value );

            #endregion
        }

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

        #endregion
    }
}