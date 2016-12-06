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
        public void AddNodeTest()
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
        public void AddNodeTest1()
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
        public void AddNodeTest2()
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
        public void AddNodeTest3()
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

        [Test]
        public void AddValueTest()
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
        public void AddValueTest1()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            String expected = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = target.Add( expected );

            Assert.IsTrue( target.Contains( actual ) );
            Assert.AreEqual( 1, target.Count );

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.AreEqual( actual.Value, expected );
            Assert.AreSame( parent, actual.Parent );
            Assert.AreEqual( 1, actual.Depth );
        }

        /// <summary>
        ///     Add same value twice
        /// </summary>
        [Test]
        public void AddValueTest2()
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
        public void CtorTest()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNodeCollection<String>( parent );
            Assert.AreSame( parent, target.Parent );
        }

        [Test]
        public void DetachFromParentTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            target.DetachFromParent();
            Assert.IsNull( target.Parent );
        }

        [Test]
        public void DetachFromParentTest1()
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

            target.ForEach( ( x, i ) => Assert.AreEqual( "test" + ( i + 1 ), x.Value ) );
        }

        [Test]
        public void ParentTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            Assert.AreEqual( parent, target.Parent );
        }

        [Test]
        public void ParentTest1()
        {
            var target = new TreeNodeCollection<String>( null );

            Assert.IsNull( target.Parent );
        }

        [Test]
        public void ParentTest2()
        {
            var target = new TreeNodeCollection<String>( null );
            Assert.IsNull( target.Parent );

            var parent = new TreeNode<String>();
            target.Parent = parent;
            Assert.AreSame( parent, target.Parent );
        }

        [Test]
        public void ParentTest3()
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
        public void ParentTest4()
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
        public void ParentTest5()
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
            // ReSharper disable once ExpressionIsAlwaysNull
            target.Parent = newParent;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.AreSame( newParent, target.Parent );
            // ReSharper disable once ExpressionIsAlwaysNull
            target.ForEach( x => Assert.AreSame( newParent, x.Parent ) );
        }

        [Test]
        public void ParentTest6()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent ) { Parent = null };

            Assert.AreEqual( null, target.Parent );
        }

        [Test]
        public void ParentTest7()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent )
            {
                Parent = parent
            };

            Assert.AreEqual( parent, target.Parent );
        }

        /// <summary>
        ///     Set parent.
        /// </summary>
        [Test]
        public void RemoveNodeTest()
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
        public void RemoveNodeTest1()
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
        public void RemoveNodeTest2()
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

        [Test]
        public void ToStringTest()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var actual = target.ToString();
            Assert.AreEqual( "[Depth: 0 - Value: '[NULL]', Children: 0]", actual );
        }

        [Test]
        public void ToStringTest1()
        {
            var target = new TreeNodeCollection<String>( null );

            var actual = target.ToString();
            Assert.AreEqual( "[Items Count: 0]", actual );
        }

        [Test]
        public void ToStringTest2()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent ) { "1", "2" };

            var actual = target.ToString();
            Assert.AreEqual( "[Depth: 0 - Value: '[NULL]', Children: 2]\r\n    [Depth: 1 - Value: '1', Children: 0]\r\n    [Depth: 1 - Value: '2', Children: 0]", actual );
        }

        [Test]
        public void ToStringTest3()
        {
            var target = new TreeNodeCollection<String>( null ) { "1", "2", "3" };

            var actual = target.ToString();
            Assert.AreEqual( "[Items Count: 3]", actual );
        }

        [Test]
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
            Assert.AreEqual(
                "[Depth: 0 - Value: 'Root', Children: 3]\r\n    [Depth: 1 - Value: '1', Children: 1]\r\n        [Depth: 2 - Value: 'A', Children: 3]\r\n            [Depth: 3 - Value: 'a', Children: 0]\r\n            [Depth: 3 - Value: 'b', Children: 0]\r\n            [Depth: 3 - Value: 'c', Children: 0]\r\n    [Depth: 1 - Value: '2', Children: 0]\r\n    [Depth: 1 - Value: '3', Children: 1]\r\n        [Depth: 2 - Value: 'B', Children: 3]\r\n            [Depth: 3 - Value: 'aa', Children: 0]\r\n            [Depth: 3 - Value: 'bb', Children: 0]\r\n            [Depth: 3 - Value: 'cc', Children: 0]",
                actual );
        }
    }
}