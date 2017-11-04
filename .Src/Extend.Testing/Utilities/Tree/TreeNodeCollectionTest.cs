#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class TreeNodeCollectionTest
    {
        /// <summary>
        ///     Update parent
        /// </summary>
        [Fact]
        public void AddNodeTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item );

            Assert.Contains( item, target );
            Assert.Single( target );

            Assert.Same( parent, item.Parent );
            Assert.Equal( 1, item.Depth );
        }

        /// <summary>
        ///     Don't update parent
        /// </summary>
        [Fact]
        public void AddNodeTest1()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item, false );

            Assert.Contains( item, target );
            Assert.Single( target );

            Assert.Null( item.Parent );
            Assert.Equal( 0, item.Depth );
        }

        /// <summary>
        ///     Don't update parent, item has already a parent
        /// </summary>
        [Fact]
        public void AddNodeTest2()
        {
            var itemParent = new TreeNode<String>();
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>( itemParent );
            target.Add( item, false );

            Assert.Contains( item, target );
            Assert.Single( target );

            Assert.Same( itemParent, item.Parent );
            Assert.Equal( 1, item.Depth );
        }

        /// <summary>
        ///     Try add same item twice.
        /// </summary>
        [Fact]
        public void AddNodeTest3()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item );
            target.Add( item );

            Assert.Contains( item, target );
            Assert.Single( target );

            Assert.Same( parent, item.Parent );
            Assert.Equal( 1, item.Depth );
        }

        [Fact]
        public void AddTestNullCheck()
        {
            var parent = new TreeNode<String>();
            // ReSharper disable once CollectionNeverQueried.Local
            var target = new TreeNodeCollection<String>( parent );

            ITreeNode<String> item = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => target.Add( item );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddValueTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var expected = RandomValueEx.GetRandomString();
            var actual = target.Add( expected );

            Assert.Contains( actual, target );
            Assert.Single( target );

            Assert.Same( parent, actual.Parent );
            Assert.Equal( actual.Value, expected );
            Assert.Equal( 1, actual.Depth );
        }

        [Fact]
        public void AddValueTest1()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            String expected = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = target.Add( expected );

            Assert.Contains( actual, target );
            Assert.Single( target );

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Equal( actual.Value, expected );
            Assert.Same( parent, actual.Parent );
            Assert.Equal( 1, actual.Depth );
        }

        /// <summary>
        ///     Add same value twice
        /// </summary>
        [Fact]
        public void AddValueTest2()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var expected = RandomValueEx.GetRandomString();
            var actual = target.Add( expected );
            var actual1 = target.Add( expected );

            Assert.Equal( 2, target.Count );
            Assert.Contains( actual, target );
            Assert.Contains( actual1, target );

            Assert.Same( parent, actual.Parent );
            Assert.Equal( actual.Value, expected );
            Assert.Equal( 1, actual.Depth );

            Assert.Same( parent, actual1.Parent );
            Assert.Equal( actual1.Value, expected );
            Assert.Equal( 1, actual1.Depth );
        }

        [Fact]
        public void CollectionInitTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent )
            {
                "test1",
                new TreeNode<String>( "test2" ),
                "test3",
                new TreeNode<String>( "test4" )
            };

            Assert.Same( parent, target.Parent );
            Assert.Same( parent,
                         target[0]
                             .Parent );
            Assert.Same( parent,
                         target[1]
                             .Parent );
            Assert.Same( parent,
                         target[2]
                             .Parent );
            Assert.Same( parent,
                         target[3]
                             .Parent );

            Assert.Same( "test1",
                         target[0]
                             .Value );
            Assert.Same( "test2",
                         target[1]
                             .Value );
            Assert.Same( "test3",
                         target[2]
                             .Value );
            Assert.Same( "test4",
                         target[3]
                             .Value );
        }

        [Fact]
        public void CtorTest()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNodeCollection<String>( parent );
            Assert.Same( parent, target.Parent );
        }

        [Fact]
        public void DetachFromParentTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            target.DetachFromParent();
            Assert.Null( target.Parent );
        }

        [Fact]
        public void DetachFromParentTest1()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNodeCollection<String>( parent ) { "1", "2", "3" };
            Assert.Equal( 3, target.Count );
            target.ForEach( x => Assert.Same( parent, x.Parent ) );

            target.DetachFromParent();
            Assert.Null( target.Parent );
            target.ForEach( x => Assert.Null( x.Parent ) );
        }

        [Fact]
        public void IterationTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent )
            {
                "test1",
                new TreeNode<String>( "test2" ),
                "test3",
                new TreeNode<String>( "test4" )
            };

            target.ForEach( ( x, i ) => Assert.Equal( "test" + ( i + 1 ), x.Value ) );
        }

        [Fact]
        public void ParentTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            Assert.Same( parent, target.Parent );
        }

        [Fact]
        public void ParentTest1()
        {
            var target = new TreeNodeCollection<String>( null );

            Assert.Null( target.Parent );
        }

        [Fact]
        public void ParentTest2()
        {
            var target = new TreeNodeCollection<String>( null );
            Assert.Null( target.Parent );

            var parent = new TreeNode<String>();
            target.Parent = parent;
            Assert.Same( parent, target.Parent );
        }

        [Fact]
        public void ParentTest3()
        {
            var target = new TreeNodeCollection<String>( null ) { "1", "2" };
            Assert.Null( target.Parent );
            target.ForEach( x => Assert.Null( x.Parent ) );

            var parent = new TreeNode<String>();
            target.Parent = parent;
            Assert.Same( parent, target.Parent );
            target.ForEach( x => Assert.Same( parent, x.Parent ) );
        }

        [Fact]
        public void ParentTest4()
        {
            var target = new TreeNodeCollection<String>( null ) { "1", "2" };
            Assert.Null( target.Parent );
            target.ForEach( x => Assert.Null( x.Parent ) );

            var parent = new TreeNode<String>();
            target.Parent = parent;
            Assert.Same( parent, target.Parent );
            target.ForEach( x => Assert.Same( parent, x.Parent ) );

            target.Add( "3" );
            target.Add( "4" );
            target.ForEach( x => Assert.Same( parent, x.Parent ) );

            var newParent = new TreeNode<String>();
            target.Parent = newParent;

            Assert.Same( newParent, target.Parent );
            target.ForEach( x => Assert.Same( newParent, x.Parent ) );
        }

        [Fact]
        public void ParentTest5()
        {
            var target = new TreeNodeCollection<String>( null ) { "1", "2" };
            Assert.Null( target.Parent );
            target.ForEach( x => Assert.Null( x.Parent ) );

            var parent = new TreeNode<String>();
            target.Parent = parent;
            Assert.Same( parent, target.Parent );
            target.ForEach( x => Assert.Same( parent, x.Parent ) );

            target.Add( "3" );
            target.Add( "4" );
            target.ForEach( x => Assert.Same( parent, x.Parent ) );

            ITreeNode<String> newParent = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            target.Parent = newParent;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Same( newParent, target.Parent );
            // ReSharper disable once ExpressionIsAlwaysNull
            target.ForEach( x => Assert.Same( newParent, x.Parent ) );
        }

        [Fact]
        public void ParentTest6()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent ) { Parent = null };

            Assert.Null( target.Parent );
        }

        [Fact]
        public void ParentTest7()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent )
            {
                Parent = parent
            };

            Assert.Same( parent, target.Parent );
        }

        /// <summary>
        ///     Set parent.
        /// </summary>
        [Fact]
        public void RemoveNodeTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item );

            var item1 = new TreeNode<String>();
            target.Add( item1 );

            var result = target.Remove( item );
            Assert.True( result );
            Assert.Null( item.Parent );

#pragma warning disable xUnit2017
            Assert.False( target.Contains( item ) );
#pragma warning restore xUnit2017

            result = target.Remove( item1 );
            Assert.True( result );
            Assert.Null( item1.Parent );
            Assert.DoesNotContain( item1, target );

            Assert.Empty( target );
        }

        /// <summary>
        ///     Item is not in collection
        /// </summary>
        [Fact]
        public void RemoveNodeTest1()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String> { Parent = parent };

            var result = target.Remove( item );
            Assert.False( result );
            Assert.Same( parent, item.Parent );
            Assert.DoesNotContain( item, target );
        }

        /// <summary>
        ///     Don't set parent.
        /// </summary>
        [Fact]
        public void RemoveNodeTest2()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item );

            var item1 = new TreeNode<String>();
            target.Add( item1 );

            var result = target.Remove( item, false );
            Assert.True( result );
            Assert.Same( parent, item.Parent );

#pragma warning disable xUnit2017
            Assert.False( target.Contains( item ) );
#pragma warning restore xUnit2017

            result = target.Remove( item1, false );
            Assert.True( result );
            Assert.Same( parent, item1.Parent );
            Assert.DoesNotContain( item1, target );

            Assert.Empty( target );
        }

        [Fact]
        public void RemoveNodeTestNullCheck()
        {
            var parent = new TreeNode<String>();
            // ReSharper disable once CollectionNeverQueried.Local
            var target = new TreeNodeCollection<String>( parent );

            ITreeNode<String> item = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => target.Remove( item );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToStringTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var actual = target.ToString();
            Assert.Equal( "[Depth: 0 - Value: '[NULL]', Children: 0]", actual );
        }

        [Fact]
        public void ToStringTest1()
        {
            var target = new TreeNodeCollection<String>( null );

            var actual = target.ToString();
            Assert.Equal( "[Items Count: 0]", actual );
        }

        [Fact]
        public void ToStringTest2()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent ) { "1", "2" };

            var actual = target.ToString();
            Assert.Equal( "[Depth: 0 - Value: '[NULL]', Children: 2]\r\n    [Depth: 1 - Value: '1', Children: 0]\r\n    [Depth: 1 - Value: '2', Children: 0]", actual );
        }

        [Fact]
        public void ToStringTest3()
        {
            var target = new TreeNodeCollection<String>( null ) { "1", "2", "3" };

            var actual = target.ToString();
            Assert.Equal( "[Items Count: 3]", actual );
        }

        [Fact]
        public void ToStringTest4()
        {
            var target = new TreeNodeCollection<String>( new TreeNode<String>( "Root" ) )
            {
                new TreeNode<String>
                {
                    Value = "1",
                    Children =
                    {
                        new TreeNode<String>
                        {
                            Value = "A",
                            Children = { "a", "b", "c" }
                        }
                    }
                },
                new TreeNode<String>
                {
                    Value = "2"
                },
                new TreeNode<String>
                {
                    Value = "3",
                    Children =
                    {
                        new TreeNode<String>
                        {
                            Value = "B",
                            Children = { "aa", "bb", "cc" }
                        }
                    }
                }
            };

            var actual = target.ToString();
            Assert.Equal(
                "[Depth: 0 - Value: 'Root', Children: 3]\r\n    [Depth: 1 - Value: '1', Children: 1]\r\n        [Depth: 2 - Value: 'A', Children: 3]\r\n            [Depth: 3 - Value: 'a', Children: 0]\r\n            [Depth: 3 - Value: 'b', Children: 0]\r\n            [Depth: 3 - Value: 'c', Children: 0]\r\n    [Depth: 1 - Value: '2', Children: 0]\r\n    [Depth: 1 - Value: '3', Children: 1]\r\n        [Depth: 2 - Value: 'B', Children: 3]\r\n            [Depth: 3 - Value: 'aa', Children: 0]\r\n            [Depth: 3 - Value: 'bb', Children: 0]\r\n            [Depth: 3 - Value: 'cc', Children: 0]",
                actual );
        }
    }
}